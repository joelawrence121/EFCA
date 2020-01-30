using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
using System.Security;
using System.Security.Cryptography;
using System.Text;


public partial class Home_LogIn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSignUp_Click(object sender, EventArgs e)
    {
        Response.Redirect("SignUp.aspx");    //redirect to sign up page
    }
    protected void btnLogIn_Click(object sender, EventArgs e)
    {
        //NEED: Hashvalue from db, MemberID, Password
        int MemberID = 0;
        string Password = "";

        try
        {
            MemberID = Convert.ToInt32(TextBox1.Text);
            Password = TextBox2.Text;
        }
        catch
        {
            lblInvalid.Visible = true;
        }

        

        //Get HashValue from DB
        string hash = ""; 
        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            //get the hash value stored in the database for the specified MemberID
            String displayMember = "SELECT MemberSalt FROM MemberLogin WHERE MemberID = @MemberID;";
            using (SqlCommand command = new SqlCommand(displayMember, connection))
            {
                command.Parameters.AddWithValue("@MemberID", MemberID);
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                //get results of query into string
                while(dr.Read())
                {
                    //string value = query result
                    hash = dr[0].ToString();
                }
                connection.Close();
            }
        }

        //Verify 
        bool ValidCreds = Verify(Password, hash); //see if password given hashed equals hash in database
        if(ValidCreds == true)
        {
            //if true (valid) 
            //instantiate object of user class 
            string FirstName = getFirstName(MemberID); //calls getFirstName function to assign first name given the ID
            string LastName = getLastName(MemberID); //Same as above but with last name
            User User1 = new User(FirstName, LastName ,MemberID); //Instantiating object using constructor
            Session["User"] = User1; //saving object in session to allow access in the next pages
            //
            Response.Redirect("MemberHome.aspx"); //redirect to memberhome
        }
        else
        {
            lblInvalid.Visible=true; //display error message
        }



    }

    private string getFirstName(int MemberID)
    {
        // function to return the first name of the member given their memberid
        string FirstName;
        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand getFirstName = new SqlCommand("SELECT FirstName FROM Member WHERE MemberID = @MemberID;", connection);
            getFirstName.Parameters.AddWithValue("@MemberID", MemberID);
            //assign query result to string
            FirstName = (string)getFirstName.ExecuteScalar();
            connection.Close();
            return FirstName;
        }
    }

    private string getLastName(int MemberID)
    {
        //function to return last name of member given their memberid from the database
        string LastName;
        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand getLastName = new SqlCommand("SELECT LastName FROM Member WHERE MemberID = @MemberID;", connection);
            getLastName.Parameters.AddWithValue("@MemberID", MemberID);
            //assign value to lastname variable
            LastName = (string)getLastName.ExecuteScalar();
            connection.Close();
            return LastName;
        }
    }
    protected void imgbtnLogo_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("AdminLogin.aspx"); //redirect to adminlogin page
    }

    public static bool Verify(string plainText, string hashValue)
    {
        //convert hash value into byte array
        byte[] byteHashSalt = Convert.FromBase64String(hashValue);

        int hashByteSize;
        hashByteSize = 20; //this is the hash size of the secure hash algorithm

        // If the hash value is less than the standard byte size, it is not valid.
        // As it would not have been done with the same algorithm.
        if (byteHashSalt.Length < hashByteSize)
        {
            return false;
        }

        // Array holds the original salt bytes from the hash value.
        byte[] saltBytes = new byte[byteHashSalt.Length - hashByteSize];

        // Copy salt from the end of the hash to the new array.
        for (int i = 0; i < saltBytes.Length; i++)
        {
            saltBytes[i] = byteHashSalt[hashByteSize + i];
        }
     
        string expectedHashString = HashPassword(plainText, saltBytes);
        return (hashValue == expectedHashString);
    }

    public static string HashPassword(string Password, byte[] saltBytes)
    {
        if (saltBytes == null)
        {
            // Generate random number for salt between 4 and 8.
            Random random = new Random();
            int saltSize = random.Next(4, 8);

            // New byte array which holds salt.
            saltBytes = new byte[saltSize];

            // Create secure new random generator.
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

            // Assign the salt secure byte values.
            rng.GetNonZeroBytes(saltBytes);
        }

        // Convert password into array of bytes.
        byte[] PasswordBytes = Encoding.UTF8.GetBytes(Password);

        // Create array which will hold the password and the salt
        byte[] PasswordWithSaltBytes = new byte[PasswordBytes.Length + saltBytes.Length];

        // Copy password bytes into array.
        for (int i = 0; i < PasswordBytes.Length; i++)
        {
            PasswordWithSaltBytes[i] = PasswordBytes[i];
        }
            

        // Add salt bytes to array.
        for (int i = 0; i < saltBytes.Length; i++)
        {
            PasswordWithSaltBytes[PasswordBytes.Length + i] = saltBytes[i];
        }
            
        HashAlgorithm hash;
        hash = new SHA1Managed();

        // Compute a hash value for the password with its salt.
        byte[] hashBytes = hash.ComputeHash(PasswordWithSaltBytes);

        // Create array that will hold the bytes and the salt.
        byte[] hashWithSaltBytes = new byte[hashBytes.Length + saltBytes.Length];

        // Copy hash bytes into new salt hash array.
        for (int i = 0; i < hashBytes.Length; i++)
        {
            hashWithSaltBytes[i] = hashBytes[i];
        }    

        // Add salt bytes to the calculated hash.
        for (int i = 0; i < saltBytes.Length; i++)
        {
            hashWithSaltBytes[hashBytes.Length + i] = saltBytes[i];
        }
            
        // Convert result into a string.
        string hashValue = Convert.ToBase64String(hashWithSaltBytes);

        // Return the result.
        return hashValue;
    }
    
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogIn.aspx"); //refreshes page, clears text boxes
        }

        protected void lbtnForgot_Click(object sender, EventArgs e)
        {
            Response.Redirect("Forgot.aspx"); //redirects to forgot page
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Response.Redirect("Template.aspx");
        }
}
