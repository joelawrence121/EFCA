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

public partial class Home_EditAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //only bind data on first instance of page load
        //not postback means so that if text boxes change it doesnt bind data
        if (!Page.IsPostBack)
        {
            bindData();
        }
    }

    private void bindData()
    {
        //verfication in bind data first
        try
        {
            Instructor Instructor1 = (Instructor)Session["Instructor"];
            //instantiating an object from the session instructor
            if (Instructor1.Verify() == false)
            {
                Response.Redirect("Login.aspx");
            }
        }
        catch
        {
            Response.Redirect("Login.aspx");
        }


        Instructor Instructor = (Instructor)Session["Instructor"];
        int InstructorID = Instructor.getID();
        string FirstName, LastName, email, postcode, address, mobile;
        DateTime DOB = new DateTime();
        FirstName = Instructor.getfirstname();
        LastName = Instructor.getlastname();
        

        //this is to bind the already existing data
        //all properties selected through the queries to get them into the text boxes
        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand getDetails = new SqlCommand("SELECT Email FROM Instructor WHERE InstructorID = @InstructorID;", connection);
            getDetails.Parameters.AddWithValue("@InstructorID", InstructorID);
            email = (string)getDetails.ExecuteScalar();
            connection.Close();
        }

        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand getDetails = new SqlCommand("SELECT DOB FROM Instructor WHERE InstructorID = @InstructorID;", connection);
            getDetails.Parameters.AddWithValue("@InstructorID", InstructorID);
            DOB = (DateTime)getDetails.ExecuteScalar();
            connection.Close();
        }
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand getDetails = new SqlCommand("SELECT Postcode FROM Instructor WHERE InstructorID = @InstructorID;", connection);
            getDetails.Parameters.AddWithValue("@InstructorID", InstructorID);
            postcode = (string)getDetails.ExecuteScalar();
            connection.Close();
        }
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand getDetails = new SqlCommand("SELECT Address FROM Instructor WHERE InstructorID = @InstructorID;", connection);
            getDetails.Parameters.AddWithValue("@InstructorID", InstructorID);
            address = (string)getDetails.ExecuteScalar();
            connection.Close();
        }
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand getDetails = new SqlCommand("SELECT Mobile FROM Instructor WHERE InstructorID = @InstructorID;", connection);
            getDetails.Parameters.AddWithValue("@InstructorID", InstructorID);
            mobile = (string)getDetails.ExecuteScalar();
            connection.Close();
        }

        //assigning all values to their textboxes
        txtID.Text = InstructorID.ToString();
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
        Response.Redirect("AdminHome.aspx");
    }

    protected void btnConfirmChanges_Click(object sender, EventArgs e)
    {
        updateInstructor();
    }

    private void updateInstructor()
    {
        //try catch loop to catch errors in wrong data types
        try
        {
            Instructor Instructor = (Instructor)Session["Instructor"];
            
            //getting all new data for the different fields
            int InstructorID = Instructor.getID();

            string strFirstName = txtFirstName.Text;
            string strLastName = txtLastName.Text;
            
            //throw exception if names are blank.
            int check = 1 / (strFirstName.Length) + 1 / (strLastName.Length);

            string strEmail = txtEmail.Text;
            DateTime DOB = Convert.ToDateTime(txtDOB.Text);
            string strPostcode = txtPostcode.Text;
            string strAddress = txtAddress.Text;
            string strMobile = txtMobile.Text;

            string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cs))
            {
                String updateInstructor = "UPDATE Instructor SET FirstName = @FirstName, LastName = @LastName, Email = @Email, DOB = @DOB, Address = @Address, Postcode = @Postcode, Mobile = @Mobile WHERE InstructorID = @InstructorID;";
                //update query set to instructorID

                using (SqlCommand command = new SqlCommand(updateInstructor, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", strFirstName);
                    command.Parameters.AddWithValue("@LastName", strLastName);
                    command.Parameters.AddWithValue("@Email", strEmail);
                    command.Parameters.AddWithValue("@DOB", DOB);
                    command.Parameters.AddWithValue("@Address", strAddress);
                    command.Parameters.AddWithValue("@Postcode", strPostcode);
                    command.Parameters.AddWithValue("@Mobile", strMobile);
                    command.Parameters.AddWithValue("@InstructorID", InstructorID);

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    connection.Close();

                    //if all code above is executed successfully without errors,
                    //success label is made visible
                    lblSuccess.Visible = true;

                }
            }

            //updating the session to get the new first and last name
            Instructor.SetName(strFirstName, strLastName);
        }
        catch
        {
            //if an error occurs, error message is made visible
            lblError.Visible = true;
        }


    }

    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        try
        {
            Instructor Instructor = (Instructor)Session["Instructor"];
            int InstructorID = Instructor.getID();

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
                SqlCommand getDetails = new SqlCommand("SELECT InstructorSalt FROM InstructorLogin WHERE InstructorID = @InstructorID;", connection);
                getDetails.Parameters.AddWithValue("@InstructorID", InstructorID);
                actual = (string)getDetails.ExecuteScalar();
                connection.Close();
            }

            if (Verify(old, actual))
            {
                newsalt = HashPassword(changed, null);

                using (SqlConnection connection = new SqlConnection(cs))
                {
                    connection.Open();
                    SqlCommand updatePw = new SqlCommand("UPDATE InstructorLogin SET InstructorSalt = @NewSalt WHERE InstructorID = @InstructorID;", connection);
                    updatePw.Parameters.AddWithValue("@InstructorID", InstructorID);
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