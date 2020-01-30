using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Home_Instructors : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            bindData();
        }

    }

    private void bindData()
    {
        //verification of instructor
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

        //bind data to grid view
        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT InstructorID, FirstName, LastName, Email, convert(varchar, DOB, 101) AS 'DOB', Mobile FROM Instructor", connection);
            //query to show all details about instructors
            SqlDataReader dr = cmd.ExecuteReader();
            gvInstructors.DataSource = dr;
            //bind query to the grid view
            gvInstructors.DataBind();
            connection.Close();
        }
    }

    protected void btnAddInstructor_Click(object sender, EventArgs e)
    {
        Response.Redirect("InstructorSignUp.aspx");
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminHome.aspx");
    }
    protected void btnDeleteInstructor_Click(object sender, EventArgs e)
    {
        try
        {
            //get the selected instructor
            GridViewRow row = gvInstructors.SelectedRow;
            //get the id from the selected row
            int InstructorID = Convert.ToInt32(row.Cells[1].Text);

            string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                //This list contains the tables that instructor needs to be deleted from
                List<string> tables = new List<string>();
                tables.Add("InstructorLogin");
                tables.Add("Attendance");
                tables.Add("Lesson");
                //important that instructor table is last, as it is the foreign keys in the others
                tables.Add("Instructor");

                for (int i = 0; i < 4; i++)
                {
                    //for loop to loop through each item in the list
                    //deleting instructor from all of them
                    string deletesql = string.Format("DELETE FROM {0} WHERE InstructorID = @InstructorID;", tables[i]);
                    SqlCommand Delete = new SqlCommand(deletesql, connection);
                    Delete.Parameters.AddWithValue("@InstructorID", InstructorID);
                    Delete.ExecuteNonQuery();
                }

                connection.Close();
            }
            bindData();

        }
        catch
        {
            lblError.Visible = true;
        } 
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Search();
    }

    private void Search()
    {
        //search function, filters the instructor list
        Instructor Instructor = (Instructor)Session["Instructor"];
        int InstructorID = Instructor.getID();
        string text = txtSearch.Text;
        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            //search the table using the search keyword
            string cmd1, cmd2;
            cmd1 = "SELECT InstructorID, FirstName, LastName, Email, convert(varchar, DOB, 101) AS 'DOB' FROM Instructor WHERE FirstName LIKE '%' + @Text + '%' OR LastName LIKE '%' + @Text + '%';";
            cmd2 = "SELECT InstructorID, FirstName, LastName, Email, convert(varchar, DOB, 101) AS 'DOB', Address, Mobile, convert(varchar, DateSignUp, 101) AS 'Signed Up' FROM Instructor WHERE FirstName LIKE '%' + @Text + '%' OR LastName LIKE '%' + @Text + '%';";
            if (InstructorID == 8 || InstructorID == 7)
            {
                SqlCommand cmd = new SqlCommand(cmd2, connection);
                cmd.Parameters.AddWithValue("@Text", text);
                SqlDataReader dr = cmd.ExecuteReader();
                gvInstructors.DataSource = dr;
                gvInstructors.DataBind();
                connection.Close();
            }
            else
            {
                SqlCommand cmd = new SqlCommand(cmd1, connection);
                cmd.Parameters.AddWithValue("@Text", text);
                SqlDataReader dr = cmd.ExecuteReader();
                gvInstructors.DataSource = dr;
                gvInstructors.DataBind();
                connection.Close();
            }

        }
    }
    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        //event triggered when the text changes
        Search();
    }
    protected void btnAdmin_Click(object sender, EventArgs e)
    {
        lblAdminView.Visible = false;
        btnDeleteInstructor.Visible = false;
        btnAddInstructor.Visible = false;
        Instructor Instructor = (Instructor)Session["Instructor"];
        int InstructorID = Instructor.getID();
        if (InstructorID == 7 || InstructorID == 8)
        {
            bindAdminData();
            lblAdminView.Visible = true;
            btnDeleteInstructor.Visible = true;
            btnAddInstructor.Visible = true;
        }
    }

    private void bindAdminData()
    {
        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT InstructorID, FirstName, LastName, Email, convert(varchar, DOB, 101) AS 'DOB', Address, Mobile, convert(varchar, DateSignUp, 101) AS 'Signed Up' FROM Instructor", connection);
            SqlDataReader dr = cmd.ExecuteReader();
            gvInstructors.DataSource = dr;
            gvInstructors.DataBind();
            connection.Close();
        }
    }
}