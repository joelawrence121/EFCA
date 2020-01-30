using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Home_MemberProducts : System.Web.UI.Page
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
        }
        catch
        {
            Response.Redirect("Login.aspx");
        }

        //bind data to the products grid view
        //grid view columns are predefined, as to allow display of images
        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand getProducts = new SqlCommand("SELECT ProductID,Product.Name,  Price, Size, Colour, Class.Name AS ClassName, Image FROM Product, Class WHERE Product.ClassID = Class.ClassID;", connection);
            SqlDataReader dr = getProducts.ExecuteReader();
            gvProducts.DataSource = dr;
            gvProducts.DataBind();
            connection.Close();
        }

        //instantiate object to session user
        User Member = (User)Session["User"];

        //query to get current orders for the user
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand getOrders = new SqlCommand("SELECT OrderID, Name, DatePurchase, Quantity, TotalPrice AS 'Payment' FROM Orders, Product WHERE Orders.MemberID = @MemberID AND Orders.ProductID = Product.ProductID;", connection);
            getOrders.Parameters.AddWithValue("@MemberID", Member.getID());
            SqlDataReader dr = getOrders.ExecuteReader();
            gvCurrentOrders.DataSource = dr;
            gvCurrentOrders.DataBind();
        }

        //change select into cancel 
        foreach (GridViewRow row in gvCurrentOrders.Rows)
        {
            LinkButton lb = (LinkButton)row.Cells[0].Controls[0];
            lb.Text = "Cancel Order";
        }

            
        
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("MemberHome.aspx");
    }
    protected void btnOrder_Click(object sender, EventArgs e)
    {
        int ProductID = 0;
        //bind row to selected row
        GridViewRow row = gvProducts.SelectedRow;
        //get product id from the row
        ProductID = Convert.ToInt32(row.Cells[1].Text);
        //instantiate new product object, give it product ID as its property
        Product Product = new Product(ProductID);
        //save product in session
        Session["Product"] = Product;
        Response.Redirect("Order.aspx");
    }
    protected void gvCurrentOrders_SelectedIndexChanged(object sender, EventArgs e)
    {
        //cancel order pressed, order deleted from the database. 
        GridViewRow row = gvCurrentOrders.SelectedRow;
        int OrderID = Convert.ToInt32(row.Cells[1].Text);

        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();

            SqlCommand deleteOrder = new SqlCommand("DELETE FROM Orders WHERE OrderID = @OrderID;", connection);
            deleteOrder.Parameters.AddWithValue("@OrderID", OrderID);
            deleteOrder.ExecuteNonQuery();

            connection.Close();
        }

        bindData();
    }
}