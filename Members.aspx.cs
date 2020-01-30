using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Home_Members : System.Web.UI.Page
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

        //display all data from the member table
        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT MemberID, FirstName, LastName, Email, convert(varchar, DOB, 101) AS 'DOB', Monthly FROM Member", connection);
            SqlDataReader dr = cmd.ExecuteReader();
            gvMembers.DataSource = dr;
            gvMembers.DataBind();
            connection.Close();
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminHome.aspx");
    }
    protected void btnAddMember_Click(object sender, EventArgs e)
    {
        Response.Redirect("SignUp.aspx");
    }
    protected void btnDeleteMember_Click(object sender, EventArgs e)
    {
        GridViewRow row = gvMembers.SelectedRow;
        //get the memberID from the table, the selected row
        int MemberID = Convert.ToInt32(row.Cells[1].Text);

        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            // Member Delete: 
            // Login, Attendance, Orders, Member

            List<string> tables = new List<string>(); 
            tables.Add("MemberLogin");
            tables.Add("Attendance");
            tables.Add("Orders");
            tables.Add("Member");

            for(int i = 0; i < 4; i ++)
            {
                //loop through all the tables and delete the members
                string deletesql = string.Format("DELETE FROM {0} WHERE MemberID = @MemberID;", tables[i]);
                SqlCommand Delete = new SqlCommand(deletesql, connection);
                Delete.Parameters.AddWithValue("@MemberID", MemberID);
                Delete.ExecuteNonQuery();
            }
        }
        bindData();
    }

    private void Search()
    {
        Instructor Instructor = (Instructor)Session["Instructor"];
        int InstructorID = Instructor.getID();
        string text = txtSearch.Text;
        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            //search the table using the search keyword
            string cmd1, cmd2;
            cmd1 = "SELECT MemberID, FirstName, LastName, Email, convert(varchar, DOB, 101) AS 'DOB', Monthly FROM Member WHERE FirstName LIKE '%' + @Text + '%' OR LastName LIKE '%' + @Text + '%';";
            cmd2 = "SELECT MemberID, FirstName, LastName, Email, convert(varchar, DOB, 101) AS 'DOB', Monthly, Address, Mobile, convert(varchar, DateSignUp, 101) AS 'Signed Up' FROM Member WHERE FirstName LIKE '%' + @Text + '%' OR LastName LIKE '%' + @Text + '%';";
            if(InstructorID == 8 || InstructorID == 7)
            {
                SqlCommand cmd = new SqlCommand(cmd2, connection);
                cmd.Parameters.AddWithValue("@Text", text);
                SqlDataReader dr = cmd.ExecuteReader();
                gvMembers.DataSource = dr;
                gvMembers.DataBind();
                connection.Close();
            }
            else
            {
                SqlCommand cmd = new SqlCommand(cmd1, connection);
                cmd.Parameters.AddWithValue("@Text", text);
                SqlDataReader dr = cmd.ExecuteReader();
                gvMembers.DataSource = dr;
                gvMembers.DataBind();
                connection.Close();
            }
            
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Search();
    }
    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        Search();
    }
    protected void btnSeePayments_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = gvMembers.SelectedRow;
            //get the memberID from the table, the selected row
            int MemberID = Convert.ToInt32(row.Cells[1].Text);
            Session["MemberID"] = MemberID;
            if (ifMonthly(MemberID))
            {
                Response.Redirect("MonthlyRecords.aspx");

            }
            else
            {
                Response.Redirect("PaymentHistory.aspx");
            }
        }
        catch
        {

        }
        
    }
    protected void btnAdmin_Click(object sender, EventArgs e)
    {
        lblAdminView.Visible = false;
        btnDeleteMember.Visible = false;
        Instructor Instructor = (Instructor)Session["Instructor"];
        int InstructorID = Instructor.getID();
        if(InstructorID == 7 || InstructorID == 8)
        {
            bindAdminData();
            lblAdminView.Visible = true;
            btnDeleteMember.Visible = true;
        }
    }

    private void bindAdminData()
    {
        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT MemberID, FirstName, LastName, Email, convert(varchar, DOB, 101) AS 'DOB', Monthly, Address, Mobile, convert(varchar, DateSignUp, 101) AS 'Signed Up' FROM Member", connection);
            SqlDataReader dr = cmd.ExecuteReader();
            gvMembers.DataSource = dr;
            gvMembers.DataBind();
            connection.Close();
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
}