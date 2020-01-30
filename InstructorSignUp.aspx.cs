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


public partial class Home_InstructorSignUp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //verification of instructor in session
        try
        {
            Instructor Instructor1 = (Instructor)Session["Instructor"];
            if (Instructor1.Verify() == false)
            {
                Response.Redirect("Login.aspx");
            }
        }
        catch
        {
            Response.Redirect("Login.aspx");
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Instructors.aspx");
    }
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        //reset success and error labels
        lblSuccess.Visible = false;
        lblError.Visible = false;
        lblError0.Visible = false;

        //call validate function to check password
        bool valid = ValidatePassword();

        //if valid = true 
        if (valid)
        {
            //try catch loop to catch data entry errors
            try
            {
                //insert instructor function
                InstructorInsert();
                InstructorDisplay();
                LoginSave();
                //if done without errors, success label visible

            }
            catch
            {
                //if error occurs, error message displayed
                lblError.Visible = true;
            }

            //then display the instructorID to the instructor

            //save ID and password to InstructorLogin table
            
        }
   
    }

    private void LoginSave()
    {
        //hash password
        string password = txtPassword.Text;
        string hash = HashPassword(password, null);

        //get MemberID 
        int InstructorID = Convert.ToInt32(gvID.Rows[0].Cells[0].Text);

        //Insert into Login table
        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            String insertLogin = "INSERT INTO InstructorLogin (InstructorID, InstructorSalt) VALUES (@InstructorID, @InstructorSalt);";
            using (SqlCommand command = new SqlCommand(insertLogin, connection))
            {
                command.Parameters.AddWithValue("@InstructorID", InstructorID);
                command.Parameters.AddWithValue("@InstructorSalt", hash);
                connection.Open();
                int result = command.ExecuteNonQuery();
                connection.Close();
            }
        }
        lblSuccess.Visible = true;

    }

    private bool ValidatePassword()
    {
        //assigning inputted passwords
        string password1 = txtPassword.Text;
        string password2 = txtConfirmPW.Text;
        bool valid = false;

        string errormessage = "";
        if (password1 != password2)
        {
            //first invalid: 
            //passwords do not match
            errormessage = "The passwords do not match.";
            valid = false;
            lblPasswordError.Text = errormessage;
            lblPasswordError.Visible = true;
        }
        else if (password1.Length < 6 && password1.Length != 0)
        {
            //second invalid:
            //password not long enough
            errormessage = "The password is not long enough, minimum 6 characters.";
            valid = false;
            lblPasswordError.Text = errormessage;
            lblPasswordError.Visible = true;
        }
        else if (password1.Length == 0)
        {
            //third error:
            //no password entered
            errormessage = "Please enter a value for the password.";
            valid = false;
            lblPasswordError.Text = errormessage;
            lblPasswordError.Visible = true;
        }
        else
        {
            //if they meet all valid requirements
            //function should return true
            lblPasswordError.Text = errormessage;
            lblPasswordError.Visible = true;
            valid = true;
        }

        //return valid boolean
        return valid;
    }

    private void InstructorDisplay()
    {
        //getting all the data associated to the instructor
        string strFirstName = txtFirstName.Text;
        string strLastName = txtLastName.Text;
        string strEmail = txtEmail.Text;
        DateTime DOB = Convert.ToDateTime(txtDOB.Text);
        DateTime SignUp = Convert.ToDateTime(DateTime.Today.ToString("dd/MM/yyyy"));
        string strPostcode = txtPostcode.Text;
        string strAddress = txtAddressLine1.Text + ", " + txtAddressLine2.Text + ", " + txtAddressLine3.Text;
        string strMobile = txtMobile.Text;


        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            String displayInstructor = "SELECT InstructorID FROM Instructor WHERE FirstName = @FirstName AND LastName = @LastName AND Email = @Email AND DOB = @DOB AND Address = @Address";
            using (SqlCommand command = new SqlCommand(displayInstructor, connection))
            {
                //using the data as a composite key to get the primary key associated to it
                //eg using all the data to get the instructor ID 
                command.Parameters.AddWithValue("@FirstName", strFirstName);
                command.Parameters.AddWithValue("@LastName", strLastName);
                command.Parameters.AddWithValue("@Email", strEmail);
                command.Parameters.AddWithValue("@DOB", DOB);
                command.Parameters.AddWithValue("@Address", strAddress);

                connection.Open();
                SqlDataReader dr = command.ExecuteReader();

                //binding result to gridview
                gvID.DataSource = dr;
                gvID.DataBind();
                gvID.Visible = true;
                lblInformation.Visible = true;
                connection.Close();
            }
        }
    }

    private void InstructorInsert()
    {
        lblError0.Visible = false;
        string strFirstName = txtFirstName.Text;
        string strLastName = txtLastName.Text;
        string strEmail = txtEmail.Text;
        DateTime DOB = Convert.ToDateTime(txtDOB.Text);

        DateTime SignUp = Convert.ToDateTime(DateTime.Today.ToString("dd/MM/yyyy"));
        string strPostcode = txtPostcode.Text;
        string strAddress = txtAddressLine1.Text + ", " + txtAddressLine2.Text + ", " + txtAddressLine3.Text;
        string strMobile = txtMobile.Text;

        //throw error if required fields blank
        int Test = 1 / (strFirstName.Length) + 1 / (strLastName.Length) + 1 / (strEmail.Length);

        //inserting data 
        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            String insertInstructor = "INSERT INTO Instructor (FirstName,LastName,Email,DOB,DateSignUp,Address,Postcode,Mobile) VALUES (@FirstName,@LastName,@Email,@DOB,@DateSignUp,@Address,@Postcode,@Mobile)";
            //fundamental query to insert data into the instructor table

            using (SqlCommand command = new SqlCommand(insertInstructor, connection))
            {
                //adding variables to the query
                command.Parameters.AddWithValue("@FirstName", strFirstName);
                command.Parameters.AddWithValue("@LastName", strLastName);
                command.Parameters.AddWithValue("@Email", strEmail);
                command.Parameters.AddWithValue("@DOB", DOB);
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
        
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("InstructorSignUp.aspx");
    }
    protected void TextBox9_TextChanged(object sender, EventArgs e)
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