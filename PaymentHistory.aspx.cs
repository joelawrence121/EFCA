using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Home_MemberPayments : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindData();
        }
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

        int MemberID = Convert.ToInt32(Session["MemberID"]);
        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT MemberID, FirstName, LastName, Email, convert(varchar, DOB, 101) AS 'DOB', Monthly, Mobile FROM Member WHERE MemberID = @MemberID", connection);
            cmd.Parameters.AddWithValue("@MemberID", MemberID);
            SqlDataReader dr = cmd.ExecuteReader();
            gvMember.DataSource = dr;
            gvMember.DataBind();
            connection.Close();
        }

        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT Class.Name AS 'Lesson', LessonDay, LessonTime, convert(varchar, Date, 101) AS 'Date', Amount, Paid FROM Class, Lesson, Member, Attendance WHERE Attendance.MemberID = Member.MemberID AND Attendance.LessonID = Lesson.LessonID AND Lesson.ClassID = Class.ClassID AND Attendance.MemberID = @MemberID ORDER BY Date DESC; ", connection);
            cmd.Parameters.AddWithValue("@MemberID", MemberID);
            SqlDataReader dr = cmd.ExecuteReader();
            gvRecords.DataSource = dr;
            gvRecords.DataBind();
            connection.Close();
        }

    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Members.aspx");
    }
}