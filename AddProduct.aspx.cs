using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using Microsoft.VisualBasic;
using System.Configuration;

public partial class Home_AddProduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //only bind data if first instance of page load
        if(!Page.IsPostBack)
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


        //instance of new list, for all of the classes. 
        List<string> classlist = new List<string>();

        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand getclasses = new SqlCommand("SELECT Name FROM Class", connection);
            using (var reader = getclasses.ExecuteReader())
            {
                while (reader.Read())
                {
                    //adding each class to the list
                    classlist.Add(reader.GetString(0));
                }
            }
            connection.Close();

        }

        //binding the list to the class drop down list 
        ddlClass.DataSource = classlist;
        ddlClass.DataBind();
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Products.aspx");
    }
    protected void btnAddProduct_Click(object sender, EventArgs e)
    {
        //to catch errors in data entry
        try
        {
            //declaring the variables to their associated text boxes
            string ProductName = txtName.Text;

            //throw an error to be caught if length is 0 
            int Check = 1 / (ProductName.Length);

            double Price = Convert.ToDouble(txtPrice.Text);
            string Size = txtSize.Text;
            string Colour = txtColour.Text;
            string ClassName = ddlClass.SelectedValue.ToString();

            //byte list for the image declared
            Byte[] image = null;
            int ClassID;

            string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cs))
            {
                //using classname to get the classID from the class table.
                String getClass = "SELECT ClassID FROM Class WHERE Name = @Name;";
                using (SqlCommand getClassCommand = new SqlCommand(getClass, connection))
                {
                    connection.Open();
                    getClassCommand.Parameters.AddWithValue("@Name", ClassName);
                    ClassID = (int)getClassCommand.ExecuteScalar();
                }
            }

            //if image is not null, begin assigning image to image variable
            if (FileUpload1.PostedFile.FileName != "")
            {
                //new stream to upload the binary imamge
                Stream stream = FileUpload1.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(stream);
                //convert the inputted file to appropriate bytes for image assignment
                image = br.ReadBytes((Int32)stream.Length);
            }


            //to add the product in
            using (SqlConnection connection = new SqlConnection(cs))
            {
                //fundamental query structure
                String insertProduct = "INSERT INTO Product (Price, Name, Size, Colour, Image, ClassID) VALUES (@Price, @Name, @Size, @Colour, @Image, @ClassID);";


                using (SqlCommand command = new SqlCommand(insertProduct, connection))
                {
                    //adding the non null values
                    command.Parameters.AddWithValue("@Price", Price);
                    command.Parameters.AddWithValue("@Name", ProductName);
                    command.Parameters.AddWithValue("@ClassID", ClassID);

                    //handling the values that can be null, 
                    //if the value is null, the query is assigned the db null value
                    if (Size != "")
                    {
                        command.Parameters.AddWithValue("@Size", Size);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@Size", DBNull.Value);
                    }

                    if (Colour != "")
                    {
                        command.Parameters.AddWithValue("@Colour", Colour);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@Colour", DBNull.Value);
                    }

                    if (image != null)
                    {
                        command.Parameters.AddWithValue("@Image", image);
                    }
                    else
                    {
                        command.Parameters.Add("@Image", DBNull.Value);
                    }


                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    connection.Close();

                    //if query is executed successfully, success label is visible.
                    lblSuccess.Visible = true;
                }


            }
        }
        catch
        {
            //if an error occurs then error message is shown
            lblError.Visible = true;
        }
       
        
    }
    
}