using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

public partial class Home_Transactions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bindData();
    }

    private void bindData()
    {
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

        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT Attendance.MemberID, Member.FirstName + ' ' + Member.LastName AS 'Member', Class.Name, Instructor.FirstName + ' ' + Instructor.LastName AS 'Instructor', Attendance.Date, Member.Monthly, Attendance.Amount, Attendance.Paid FROM Member, Instructor, Attendance, Lesson, Class WHERE Attendance.MemberID = Member.MemberID AND Attendance.InstructorID = Instructor.InstructorID AND Attendance.LessonID = Lesson.LessonID AND Lesson.ClassID = Class.ClassID ORDER BY Attendance.Date DESC;", connection);
            SqlDataReader dr = command.ExecuteReader();
            gvAdHoc.DataSource = dr;
            gvAdHoc.DataBind();
            dr.Close();
            connection.Close();

        }

        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT MonthlyPayment.MemberID, Member.FirstName + ' ' + Member.LastName AS 'Member', Month, Year, Amount, Paid, Instructor.FirstName + ' ' + Instructor.LastName AS 'Taken By' FROM MonthlyPayment, Member, Instructor WHERE Member.MemberID = MonthlyPayment.MemberID AND MonthlyPayment.InstructorID = Instructor.InstructorID;", connection);
            SqlDataReader dr = command.ExecuteReader();
            gvMonthlyPayments.DataSource = dr;
            gvMonthlyPayments.DataBind();
            dr.Close();
            connection.Close();

        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminHome.aspx");
    }
    protected void gvAdHoc_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gvMonthlyPayments_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}