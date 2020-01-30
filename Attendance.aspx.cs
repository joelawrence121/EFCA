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

public partial class Home_Attendance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            bindData();
        }                
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

        //get lesson saved in object
        Lesson Lesson = (Lesson)Session["Lesson"];
        //details of lesson displayed
        lblLessonID.Text = Lesson.getLessonID().ToString();
        lblInstructorID.Text = Lesson.getInstructorID().ToString();
        lblClassID.Text = Lesson.getClassID().ToString();

        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            //use composite key to get details
            SqlCommand command = new SqlCommand("SELECT LessonID, Name AS 'Class Name', LessonDay, FirstName AS 'Instructor First Name', LastName AS 'Instructor Last Name', LessonDuration AS 'Lesson Duration (hrs)', LessonTime AS 'Lesson Start' FROM Lesson, Class, Instructor WHERE Lesson.ClassID = Class.ClassID AND Lesson.InstructorID = Instructor.InstructorID AND Lesson.ClassID = @ClassID AND Class.ClassID = @ClassID AND Instructor.InstructorID = @InstructorID AND Lesson.InstructorID = @InstructorID AND Lesson.LessonID = @LessonID;", connection);
            command.Parameters.AddWithValue("@ClassID", Lesson.getClassID());
            command.Parameters.AddWithValue("@InstructorID", Lesson.getInstructorID());
            command.Parameters.AddWithValue("@LessonID", Lesson.getLessonID());

            SqlDataReader dr = command.ExecuteReader();
            gvLesson.DataSource = dr;
            gvLesson.DataBind();
            dr.Close();
        }

        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT MemberID, FirstName + ' ' + LastName AS 'Name', Monthly FROM Member", connection);
            SqlDataReader dr = cmd.ExecuteReader();
            gvMembers.DataSource = dr;
            gvMembers.DataBind();
            connection.Close();
        }


        //save in sessions to be used in other functions
        List<int> MemberIDList = new List<int>();
        Session["MemberIDList"] = MemberIDList;

        DataTable DataTable = new DataTable();
        Session["DataTable"] = DataTable;
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Timetable.aspx");
    }

    private void Search()
    {
        //function to search the member table for a specific name
        string text = txtSearch.Text;
        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT MemberID, FirstName, LastName, Email, DateSignUp FROM Member WHERE FirstName LIKE '%' + @Text + '%' OR LastName LIKE '%' + @Text + '%';", connection);
            cmd.Parameters.AddWithValue("@Text", text);
            SqlDataReader dr = cmd.ExecuteReader();
            gvMembers.DataSource = dr;
            gvMembers.DataBind();
            connection.Close();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Search();
    }
    protected void gvMembers_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMemberHead.Visible = true;
        cbPaid.Visible = true;
        txtAmount.Visible = true;
        lblAmount.Visible = true;
        btnRecord.Visible = true;
        gvRecordMember.DataSource = null;
        gvRecordMember.DataBind();
        RecordAttendance();

    }

    private void RecordAttendance()
    {
        GridViewRow row = gvMembers.SelectedRow;
        int MemberID = Convert.ToInt32(row.Cells[1].Text);
        DataTable DataTable = new DataTable();

        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT FirstName + ' ' + LastName AS 'Name', MemberID AS 'ID', Monthly FROM Member WHERE MemberID = @MemberID;", connection);
            cmd.Parameters.AddWithValue("@MemberID", MemberID);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                DataTable.Load(dr);
            }

            connection.Close();
        }

        gvRecordMember.DataSource = DataTable;
        gvRecordMember.DataBind();

        bool Monthly;
        Monthly = ifMonthly(MemberID);
        

        if(Monthly)
        {
            lblAmount.Visible = false;
            txtAmount.Visible = false;
            cbPaid.Visible = false;
            btnMonthly.Visible = true;
        }
        else
        {
            lblAmount.Visible = true;
            txtAmount.Visible = true;
            cbPaid.Visible = true;
            btnMonthly.Visible = false;
        }
    }

    private void bindAttendance()
    {
        //function to add selected member to the attendance list
        GridViewRow row = gvMembers.SelectedRow;
        int MemberID = Convert.ToInt32(row.Cells[1].Text);
        List<int> MemberIDList = (List<int>)Session["MemberIDList"];
        DataTable DataTable = (DataTable)Session["DataTable"];
        //get session table to add to it
        MemberIDList.Add(MemberID);

        Session["MemberIDList"] = MemberIDList;

        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT MemberID, FirstName + ' ' + LastName AS 'Name', Monthly FROM Member WHERE MemberID = @MemberID;", connection);
            cmd.Parameters.AddWithValue("@MemberID", MemberID);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                DataTable.Load(dr);
            }

            connection.Close();
        }

        Session["DataTable"] = DataTable;
        gvAttendance.DataSource = DataTable;

        gvAttendance.DataBind();

        foreach (GridViewRow row1 in gvAttendance.Rows)
        {
            //change select button to remove 
            LinkButton lb = (LinkButton)row1.Cells[0].Controls[0];
            lb.Text = "Delete";
        }
    }

    

    static public void Merge(int[] IDs, int low, int mid, int high)
    {
        //function to sort the list of member ids in the attendance table
        //temp array to hold data in algorithm
        int[] temp = new int[25];
        int i, midhigh, number, position;

        midhigh = (mid - 1);
        position = low;
        number = (high - low + 1);

        //loop through first half list
        while ((low <= midhigh) && (mid <= high))
        {
            //comparing with mid
            if (IDs[low] <= IDs[mid])
            {
                temp[position++] = IDs[low++];
            }                
            else
            {
                temp[position++] = IDs[mid++];
            }
                
        }

        while (low <= midhigh)
        {
            temp[position++] = IDs[low++];
        }
            

        while (mid <= high)
        {
            temp[position++] = IDs[mid++];
        }
            
        for (i = 0; i < number; i++)
        {
            IDs[high] = temp[high];
            high--;
        }
    }

    static public void MergeSort(int[] IDs, int low, int high)
    {
        int mid = (high + low) / 2;
        //Sort each sublist recursively by re-applying merge sort.
        if (high > low)
        {
            MergeSort(IDs, low, mid);
            MergeSort(IDs, (mid + 1), high);
            //Merge the two sublists back into one sorted list.
            Merge(IDs, low, (mid + 1), high);
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        
    }

    protected void btnSort_Click(object sender, EventArgs e)
    {
        //once clicked, sort should be carried out
        //get the id list from the session
        List<int> MemberIDList = (List<int>)Session["MemberIDList"];
        int max = MemberIDList.Count();
        int[] MemberIDArray = MemberIDList.ToArray();
        //merge sort it
        MergeSort(MemberIDArray, 0, max - 1);

        DataTable Sorted = new DataTable();

        for (int i = 0; i < max; i++)
        {
            string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT MemberID, FirstName + ' ' + LastName AS 'Name', Monthly FROM Member WHERE MemberID = @MemberID;", connection);
                cmd.Parameters.AddWithValue("@MemberID", MemberIDArray[i]);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    Sorted.Load(dr);
                }

                connection.Close();
            }
        }

        //change the datatable to the sorted version
        gvAttendance.DataSource = Sorted;
        gvAttendance.DataBind();

        foreach (GridViewRow row in gvAttendance.Rows)
        {
            //change the select button to remove
            LinkButton lb = (LinkButton)row.Cells[0].Controls[0];
            lb.Text = "Remove";
        }

        //save back into session
        Session["MemberIDArray"] = MemberIDArray;


 
    }
    protected void btnToday_Click(object sender, EventArgs e)
    {
        //automatic button to have the today date put into the boxes
        DateTime today = DateTime.Today;
        txtDate.Text = today.ToString("dd/MM/yyyy");
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //call function to save into the database
        //get the list of memberIDs
        List<int> MemberIDList = (List<int>)Session["MemberIDList"];
        int[] MemberIDArray = MemberIDList.ToArray();
        Session["MemberIDArray"] = MemberIDArray;
        SaveAttendance();
    }

    private void SaveAttendance()
    {
        //try
        //{
            int LessonID, InstructorID;
            Lesson Lesson = (Lesson)Session["Lesson"];
            LessonID = Lesson.getLessonID();
            InstructorID = Lesson.getInstructorID();
            int[] MemberIDArray = (int[])Session["MemberIDArray"];

            bool ValidDate = false;         
            DateTime Date = Convert.ToDateTime("01.01.2000");
            try
            {
                Date = Convert.ToDateTime(txtDate.Text);
                ValidDate = true;
            }
            catch
            {
                lblError.Visible = true;

            }
            
            int max = MemberIDArray.Count();
            if(ValidDate == true)
            {
                for (int i = 0; i < max; i++)
                {
                    string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    using (SqlConnection connection = new SqlConnection(cs))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("INSERT INTO Attendance (MemberID, InstructorID, LessonID, Date) VALUES (@MemberID, @InstructorID, @LessonID, @Date);", connection);
                        cmd.Parameters.AddWithValue("@MemberID", MemberIDArray[i]);
                        cmd.Parameters.AddWithValue("@InstructorID", InstructorID);
                        cmd.Parameters.AddWithValue("@LessonID", LessonID);
                        cmd.Parameters.AddWithValue("@Date", Date);

                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                lblSaved.Visible = true;
            }

            
            
        //}
        //catch
        //{
            //Label20.Visible = true;
        //}
    }
    protected void gvAttendance_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<int> MemberIDList = (List<int>)Session["MemberIDList"];
        int MemberID = Convert.ToInt32(gvAttendance.SelectedRow.Cells[1].Text);
        MemberIDList.Remove(MemberID);
        //remove and save back into the session
        Session["MemberIDList"] = MemberIDList;
        int[] MemberIDArray = MemberIDList.ToArray<int>();

        DataTable DataTableNew = new DataTable();

        int max = MemberIDList.Count();

        for (int i = 0; i < max; i++)
        {
            string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT MemberID, FirstName + ' ' + LastName AS 'Name', Monthly FROM Member WHERE MemberID = @MemberID;", connection);
                cmd.Parameters.AddWithValue("@MemberID", MemberIDArray[i]);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    //get the IDs from the first and last names
                    DataTableNew.Load(dr);
                }

                connection.Close();
            }
        }

        //save into session
        Session["DataTable"] = DataTableNew;
        Session["MemberIDArray"] = MemberIDArray;
        gvAttendance.DataSource = DataTableNew;
        gvAttendance.DataBind();

        foreach (GridViewRow row in gvAttendance.Rows)
        {
            LinkButton lb = (LinkButton)row.Cells[0].Controls[0];
            lb.Text = "Remove";
        }
    }

    protected bool ifMonthly(int MemberID)
    {
        int Monthly;

        string css = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(css))
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT Monthly FROM Member WHERE MemberID = @MemberID;", connection);
            cmd.Parameters.AddWithValue("@MemberID", MemberID);
            Monthly = Convert.ToInt32(cmd.ExecuteScalar());

            connection.Close();
        }

        if (Monthly == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }



    protected void btnRecord_Click(object sender, EventArgs e)
    {

        lblSaved.Visible = false;
        lblError.Visible = false;
        lblDateError.Visible = false;
        try
        {
            //save record into attendance table 
            int LessonID, InstructorID, MemberID;
            
            int Paid;
            double Amount = 0;
            Lesson Lesson = (Lesson)Session["Lesson"];
            LessonID = Lesson.getLessonID();
            InstructorID = Lesson.getInstructorID();
            MemberID = Convert.ToInt32(gvMembers.SelectedRow.Cells[1].Text);
            int[] MemberIDArray = (int[])Session["MemberIDArray"];   

            bool ValidDate = false;
            DateTime Date = Convert.ToDateTime("01.01.2000");

            bool Monthly = ifMonthly(MemberID);

            try
            {
                Date = Convert.ToDateTime(txtDate.Text);
                ValidDate = true;
            }
            catch
            {
                lblDateError.Visible = true;
            }

            if(cbPaid.Checked == true || Monthly)
            {
                Paid = 1; 
            }
            else
            {
                Paid = 0;
            }

            if (Monthly != true)
            {
                Amount = Convert.ToDouble(txtAmount.Text);
            }
            

            if(ValidDate)
            {
                string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Attendance (MemberID, InstructorID, LessonID, Date, Paid, Amount, Monthly) VALUES (@MemberID, @InstructorID, @LessonID, @Date, @Paid, @Amount, @Monthly);", connection);
                    cmd.Parameters.AddWithValue("@MemberID", MemberID);
                    cmd.Parameters.AddWithValue("@InstructorID", InstructorID);
                    cmd.Parameters.AddWithValue("@LessonID", LessonID);
                    cmd.Parameters.AddWithValue("@Date", Date);
                    cmd.Parameters.AddWithValue("@Paid", Paid);
                    if(Monthly)
                    {
                        cmd.Parameters.AddWithValue("@Amount", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Amount", Amount);
                    }
                    cmd.Parameters.AddWithValue("@Monthly", Monthly);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    lblSaved.Visible = true;
                }
            }
            else
            {
                lblDateError.Visible = true;
            }

            //update the saved attendance log on right:
            //       save into session! then display

            string css = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(css))
            {
                connection.Open();
                //use composite key to get details
                SqlCommand command = new SqlCommand("SELECT FirstName + ' ' + LastName AS 'Name', Member.MemberID, Paid, Amount, Member.Monthly FROM Attendance, Member WHERE Member.MemberID = Attendance.MemberID AND LessonID = @LID AND InstructorID = @IID AND Date = @Date;", connection);
                command.Parameters.AddWithValue("@IID", Lesson.getInstructorID());
                command.Parameters.AddWithValue("@LID", Lesson.getLessonID());
                command.Parameters.AddWithValue("@Date", Date);
                SqlDataReader dr = command.ExecuteReader();
                gvAttendance.DataSource = dr;
                gvAttendance.DataBind();
                dr.Close();
            }
            

            
        }
        catch
        {
           lblError.Visible = true;
        }
    }
    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
        Lesson Lesson = (Lesson)Session["Lesson"];
        int LessonID = Lesson.getLessonID();
        int InstructorID = Lesson.getInstructorID();
        DateTime Date = Convert.ToDateTime("01.01.2000");
        try
        {
            Date = Convert.ToDateTime(txtDate.Text);
        }
        catch
        {

        }

        string css = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(css))
        {
            connection.Open();
            //use composite key to get details
            SqlCommand command = new SqlCommand("SELECT FirstName + ' ' + LastName AS 'Name', Member.MemberID, Paid, Amount, Member.Monthly FROM Attendance, Member WHERE Member.MemberID = Attendance.MemberID AND LessonID = @LID AND InstructorID = @IID AND Date = @Date;", connection);
            command.Parameters.AddWithValue("@IID", Lesson.getInstructorID());
            command.Parameters.AddWithValue("@LID", Lesson.getLessonID());
            command.Parameters.AddWithValue("@Date", Date);
            SqlDataReader dr = command.ExecuteReader();
            gvAttendance.DataSource = dr;
            gvAttendance.DataBind();
            dr.Close();
        }
    }
    protected void btnMonthly_Click(object sender, EventArgs e)
    {
        int MemberID;
        MemberID = Convert.ToInt32(gvMembers.SelectedRow.Cells[1].Text);
        Session["MemberID"] = MemberID;
        Response.Redirect("MonthlyRecords.aspx");
    }
}