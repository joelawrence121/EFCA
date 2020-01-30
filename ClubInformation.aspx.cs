using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home_Club_Information : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //prevents unauthorised access, login must be in session to access page
        try
        {
            User User1 = (User)Session["User"];
            string fullname = User1.getfirstname() + " " + User1.getlastname();
        }
        catch
        {
            Response.Redirect("Login.aspx");
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        //redirect back to home
        Response.Redirect("MemberHome.aspx");
    }
}