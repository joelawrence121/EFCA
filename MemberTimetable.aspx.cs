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

public partial class Home_MemberTimetable : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bindData();
        
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("MemberHome.aspx");
    }
    private void bindData()
    {
        //verification
        try
        {
            User User1 = (User)Session["User"];
            string fullname = User1.getfirstname() + " " + User1.getlastname();
        }
        catch
        {
            Response.Redirect("Login.aspx");
        }

        //list of days 
        List<string> days = new List<string>();
        days.Add("Monday");
        days.Add("Tuesday");
        days.Add("Wednesday");
        days.Add("Thursday");
        days.Add("Friday");
        days.Add("Saturday");
        days.Add("Sunday");

        //loop through all days in the list
        foreach (string day in days)
        {
            //call getDayData function
            getDayData(day);
        }
 
    }

    private void getDayData(string day)
    { 
        //function to get lesson data about each day
        //then attach that query result to the different grid views
        string gridviewname = "gv" + day;
        //find the gridview control attached to the gridview name with the day
        GridView gv = (GridView)FindControl(gridviewname);

        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT Name AS 'Class Name', FirstName + ' ' + LastName AS 'Instructor', LessonDuration AS 'Lesson Duration (hrs)', LessonTime AS 'Lesson Start', DATEADD(minute, (60*LessonDuration), LessonTime) AS 'Lesson End' FROM Lesson, Class, Instructor WHERE Lesson.ClassID = Class.ClassID AND Lesson.InstructorID = Instructor.InstructorID AND LessonDay = @Day ORDER BY LessonTime ASC;", connection);
            command.Parameters.AddWithValue("@Day", day);
            //query specific to that day
            SqlDataReader dr = command.ExecuteReader();
            gv.DataSource = dr;
            gv.DataBind();
            dr.Close();
            connection.Close();

        }
    }
}