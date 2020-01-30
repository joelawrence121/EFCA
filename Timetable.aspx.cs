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

public partial class Timetable_Timetable : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //bind all data to the gridviews
            bindData();
            bindClasses();
            bindInstructors();
            bindDays();
        }
    }

    private void bindDays()
    {
        //the drop down list for days contains the days of the week
        List<string> Days = new List<string>();
        Days.Add("Monday");
        Days.Add("Tuesday");
        Days.Add("Wednesday");
        Days.Add("Thursday");
        Days.Add("Friday");
        Days.Add("Saturday");
        Days.Add("Sunday");
        ddlDays.DataSource = Days;
        ddlDays.DataBind();
    }

    private void bindInstructors()
    {
        //list of instructors should be updated each time it is loaded.
        //this is to make sure it has all the current instructors
        //dynamic loading
        List<string> instructorList = new List<string>();

        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand getinstructors = new SqlCommand("SELECT FirstName, LastName FROM Instructor", connection);
            using (var reader = getinstructors.ExecuteReader())
            {
                while (reader.Read())
                {
                    //returns the first and last name into the string
                    instructorList.Add(reader.GetString(0) + " " + reader.GetString(1));
                }
            }
            connection.Close();

        }

        ddlInstructors.DataSource = instructorList;
        ddlInstructors.DataBind();
    }

    private void bindClasses()
    {
        //same as the instructors but with classes
        List<string> classlist = new List<string>();

        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand getclasses = new SqlCommand("SELECT Name FROM Class",connection);
            using (var reader = getclasses.ExecuteReader())
            {
                while (reader.Read())
                {
                    classlist.Add(reader.GetString(0));
                }
            }
            connection.Close();

        }

        ddlClasses.DataSource = classlist;
        ddlClasses.DataBind();

    }

    private void bindData()
    {
        //verification
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

            for(int i = 0; i < 7; i ++)
            {
                //loop through all days (numbered 1 to 7)
                //get the data about lessons for that day from the database
                getDayData(i);
            }      
            
        }
    }

    private void getDayData(int i)
    {
        List<string> days = new List<string>();
        days.Add("Monday");
        days.Add("Tuesday");
        days.Add("Wednesday");
        days.Add("Thursday");
        days.Add("Friday");
        days.Add("Saturday");
        days.Add("Sunday");

        //find grid view associated to that day
        string gridviewname = "gvDay" + (i+1).ToString();
        GridView gv = (GridView)FindControl(gridviewname);

        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT LessonID, Name AS 'Class Name', FirstName AS 'Instructor First Name', LastName AS 'Instructor Last Name', LessonDuration AS 'Lesson Duration (hrs)', LessonTime AS 'Lesson Start', DATEADD(minute, (LessonDuration*60), LessonTime) AS 'Lesson End'FROM Lesson, Class, Instructor WHERE Lesson.ClassID = Class.ClassID AND Lesson.InstructorID = Instructor.InstructorID AND LessonDay = @Day ORDER BY LessonTime ASC;", connection);
            command.Parameters.AddWithValue("@Day", days[i]);
            SqlDataReader dr = command.ExecuteReader();
            gv.DataSource = dr;
            gv.DataBind();
            dr.Close();
            connection.Close();

        }

    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminHome.aspx");
    }


    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnAddLesson_Click(object sender, EventArgs e)
    {
        lblError.Visible = false;
        string classname, instructorname, firstname, lastname, day, time;
        double duration;
        DateTime Time = new DateTime(1, 1, 1, 1, 1, 1);
        duration = 0;
        classname = "";
        firstname = "";
        lastname = "";
        day = "";
        time = "00:00";
        
    
        //try catch to handle data entry errors
        try
        {
            classname = ddlClasses.SelectedValue;
            instructorname = ddlInstructors.SelectedValue;
            string[] array = instructorname.Split(new char[] { ' ' }, 2);
            firstname = array[0];
            lastname = array[1];
            double test = 1 / duration;
            day = ddlDays.SelectedValue;
            Time = Convert.ToDateTime(txtStart.Text);
            duration = Convert.ToDouble(txtDuration.Text);
            insertLesson(classname, firstname, lastname, day, Time, duration);
        }
        catch
        {
            lblError.Visible = true;
        }

        
        bindData();
    }

    private void insertLesson(string ClassName, string FirstName, string LastName, string Day, DateTime Time, double Duration)
    {
        try
        {
            string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cs))
            {
                int ClassID;
                String getClass = "SELECT ClassID FROM Class WHERE Name = @Name;";
                using (SqlCommand getClassCommand = new SqlCommand(getClass, connection))
                {
                    //need to get associated class id from class name
                    connection.Open();
                    getClassCommand.Parameters.AddWithValue("@Name", ClassName);
                    ClassID = (int)getClassCommand.ExecuteScalar();
                }

                int InstructorID;
                String getInstructor = "SELECT InstructorID FROM Instructor WHERE FirstName = @FirstName AND LastName = @LastName;";
                using (SqlCommand getInstructorCommand = new SqlCommand(getInstructor, connection))
                {
                    //need to also get the instructor ID
                    getInstructorCommand.Parameters.AddWithValue("@FirstName", FirstName);
                    getInstructorCommand.Parameters.AddWithValue("@LastName", LastName);
                    InstructorID = (int)getInstructorCommand.ExecuteScalar();

                }

                String insertLesson = "INSERT INTO Lesson (LessonDuration, LessonDay, LessonTime, ClassID, InstructorID) VALUES (@Dur,@Day,@Time,@ClassID,@InstID); ";
                using (SqlCommand command = new SqlCommand(insertLesson, connection))
                {
                    //insert into the database
                    command.Parameters.AddWithValue("@Dur", Duration);
                    command.Parameters.AddWithValue("@Day", Day);
                    command.Parameters.AddWithValue("@Time", Time);
                    command.Parameters.AddWithValue("@ClassID", ClassID);
                    command.Parameters.AddWithValue("@InstID", InstructorID);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
        catch
        {
            lblError.Visible = true;
        }
        
    }
    
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnDelete1_Click(object sender, EventArgs e)
    {
        DeleteLesson(1);
    }

    private void DeleteLesson(int GridViewIndex)
    {
        string gridviewname = "gvDay" + GridViewIndex.ToString();
        GridView gv = (GridView)FindControl(gridviewname);
        GridViewRow row = gv.SelectedRow;
        int LessonID = Convert.ToInt32(row.Cells[1].Text);
        string FirstName = row.Cells[3].Text;
        string LastName = row.Cells[4].Text;
        string ClassName = row.Cells[2].Text;
        int ClassID = getClassID(ClassName);
        int InstructorID = getInstructorID(FirstName, LastName);
        Lesson Lesson1 = new Lesson(LessonID, InstructorID, ClassID);
        Session["Lesson"] = Lesson1;
       
        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            //must delete from attendance first where it is FK
            connection.Open();
            SqlCommand attendancecmd = new SqlCommand("DELETE FROM Attendance WHERE LessonID = @LessonID;", connection);
            attendancecmd.Parameters.AddWithValue("@LessonID", LessonID);
            attendancecmd.ExecuteNonQuery();
            connection.Close();
        }
        using (SqlConnection connection = new SqlConnection(cs))
        {

            connection.Open();
            SqlCommand lessoncmd = new SqlCommand("DELETE FROM Lesson WHERE LessonID = @LessonID;", connection);
            lessoncmd.Parameters.AddWithValue("@LessonID", LessonID);
            lessoncmd.ExecuteNonQuery();
            connection.Close();
        }
        bindData();
    }
    protected void btnDelete2_Click(object sender, EventArgs e)
    {
        DeleteLesson(2);
    }
    protected void btnDelete3_Click(object sender, EventArgs e)
    {
        DeleteLesson(3);
    }
    protected void btnDelete4_Click(object sender, EventArgs e)
    {
        DeleteLesson(4);
    }
    protected void btnDelete5_Click(object sender, EventArgs e)
    {
        DeleteLesson(5);
    }
    protected void btnDelete6_Click(object sender, EventArgs e)
    {
        DeleteLesson(6);
    }
    protected void btnDelete7_Click(object sender, EventArgs e)
    {
        DeleteLesson(7);
    }


    private int getClassID(string ClassName)
    {
        int ClassID;
        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            String getClass = "SELECT ClassID FROM Class WHERE Name = @Name;";
            using (SqlCommand getClassCommand = new SqlCommand(getClass, connection))
            {
                connection.Open();
                getClassCommand.Parameters.AddWithValue("@Name", ClassName);
                ClassID = (int)getClassCommand.ExecuteScalar();
            }
        }
        return ClassID;  
        
    }

    private int getInstructorID(string FirstName, string LastName)
    {
        int InstructorID;

        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            String getInstructor = "SELECT InstructorID FROM Instructor WHERE FirstName = @FirstName AND LastName = @LastName;";
            using (SqlCommand getInstructorCommand = new SqlCommand(getInstructor, connection))
            {
                connection.Open();
                getInstructorCommand.Parameters.AddWithValue("@FirstName", FirstName);
                getInstructorCommand.Parameters.AddWithValue("@LastName", LastName);
                InstructorID = (int)getInstructorCommand.ExecuteScalar();
                connection.Close();
            }
        }

        return InstructorID;
    }

    private void gotoAttendance(int i)
    {
        //get data about lesson
        string gridviewname = "gvDay" + i.ToString();
        GridView gv = (GridView)FindControl(gridviewname);
        GridViewRow row = gv.SelectedRow;
        int LessonID = Convert.ToInt32(row.Cells[1].Text);
        string FirstName = row.Cells[3].Text;
        string LastName = row.Cells[4].Text;
        string ClassName = row.Cells[2].Text;
        int ClassID = getClassID(ClassName);
        int InstructorID = getInstructorID(FirstName, LastName);
        //instantiate object, save in session for attendance
        Lesson Lesson1 = new Lesson(LessonID, InstructorID, ClassID);
        Session["Lesson"] = Lesson1;
        Response.Redirect("Attendance.aspx");
    }

    protected void btnAttendance1_Click(object sender, EventArgs e)
    {
        gotoAttendance(1);
    }

    protected void btnAttendance2_Click(object sender, EventArgs e)
    {
        gotoAttendance(2);
    }
    protected void btnAttendance3_Click(object sender, EventArgs e)
    {
        gotoAttendance(3);
    }
    protected void btnAttendance4_Click(object sender, EventArgs e)
    {
        gotoAttendance(4);
    }
    protected void btnAttendance5_Click(object sender, EventArgs e)
    {
        gotoAttendance(5);
    }
    protected void btnAttendance6_Click(object sender, EventArgs e)
    {
        gotoAttendance(6);
    }
    protected void btnAttendance7_Click(object sender, EventArgs e)
    {
        gotoAttendance(7);
    }
    protected void GridView7_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnRecords1_Click(object sender, EventArgs e)
    {
        //getdata
        GridViewRow row = gvDay1.SelectedRow;
        int LessonID = Convert.ToInt32(row.Cells[1].Text);
        string FirstName = row.Cells[3].Text;
        string LastName = row.Cells[4].Text;
        string ClassName = row.Cells[2].Text;
        int ClassID = getClassID(ClassName);
        int InstructorID = getInstructorID(FirstName, LastName);
        //instantiate object about lesson in question
        Lesson Lesson1 = new Lesson(LessonID, InstructorID, ClassID);
        Session["Lesson"] = Lesson1;
        Response.Redirect("AttendanceRecords.aspx");
    }
    protected void btnRecords2_Click(object sender, EventArgs e)
    {
        GridViewRow row = gvDay2.SelectedRow;
        int LessonID = Convert.ToInt32(row.Cells[1].Text);
        string FirstName = row.Cells[3].Text;
        string LastName = row.Cells[4].Text;
        string ClassName = row.Cells[2].Text;
        int ClassID = getClassID(ClassName);
        int InstructorID = getInstructorID(FirstName, LastName);
        Lesson Lesson1 = new Lesson(LessonID, InstructorID, ClassID);
        Session["Lesson"] = Lesson1;
        Response.Redirect("AttendanceRecords.aspx");
    }
    protected void btnRecords3_Click(object sender, EventArgs e)
    {
        GridViewRow row = gvDay3.SelectedRow;
        int LessonID = Convert.ToInt32(row.Cells[1].Text);
        string FirstName = row.Cells[3].Text;
        string LastName = row.Cells[4].Text;
        string ClassName = row.Cells[2].Text;
        int ClassID = getClassID(ClassName);
        int InstructorID = getInstructorID(FirstName, LastName);
        Lesson Lesson1 = new Lesson(LessonID, InstructorID, ClassID);
        Session["Lesson"] = Lesson1;
        Response.Redirect("AttendanceRecords.aspx");
    }
    protected void btnRecords4_Click(object sender, EventArgs e)
    {
        GridViewRow row = gvDay4.SelectedRow;
        int LessonID = Convert.ToInt32(row.Cells[1].Text);
        string FirstName = row.Cells[3].Text;
        string LastName = row.Cells[4].Text;
        string ClassName = row.Cells[2].Text;
        int ClassID = getClassID(ClassName);
        int InstructorID = getInstructorID(FirstName, LastName);
        Lesson Lesson1 = new Lesson(LessonID, InstructorID, ClassID);
        Session["Lesson"] = Lesson1;
        Response.Redirect("AttendanceRecords.aspx");
    }
    protected void btnRecords5_Click(object sender, EventArgs e)
    {
        GridViewRow row = gvDay5.SelectedRow;
        int LessonID = Convert.ToInt32(row.Cells[1].Text);
        string FirstName = row.Cells[3].Text;
        string LastName = row.Cells[4].Text;
        string ClassName = row.Cells[2].Text;
        int ClassID = getClassID(ClassName);
        int InstructorID = getInstructorID(FirstName, LastName);
        Lesson Lesson1 = new Lesson(LessonID, InstructorID, ClassID);
        Session["Lesson"] = Lesson1;
        Response.Redirect("AttendanceRecords.aspx");
    }
    protected void btnRecords6_Click(object sender, EventArgs e)
    {
        GridViewRow row = gvDay6.SelectedRow;
        int LessonID = Convert.ToInt32(row.Cells[1].Text);
        string FirstName = row.Cells[3].Text;
        string LastName = row.Cells[4].Text;
        string ClassName = row.Cells[2].Text;
        int ClassID = getClassID(ClassName);
        int InstructorID = getInstructorID(FirstName, LastName);
        Lesson Lesson1 = new Lesson(LessonID, InstructorID, ClassID);
        Session["Lesson"] = Lesson1;
        Response.Redirect("AttendanceRecords.aspx");
    }
    protected void btnRecords7_Click(object sender, EventArgs e)
    {
        GridViewRow row = gvDay7.SelectedRow;
        int LessonID = Convert.ToInt32(row.Cells[1].Text);
        string FirstName = row.Cells[3].Text;
        string LastName = row.Cells[4].Text;
        string ClassName = row.Cells[2].Text;
        int ClassID = getClassID(ClassName);
        int InstructorID = getInstructorID(FirstName, LastName);
        Lesson Lesson1 = new Lesson(LessonID, InstructorID, ClassID);
        Session["Lesson"] = Lesson1;
        Response.Redirect("AttendanceRecords.aspx");
    }
}