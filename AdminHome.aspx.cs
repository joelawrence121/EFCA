using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home_Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bindData();
    }

    private void bindData()
    {
        //Security method to authenticate that the user is a verfied instructor.
        //Done before any data is loaded to ensure security.
        try
        {
            Instructor Instructor1 = (Instructor)Session["Instructor"];
            if (Instructor1.Verify() == false)
            {
                Response.Redirect("Login.aspx"); //If verfification fails, redirect to login.
            }

            string FullName = Instructor1.getfirstname() + " " + Instructor1.getlastname();
            lblFirstName.Text = FullName;
            lblLastName.Text = Instructor1.getID().ToString(); //display the instructors name in the top right.
        }
        catch
        {
            Response.Redirect("Login.aspx"); //if anything fails, errors thrown, by default redirect to login page.
        }
        

        
    }
    protected void btnLogOut_Click(object sender, EventArgs e)
    {
        Response.Redirect("LogIn.aspx");
    }
    protected void btnTimetable_Click(object sender, EventArgs e)
    {
        Response.Redirect("Timetable.aspx");
    }
    protected void btnMembers_Click(object sender, EventArgs e)
    {
        Response.Redirect("Members.aspx");
    }
    protected void btnClasses_Click(object sender, EventArgs e)
    {
        Response.Redirect("Classes.aspx");
    }
    protected void btnInstructors_Click(object sender, EventArgs e)
    {
        Response.Redirect("Instructors.aspx");
    }
    protected void btnProducts_Click(object sender, EventArgs e)
    {
        Response.Redirect("Products.aspx");
    }
    protected void btnClubStats_Click(object sender, EventArgs e)
    {
        Response.Redirect("ClubStats.aspx");
    }
    protected void lbtnChangeDetails_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditAdmin.aspx");
    }
    protected void btnTransactions_Click(object sender, EventArgs e)
    {
        Response.Redirect("Transactions.aspx");
    }
}