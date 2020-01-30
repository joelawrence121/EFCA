using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;



public partial class Home_Classes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bindData(); //load the initial data needed
    }

    private void bindData()
    {
        //verfication that the instructor is logged in 
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

        //loading the data about the classes into the grid view using a query
        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            //replace function removes the time part of the datetime data
            SqlCommand cmd = new SqlCommand("SELECT ClassID, Name AS 'Class Name', MaxAge As 'Maximum Age', MinAge 'Minimum Age' FROM Class", connection);
            SqlDataReader dr = cmd.ExecuteReader();
            gvClasses.DataSource = dr;
            gvClasses.DataBind(); //bind the data into the grid view
            connection.Close();
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminHome.aspx");
    }
    protected void btnAddClass_Click(object sender, EventArgs e)
    {
        //this function tries to insert the data into the db
        InsertData();
    }

    private void InsertData()
    {
        //declaring the two variables needed for DOB upper and lower.
        int AgeLower;
        int AgeUpper;
        bool emptyString = true;
        string ClassName = "";

        try
        {
            ClassName = txtClassName.Text;
            if(ClassName.Length == 0)
            {
                lblErrorMessage.Visible = true; 
            }
            else
            {
                emptyString = false;
            }
        }
        catch
        {

        }

        
        //try catch loop to catch possible errors without crashing
        //errors including class name being nothing or wrong datatype

        if(emptyString == false)
        {
            //try
            //{


                string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    //the fundamental query
                    String insertClass = "INSERT INTO Class (Name, MaxAge, MinAge) VALUES (@Name, @AgeUpper, @AgeLower);";
                    
                    //process of adding the variables to the query
                    using (SqlCommand command = new SqlCommand(insertClass, connection))
                    {
                        //Name is a not null value, must be added.
                        command.Parameters.AddWithValue("@Name", ClassName);

                        //checks if the values are null, as they can be
                        //if they are not null, they are added to the query
                        //otherwise they are replaced with a DB.Null value to specify it's null
                        if (txtUpperDOB.Text != "")
                        {
                            AgeUpper = Convert.ToInt32(txtUpperDOB.Text);
                            command.Parameters.AddWithValue("@AgeUpper", AgeUpper);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@AgeUpper", DBNull.Value);
                        }


                        //same process as above for the lower DOB text field.
                        if (txtLowerDOB.Text != "")
                        {
                            AgeLower = Convert.ToInt32(txtLowerDOB.Text);
                            command.Parameters.AddWithValue("@AgeLower", AgeLower);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@AgeLower", DBNull.Value);
                        }

                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        connection.Close();
                        bindData();
                    }
                }
            //}
            //catch
            //{
                //if an error occurs, a message will be displayed
                //message says that an error has occurred.
                //lblErrorMessage.Visible = true;
            //}
        }
        
    }

    protected void btnDeleteClass_Click(object sender, EventArgs e)
    {
        //this function is used to delete a class from the DB

        GridViewRow row = gvClasses.SelectedRow; //row datatype assigned to row selected
        int ClassID = Convert.ToInt32(row.Cells[1].Text); //the class ID = the first datavalue in the row

        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();

            //in order for the delete to work
            //all fields that have the class as a foreign key must also be deleted
            //therefore it must delete from all the tables that reference classid

            SqlCommand attendancecmd = new SqlCommand("DELETE Attendance FROM Attendance, Lesson, Class WHERE Attendance.LessonID = Lesson.LessonID AND Lesson.ClassID = Class.ClassID AND Class.ClassID = @ClassID;", connection);
            attendancecmd.Parameters.AddWithValue("@ClassID", ClassID);
            attendancecmd.ExecuteNonQuery();

            SqlCommand ordercmd = new SqlCommand("DELETE Orders FROM Orders, Product, Class WHERE Orders.ProductID = Product.ProductID AND Product.ClassID = Class.ClassID AND Class.ClassID = @ClassID;", connection);
            ordercmd.Parameters.AddWithValue("@ClassID", ClassID);
            ordercmd.ExecuteNonQuery();

            SqlCommand lessoncmd = new SqlCommand("DELETE FROM Lesson WHERE ClassID = @ClassID;", connection);
            lessoncmd.Parameters.AddWithValue("@ClassID", ClassID);
            lessoncmd.ExecuteNonQuery();

            SqlCommand productcmd = new SqlCommand("DELETE FROM Product WHERE ClassID = @ClassID;", connection);
            productcmd.Parameters.AddWithValue("@ClassID", ClassID);
            productcmd.ExecuteNonQuery();

            SqlCommand classcmd = new SqlCommand("DELETE FROM Class WHERE ClassID = @ClassID;", connection);
            classcmd.Parameters.AddWithValue("@ClassID", ClassID);
            classcmd.ExecuteNonQuery();

            connection.Close();
        }

        //once deleted, the table should be updated to show 
        bindData();
    }
    protected void btnEditClass_Click(object sender, EventArgs e)
    {

    }
}