using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Home_ConfirmOrder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bindData();
    }

    private void bindData()
    {
        //verification of user.
        try
        {
            User User1 = (User)Session["User"];
            string fullname = User1.getfirstname() + " " + User1.getlastname();
        }
        catch
        {
            Response.Redirect("Login.aspx");
        }

        //retrieving order details from order object stored in session.
        Order OrderDetails = (Order)Session["Order"];

        //assigning label values to order properties
        lblQuantity.Text = OrderDetails.getQuantity().ToString();
        lblProduct.Text = OrderDetails.getName();
        lblTotal.Text = OrderDetails.getTotalPrice().ToString();

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Order.aspx");
    }
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        SaveOrder();
        //once saved, redirected to products where they can see their order
        Response.Redirect("MemberProducts.aspx");
    }

    private void SaveOrder()
    {
        //instantiate object for the order details and the member
        //(as both are needed to make an order entry in the db)
        Order OrderDetails = (Order)Session["Order"];
        User Member = (User)Session["User"];

        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            String insertOrder = "INSERT INTO Orders (DatePurchase, Quantity, TotalPrice, ProductID, MemberID) VALUES (@DatePurchase, @Quantity, @TotalPrice, @ProductID, @MemberID);";
            using (SqlCommand command = new SqlCommand(insertOrder, connection))
            {
                //all details are in the session objects
                command.Parameters.AddWithValue("@DatePurchase", OrderDetails.getDate());
                command.Parameters.AddWithValue("@Quantity", OrderDetails.getQuantity());
                command.Parameters.AddWithValue("@TotalPrice", OrderDetails.getTotalPrice());
                command.Parameters.AddWithValue("@ProductID", OrderDetails.getProductID());
                command.Parameters.AddWithValue("@MemberID", Member.getID());
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        SaveOrder();
        Response.Redirect("MemberProducts.aspx");
    }
}