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

public partial class Home_AttendanceRecords : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //only bind data on first instance of page load. 
        if(!Page.IsPostBack)
        {
            bindData();
        }
        
        
    }

    private void bindData()
    {
        // verification of instructor 
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

        //new instance of lesson class
        //assigned in previous page and saved to session
        Lesson Lesson = (Lesson)Session["Lesson"];

        //query to get the lesson in question
        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT DISTINCT LessonID, Name AS 'Class Name', LessonDay, FirstName AS 'Instructor First Name', LastName AS 'Instructor Last Name', LessonDuration AS 'Lesson Duration (hrs)', LessonTime AS 'Lesson Start' FROM Lesson, Class, Instructor WHERE Lesson.ClassID = Class.ClassID AND Lesson.InstructorID = Instructor.InstructorID AND Lesson.ClassID = @ClassID AND Class.ClassID = @ClassID AND Instructor.InstructorID = @InstructorID AND Lesson.InstructorID = @InstructorID AND Lesson.LessonID = @LessonID;", connection);
            command.Parameters.AddWithValue("@ClassID", Lesson.getClassID());
            command.Parameters.AddWithValue("@InstructorID", Lesson.getInstructorID());
            command.Parameters.AddWithValue("@LessonID", Lesson.getLessonID());

            SqlDataReader dr = command.ExecuteReader();
            gvLesson.DataSource = dr;
            gvLesson.DataBind();
            dr.Close();
        }


        //list of date times, to bind it to the ddl to pick
        List<DateTime> datelist = new List<DateTime>();
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            //finding the unique dates of all the attendance records
            //thus getting all the dates
            SqlCommand getdates = new SqlCommand("SELECT DISTINCT Date FROM Attendance WHERE InstructorID = @InstructorID AND LessonID = @LessonID;", connection);
            getdates.Parameters.AddWithValue("@InstructorID", Lesson.getInstructorID());
            getdates.Parameters.AddWithValue("@LessonID", Lesson.getLessonID());
            using (var reader = getdates.ExecuteReader())
            {
                while (reader.Read())
                {
                    //adding each date to the date list
                    datelist.Add(reader.GetDateTime(0));
                }
            }
            connection.Close();

        }
        List<string> StringDateList  = new List<string>();
        foreach(DateTime date in datelist)
        {
            //looping through each item in date list
            //converting item to dd/MM/yyyy format
            StringDateList.Add(date.ToString("dd/MM/yyyy"));
        }

        //accounting for if no records for that lesson
        if(StringDateList.Count() == 0)
        {
            //making error visible, making the lbl and ddl invisible
            lblNoRecords.Visible = true;
            lblDate.Visible = false;
            ddlDates.Visible = false;
        }
        else
        {
            //else bind string date list to ddl 
            ddlDates.DataSource = StringDateList;
            ddlDates.DataBind();
            //call get records function
            getRecords();
        }

        
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Timetable.aspx");
    }
    protected void ddlDates_SelectedIndexChanged(object sender, EventArgs e)
    {
        getRecords();
    }

    private void getRecords()
    {
        //function to get the attendance records for a given lessonID
        //Instantiate new lesson from lession saved in session
        Lesson Lesson = (Lesson)Session["Lesson"];
        //date is the selected ddl item
        DateTime date = Convert.ToDateTime(ddlDates.SelectedValue);
        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            //select distinct first name and last name and monthly
            SqlCommand getdates = new SqlCommand("SELECT DISTINCT FirstName + ' ' + LastName AS 'Name', Paid, Amount, Member.Monthly FROM Member, Lesson, Attendance WHERE Attendance.LessonID = @LessonID AND Attendance.InstructorID = @InstructorID AND Member.MemberID = Attendance.MemberID AND Attendance.Date = @Date;", connection);
            getdates.Parameters.AddWithValue("@LessonID", Lesson.getLessonID());
            getdates.Parameters.AddWithValue("@InstructorID", Lesson.getInstructorID());
            getdates.Parameters.AddWithValue("@Date", date);
            SqlDataReader dr = getdates.ExecuteReader();
            gvMembers.DataSource = dr;
            gvMembers.DataBind();
            connection.Close();

        }

    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        //when refreshed, get records function made again
        getRecords();
    }
}