using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using Microsoft.VisualBasic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
/// <summary>
/// The user will serve as the parent class holding details about the Members
/// and Instructors, essential for the ordering, attendance and others. 
/// </summary>
public class User
{
    public string FirstName;
    public string LastName;
    public int UserID;

    public virtual Boolean Verify()
    {
        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        int result;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand ifMember = new SqlCommand("SELECT COUNT(*) FROM Member WHERE Member.MemberID = @MemberID;", connection);
            ifMember.Parameters.AddWithValue("@MemberID", UserID);
            result = (int)ifMember.ExecuteScalar();
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

    public User()
    {
        FirstName = "unknown";
        LastName = "unknown";
        UserID = 0;
    }

    public User(string inFirstName, string inLastName, int inID)
    {
        FirstName = inFirstName;
        LastName = inLastName;
        UserID = inID;
    }

    public void SetName(string inFirstName, string inLastName)
    {
        FirstName = inFirstName;
        LastName = inLastName;
    }
    
    public string getfirstname()
    {
        return FirstName;
    }

    public string getlastname()
    {
        return LastName;
    }

    public int getID()
    {
        return UserID;
    }
}
	
