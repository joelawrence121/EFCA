using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Home_MonthlyRecords : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
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

            bindData();
        }
    }

    private void bindData()
    {
        int MemberID = (int)Session["MemberID"];
        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT MemberID, FirstName, LastName, Email, convert(varchar, DOB, 101) AS 'DOB', Monthly FROM Member WHERE MemberID = @MemberID", connection);
            cmd.Parameters.AddWithValue("@MemberID", MemberID);
            SqlDataReader dr = cmd.ExecuteReader();
            gvMember.DataSource = dr;
            gvMember.DataBind();
            connection.Close();
        }

        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT Month, Year, Paid, Amount, FirstName + ' ' + LastName AS 'Recorded By' FROM MonthlyPayment, Instructor WHERE MemberID = @MemberID AND Instructor.InstructorID = MonthlyPayment.InstructorID ORDER BY Year, Month;", connection);
            cmd.Parameters.AddWithValue("@MemberID", MemberID);
            SqlDataReader dr = cmd.ExecuteReader();
            gvRecords.DataSource = dr;
            gvRecords.DataBind();
            connection.Close();
        }

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

        foreach (GridViewRow row in gvRecords.Rows)
        {
            int Month = Convert.ToInt32(row.Cells[0].Text);
            row.Cells[0].Text = Months[Month - 1];
        }

    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Members.aspx");
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        lblSaved.Visible = false;
        lblError.Visible = false;
        int MemberID = (int)Session["MemberID"]; 
        int Year, Paid, Month;
        double Amount;
        Paid = 0;
        Amount = 0;
        Instructor Instructor = (Instructor)Session["Instructor"];
        int InstructorID = Instructor.getID();
        try
        {
            Year = Convert.ToInt32(txtYear.Text);
            Month = (ddlMonths.SelectedIndex + 1);
            if(cbPaid.Checked)
            {
                Paid = 1;
            }
            Amount = Convert.ToDouble(txtAmount.Text);

            string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cs))
            {
                String insertLogin = "INSERT INTO MonthlyPayment (MemberID, Month, Year, Paid, Amount, InstructorID) VALUES (@MemberID, @Month, @Year, @Paid, @Amount, @InstructorID);";
                using (SqlCommand command = new SqlCommand(insertLogin, connection))
                {
                    command.Parameters.AddWithValue("@MemberID", MemberID);
                    command.Parameters.AddWithValue("@Month", Month);
                    command.Parameters.AddWithValue("@Year", Year);
                    command.Parameters.AddWithValue("@Paid", Paid);
                    command.Parameters.AddWithValue("@Amount", Amount);
                    command.Parameters.AddWithValue("@InstructorID", InstructorID);
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            bindData();
            lblSaved.Visible = true;
        }
        catch
        {
            lblError.Visible = true;
        }
    }
}