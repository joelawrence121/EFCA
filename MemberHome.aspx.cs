using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



public partial class Home_MemberHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bindData();
    }

    private void bindData()
    {
        //verification
        try
        {
            User User1 = (User)Session["User"];
            string fullname = User1.getfirstname() + " " + User1.getlastname();
            lblMemberName.Text = fullname;

            lblID.Text = User1.getID().ToString();
        }
        catch
        {
            Response.Redirect("Login.aspx");
        }
        
    }
    protected void btnTimetable_Click(object sender, EventArgs e)
    {
        Response.Redirect("MemberTimetable.aspx");
    }
    protected void btnClasses_Click(object sender, EventArgs e)
    {
        Response.Redirect("Member Classes.aspx");
    }
    protected void btnProducts_Click(object sender, EventArgs e)
    {
        Response.Redirect("MemberProducts.aspx");
    }
    protected void lbtnChangeDetails_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditMember.aspx");
    }
    protected void btnClubInfo_Click(object sender, EventArgs e)
    {
        Response.Redirect("ClubInformation.aspx");
    }
    protected void btnLogOut_Click(object sender, EventArgs e)
    {
        Response.Redirect("LogIn.aspx");
    }
}