using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using Microsoft.VisualBasic;
using System.Configuration;

public partial class Home_ClubStats : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bindData();
    }

    private void bindData()
    {
        //verification that the user is an instructor
        //this data is for instructors eyes only
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


        int membersAmt;
        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            //simple count query to find all registered members.
            SqlCommand getmembers = new SqlCommand("SELECT COUNT(MemberID) FROM Member;", connection);
            membersAmt = (int)getmembers.ExecuteScalar();
            connection.Close();

        }
        //assign variable to label
        lblMemberCount.Text = membersAmt.ToString();

        
        //same thing done for:
        //instructor, class and lesson tables.

        int instructorsAmt;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand getinstructors = new SqlCommand("SELECT COUNT(InstructorID) FROM Instructor;", connection);
            instructorsAmt = (int)getinstructors.ExecuteScalar();
            connection.Close();

        }

        lblInstructorCount.Text = instructorsAmt.ToString();

        int classesAmt;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand getinstructors = new SqlCommand("SELECT COUNT(ClassID) FROM Class;", connection);
            classesAmt = (int)getinstructors.ExecuteScalar();
            connection.Close();

        }

        lblClassCount.Text = classesAmt.ToString();

        int lessonsAmt;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand getinstructors = new SqlCommand("SELECT COUNT(LessonID) FROM Lesson;", connection);
            lessonsAmt = (int)getinstructors.ExecuteScalar();
            connection.Close();

        }

        lblLessonCount.Text = lessonsAmt.ToString();

        int AdHoc = 0;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand getadhoc = new SqlCommand("SELECT COUNT(MemberID) FROM Member WHERE Monthly = 0;", connection);
            AdHoc = (int)getadhoc.ExecuteScalar();
            connection.Close();

        }
        lblAdHoc.Text = AdHoc.ToString();

        int Monthly = 0;
        Monthly = membersAmt - AdHoc;
        lblMonthly.Text = Monthly.ToString();
       

        List<string> Months = new List<string>();
        Months.Add("January");
        Months.Add("February");
        Months.Add("March");
        Months.Add("April");
        Months.Add("May");
        Months.Add("June");
        Months.Add("July");
        Months.Add("August");
        Months.Add("September");
        Months.Add("October");
        Months.Add("November");
        Months.Add("December");

        ddlMonths.DataSource = Months;
        ddlMonths.DataBind();
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminHome.aspx");
    }
}