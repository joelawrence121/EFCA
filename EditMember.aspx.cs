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

public partial class Home_EditMember : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            bindData();
        }
        
    }

    private void bindData()
    {
        //verification method
        try
        {
            User User1 = (User)Session["User"];
            string fullname = User1.getfirstname() + " " + User1.getlastname();
        }
        catch
        {
            Response.Redirect("Login.aspx");
        }
        //object instantiated to session variable
        User Member = (User)Session["User"];

        //get ID from currently logged in member
        int MemberID = Member.getID();
        string FirstName, LastName, email, postcode, address, mobile;
        DateTime DOB = new DateTime();
        FirstName = Member.getfirstname();
        LastName = Member.getlastname();

        //get fields to be displayed
        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand getDetails = new SqlCommand("SELECT Email FROM Member WHERE MemberID = @MemberID;", connection);
            getDetails.Parameters.AddWithValue("@MemberID", MemberID);
            email = (string)getDetails.ExecuteScalar();
            connection.Close();
        }

        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand getDetails = new SqlCommand("SELECT DOB FROM Member WHERE MemberID = @MemberID;", connection);
            getDetails.Parameters.AddWithValue("@MemberID", MemberID);
            DOB = (DateTime)getDetails.ExecuteScalar();
            connection.Close();
        }
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand getDetails = new SqlCommand("SELECT Postcode FROM Member WHERE MemberID = @MemberID;", connection);
            getDetails.Parameters.AddWithValue("@MemberID", MemberID);
            postcode = (string)getDetails.ExecuteScalar();
            connection.Close();
        }
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand getDetails = new SqlCommand("SELECT Address FROM Member WHERE MemberID = @MemberID;", connection);
            getDetails.Parameters.AddWithValue("@MemberID", MemberID);
            address = (string)getDetails.ExecuteScalar();
            connection.Close();
        }
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand getDetails = new SqlCommand("SELECT Mobile FROM Member WHERE MemberID = @MemberID;", connection);
            getDetails.Parameters.AddWithValue("@MemberID", MemberID);
            mobile = (string)getDetails.ExecuteScalar();
            connection.Close();
        }

        txtID.Text = MemberID.ToString();
        txtFirstName.Text = FirstName;
        txtLastName.Text = LastName;
        txtEmail.Text = email;
        txtDOB.Text = DOB.ToString("dd/MM/yyyy");
        txtPostcode.Text = postcode;
        txtAddress.Text = address;
        txtMobile.Text = mobile;
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("MemberHome.aspx");
    }
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        //function to update values for a member in the db
        updateMember();
    }

    private void updateMember()
    {
        //try catch to handle data entry errors
        try
        {
            //object instantiated again as it is a different function
            User Member = (User)Session["User"];
            int MemberID = Member.getID();

            //getting new values
            string strFirstName = txtFirstName.Text;
            string strLastName = txtLastName.Text;

            //throw exception if names are blank.
            int check = 1 / (strFirstName.Length) + 1 / (strLastName.Length);

            string strEmail = txtEmail.Text;
            DateTime DOB = Convert.ToDateTime(txtDOB.Text);
            int Monthly = 0;
            if (ddlPayment.SelectedValue == "Monthly")
            {
                Monthly = 1;
            }
            string strPostcode = txtPostcode.Text;
            string strAddress = txtAddress.Text;
            string strMobile = txtMobile.Text;

            string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cs))
            {
                String updateMember = "UPDATE Member SET FirstName = @FirstName, LastName = @LastName, Email = @Email, DOB = @DOB, Monthly = @Monthly, Address = @Address, Postcode = @Postcode, Mobile = @Mobile WHERE MemberID = @MemberID;";
                //update query

                using (SqlCommand command = new SqlCommand(updateMember, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", strFirstName);
                    command.Parameters.AddWithValue("@LastName", strLastName);
                    command.Parameters.AddWithValue("@Email", strEmail);
                    command.Parameters.AddWithValue("@DOB", DOB);
                    command.Parameters.AddWithValue("@Monthly", Monthly);
                    command.Parameters.AddWithValue("@Address", strAddress);
                    command.Parameters.AddWithValue("@Postcode", strPostcode);
                    command.Parameters.AddWithValue("@Mobile", strMobile);
                    command.Parameters.AddWithValue("@MemberID", MemberID);

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    connection.Close();
                    //if done without errors, success label visible
                    lblSuccess.Visible = true;
                    
                }
            }

            Member.SetName(strFirstName, strLastName);
        }
        catch
        {
            //if an error occurs, doesn't crash, shows error message
            lblError.Visible = true;
        }

    }

    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        try
        {
            User Member = (User)Session["User"];
            int MemberID = Member.getID();

            lblErrorOld.Visible = false;
            lblSuccessP.Visible = false;
            lblErrorP.Visible = false;

            string old, changed, actual, newsalt;
            old = txtPassword.Text;
            changed = txtNewPassword.Text;

            //get actual salt
            string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand getDetails = new SqlCommand("SELECT MemberSalt FROM MemberLogin WHERE MemberID = @MemberID;", connection);
                getDetails.Parameters.AddWithValue("@MemberID", MemberID);
                actual = (string)getDetails.ExecuteScalar();
                connection.Close();
            }

            if (Verify(old, actual))
            {
                newsalt = HashPassword(changed, null);

                using (SqlConnection connection = new SqlConnection(cs))
                {
                    connection.Open();
                    SqlCommand updatePw = new SqlCommand("UPDATE MemberLogin SET MemberSalt = @NewSalt WHERE MemberID = @MemberID;", connection);
                    updatePw.Parameters.AddWithValue("@MemberID", MemberID);
                    updatePw.Parameters.AddWithValue("@NewSalt", newsalt);
                    int result = updatePw.ExecuteNonQuery();
                    connection.Close();
                }

                lblSuccessP.Visible = true;
            }
            else
            {
                lblErrorOld.Visible = true;
            }


        }
        catch
        {
            lblErrorP.Visible = true;
        }


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
}