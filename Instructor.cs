using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using Microsoft.VisualBasic;
using System.Configuration;

/// <summary>
/// Summary description for Instructor
/// </summary>
public class Instructor : User
{
    public override Boolean Verify()
    {
        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        int result;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand ifInstructor = new SqlCommand("SELECT COUNT(*) FROM Instructor WHERE Instructor.InstructorID = @InstructorID;", connection);
            ifInstructor.Parameters.AddWithValue("@InstructorID", UserID);
            result = (int)ifInstructor.ExecuteScalar();
            connection.Close();
        }

        if (result == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
        

    }

    public Instructor(string inputFName, string inputLName, int inputID)
    {
        FirstName = inputFName;
        LastName = inputLName;
        UserID = inputID;
    }
	
}