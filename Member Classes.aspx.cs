using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Home_Member_Classes : System.Web.UI.Page
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
        //verfication of user
        try
        {
            User User1 = (User)Session["User"];
            string fullname = User1.getfirstname() + " " + User1.getlastname();
        }
        catch
        {
            Response.Redirect("Login.aspx");
        }

        //query to bind class data to the grid view
        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            //query, using replace in SQL to remove time from datetime column
            SqlCommand cmd = new SqlCommand("SELECT Name AS 'Class Name',MaxAge As 'Maximum Age', MinAge 'Minimum Age' FROM Class", connection);
            SqlDataReader dr = cmd.ExecuteReader();
            gvClasses.DataSource = dr;
            gvClasses.DataBind();
            connection.Close();
        }
    }
}