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



public partial class Home_SignUp : System.Web.UI.Page
{



    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSignUp_Click(object sender, EventArgs e)
    {
        lblSuccess.Visible = false;
        lblError.Visible = false;

        
        //validate password function
        bool valid = ValidatePassword();
        if(valid)
        {
            //try catch loops to handle errors in data entry
 
            try
            {
                MemberInsert();
                MemberDisplay();
                LoginSave();
                lblSuccess.Visible = true;
            }
            catch
            {
                lblError.Visible = true;
            }
            
        }
              
    }

    private void LoginSave()
    {
        //hashpassword
        string password = txtPassword.Text;
        string hash = HashPassword(password, null);

        //get MemberID 
        int MemberID = Convert.ToInt32(gvID.Rows[0].Cells[0].Text);

        //Insert into Login table
        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            String insertLogin = "INSERT INTO MemberLogin (MemberID, MemberSalt) VALUES (@MemberID, @MemberSalt);";
            using (SqlCommand command = new SqlCommand(insertLogin, connection))
            {
                command.Parameters.AddWithValue("@MemberID", MemberID);
                command.Parameters.AddWithValue("@MemberSalt", hash);
                connection.Open();
                int result = command.ExecuteNonQuery();
                connection.Close();
            }
        }


    }


    private void MemberDisplay()
    {
        string strFirstName = txtFirstName.Text;
        string strLastName = txtLastName.Text;
        string strEmail = txtEmail.Text;
        DateTime DOB = Convert.ToDateTime(txtDOB.Text);
        DateTime SignUp = Convert.ToDateTime(DateTime.Today.ToString("dd/MM/yyyy"));
        int Monthly = 0;
        if (ddlPayment.SelectedValue == "Monthly")
        {
            Monthly = 1;
        }
        string strPostcode = txtPostcode.Text;
        string strAddress = txtAddress1.Text + ", " + txtAddress2.Text + ", " + txtAddress3.Text;
        string strMobile = txtMobile.Text;

        //use data entered as composite key to get memberID associated to it
        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            String displayMember = "SELECT MemberID FROM Member WHERE FirstName = @FirstName AND LastName = @LastName AND Email = @Email AND DOB = @DOB AND Address = @Address";
            using (SqlCommand command = new SqlCommand(displayMember, connection))
            {
                command.Parameters.AddWithValue("@FirstName", strFirstName);
                command.Parameters.AddWithValue("@LastName", strLastName);
                command.Parameters.AddWithValue("@Email", strEmail);
                command.Parameters.AddWithValue("@DOB", DOB);
                command.Parameters.AddWithValue("@Address", strAddress);

                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                gvID.DataSource = dr;
                gvID.DataBind();
                gvID.Visible = true;
                lblInformation.Visible = true;
                connection.Close();
            }
        }
    }

    private bool ValidatePassword()
    {
        //validate password according to three criteria:
        //passwords entered must match
        //password must be 6 characters or longer
        //password cannot be null

        string password1 = txtPassword.Text;
        string password2 = txtConfirmPassword.Text;
        bool valid = false;
        string errormessage = "";
        if (password1 != password2)
        {
            //error messages tailored to each specific not met criteria
            errormessage = "The passwords do not match.";
            valid = false;
            lblPWError.Text = errormessage;
            lblPWError.Visible = true;
        }
        else if (password1.Length < 6 && password1.Length != 0)
        {
            errormessage = "The password is not long enough, minimum 6 characters.";
            valid = false;
            lblPWError.Text = errormessage;
            lblPWError.Visible = true;
        }
        else if (password1.Length == 0)
        {
            errormessage = "Please enter a value for the password.";
            valid = false;
            lblPWError.Text = errormessage;
            lblPWError.Visible = true;
        }
        else
        {
            lblPWError.Text = errormessage;
            lblPWError.Visible = true;
            valid = true;
        }

        return valid;



    }

    private void MemberInsert()
    {
        //try catch loop to avoid crashing
        //try
        //{
            //get the data from the front end
            string strFirstName = txtFirstName.Text;
            string strLastName = txtLastName.Text;
            string strEmail = txtEmail.Text;
            DateTime DOB = Convert.ToDateTime(txtDOB.Text);
            DateTime SignUp = Convert.ToDateTime(DateTime.Today.ToString("dd/MM/yyyy"));
            int Monthly = 0;
            if (ddlPayment.SelectedValue == "Monthly")
            {
                Monthly = 1;
            }
            int Test = 1 / (strFirstName.Length) + 1 / (strLastName.Length) + 1 / (strEmail.Length); 
            string strPostcode = txtPostcode.Text;
            string strAddress = txtAddress1.Text + ", " + txtAddress2.Text + ", " + txtAddress3.Text;
            string strMobile = txtMobile.Text;

            //Insert data into the database
            string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cs))
            {
                String insertMember = "INSERT INTO Member (FirstName,LastName,Email,DOB,Monthly,DateSignUp,Address,Postcode,Mobile) VALUES (@FirstName,@LastName,@Email,@DOB,@Monthly,@DateSignUp,@Address,@Postcode,@Mobile)";


                using (SqlCommand command = new SqlCommand(insertMember, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", strFirstName);
                    command.Parameters.AddWithValue("@LastName", strLastName);
                    command.Parameters.AddWithValue("@Email", strEmail);
                    command.Parameters.AddWithValue("@DOB", DOB);
                    command.Parameters.AddWithValue("@Monthly", Monthly);
                    command.Parameters.AddWithValue("@DateSignUp", SignUp);
                    command.Parameters.AddWithValue("@Address", strAddress);
                    command.Parameters.AddWithValue("@Postcode", strPostcode);
                    command.Parameters.AddWithValue("@Mobile", strMobile);

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    lblSuccess.Visible = true;
                    connection.Close();



                }


            }
        //}
        //catch
        //{
            //if there is an error, catch it and display error to user
            //lblPWError.Visible = true;
        //}
        
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("SignUp.aspx");
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("LogIn.aspx");
    }
    protected void TextBox9_TextChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

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