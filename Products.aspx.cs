using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Home_Products : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //load data on first instance of page load
        if(!Page.IsPostBack)
        {
            bindData();
        }
    }

    private void bindData()
    {
        //verification
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

        //bind data to all gridviews
        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            //query to display all products from product table
            SqlCommand getProducts = new SqlCommand("SELECT ProductID,Product.Name,  Price, Size, Colour, Class.Name AS ClassName, Image FROM Product, Class WHERE Product.ClassID = Class.ClassID;", connection);
            SqlDataReader dr = getProducts.ExecuteReader();
            gvProducts.DataSource = dr;
            gvProducts.DataBind();
            //gridview has predefined columns to allow display of images
            connection.Close();
        }

        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            //display the current orders
            SqlCommand getOrders = new SqlCommand("SELECT Member.FirstName, Member.LastName, OrderID, Product.Name, Product.Colour AS 'Colour', Product.Size AS 'Size', LEFT(DatePurchase, 12) AS 'Date', Quantity, TotalPrice AS 'Payment' FROM Member, Orders, Product WHERE Orders.MemberID = Member.MemberID AND Orders.ProductID = Product.ProductID;", connection);
            SqlDataReader dr = getOrders.ExecuteReader();
            gvCurrentOrders.DataSource = dr;
            gvCurrentOrders.DataBind();
            connection.Close();
        }

        foreach (GridViewRow row1 in gvCurrentOrders.Rows)
        {
            //change select button to remove 
            LinkButton lb = (LinkButton)row1.Cells[0].Controls[0];
            lb.Text = "Complete";
        }

        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            //cross table query to find quantities of each product in all orders
            //summarise them and display them in the gridview
            SqlCommand crossTabQuery = new SqlCommand("DECLARE @columns NVARCHAR(MAX), @sql NVARCHAR(MAX); SET @columns = N''; SELECT @columns += N', p.' + QUOTENAME(Name) FROM (SELECT p.Name FROM dbo.Product AS p INNER JOIN dbo.Orders AS o ON p.ProductID = o.ProductID GROUP BY p.Name) AS x; SET @sql = N' SELECT ' + STUFF(@columns, 1, 2, '') + ' FROM ( SELECT p.Name, o.Quantity FROM dbo.Product AS p INNER JOIN dbo.Orders AS o ON p.ProductID = o.ProductID ) AS j PIVOT ( SUM(Quantity) FOR Name IN (' + STUFF(REPLACE(@columns, ', p.[', ',['), 1, 1, '') + ') ) AS p;'; PRINT @sql; EXEC sp_executesql @sql;", connection);
            SqlDataReader dr = crossTabQuery.ExecuteReader();
            gvQuantity.DataSource = dr;
            gvQuantity.DataBind();
            connection.Close();
        }

        bindQueue();

    }

    private void bindQueue()
    {
        //function to create the queue for the orders
        
        //new order queue class is instantiated to orderqueue object
        Queue OrderQueue = new Queue();
        //orderlist created to save original orders
        List<int> OrderList = new List<int>();

        //cs gets the connection string from the web.config 
        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand getIDs = new SqlCommand("SELECT OrderID FROM Orders ORDER BY DatePurchase;", connection);
            SqlDataReader dr = getIDs.ExecuteReader();
            while (dr.Read())
            {
                //add each order to the queue
                //as the query is ordered in dates
                //the first item in the queue is the order made longest ago
                OrderQueue.Enqueue(dr.GetInt32(0));
            }
            connection.Close();
        }

        //method to bind the orderqueue nodes to a list
        OrderList = OrderQueue.GetAllNodes().Select(x => x.OrderID).ToList();
        //assign the gridview datasource as the list created
        gvOrderQueue.DataSource = OrderList;
        gvOrderQueue.DataBind();
        //store both the queue and the IDs in the session
        Session["OrderIDQueue"] = OrderQueue;
        Session["OriginalIDs"] = OrderList;
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminHome.aspx");
    }
    protected void btnAddProduct_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddProduct.aspx");
    }
    protected void btnDeleteProduct_Click(object sender, EventArgs e)
    {
        GridViewRow row = gvProducts.SelectedRow;
        //get the ID that the user wants to delete from the grid view
        int ProductID = Convert.ToInt32(row.Cells[1].Text);

        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            //products need to be deleted from orders and the products table
            //important that it is deleted from orders first as to avoid error
            //as it is the foreign key in the orders table
            SqlCommand ordercmd = new SqlCommand("DELETE FROM Orders WHERE ProductID = @ProductID;", connection);
            ordercmd.Parameters.AddWithValue("@ProductID", ProductID);
            ordercmd.ExecuteNonQuery();

            SqlCommand cmd = new SqlCommand("DELETE FROM Product WHERE ProductID = @ProductID;", connection);
            cmd.Parameters.AddWithValue("@ProductID", ProductID);
            cmd.ExecuteNonQuery();

            connection.Close();
        }
        bindData();
    }
    protected void gvCurrentOrders_SelectedIndexChanged(object sender, EventArgs e)
    {

        GridViewRow row = gvCurrentOrders.SelectedRow;
        //get the order ID that the user wants to delete from the grid view
        int OrderID = Convert.ToInt32(row.Cells[3].Text);

        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            //products need to be deleted from orders and the products table
            //important that it is deleted from orders first as to avoid error
            //as it is the foreign key in the orders table
            SqlCommand ordercmd = new SqlCommand("DELETE FROM Orders WHERE OrderID = @OrderID;", connection);
            ordercmd.Parameters.AddWithValue("@OrderID", OrderID);
            ordercmd.ExecuteNonQuery();

            connection.Close();
        }
        bindData();
    }
    protected void btnComplete_Click(object sender, EventArgs e)
    {
        //function to remove a node from the queue

        //get the orderqueue from the session, so that it is the same
        Queue OrderQueue = (Queue)Session["OrderIDQueue"];
        //calls method to dequeue the item
        OrderQueue.Dequeue();
        List<int> OrderList = new List<int>();
        
        //binds the new queue to the gridview, so the user can see the item removed
        OrderList = OrderQueue.GetAllNodes().Select(x => x.OrderID).ToList();
        gvOrderQueue.DataSource = OrderList;
        gvOrderQueue.DataBind();

        //save the order queue back to the session, to the same session name
        //as to override the old, outdated queue
        Session["OrderIDQueue"] = OrderQueue;

    }
    protected void btnSaveOrders_Click(object sender, EventArgs e)
    {
        //function to save the new queue, with fewer items, to the db

        //three lists needed to complete tasks
        List<int> IDsToDelete = new List<int>();
        List<int> OriginalIDs = (List<int>)Session["OriginalIDs"];
        List<int> NewIDs = new List<int>();
        Queue OrderQueue = (Queue)Session["OrderIDQueue"];
        NewIDs = OrderQueue.GetAllNodes().Select(x => x.OrderID).ToList();

        foreach(int id in OriginalIDs)
        {
            //if the new ids is not in the original ids, it means it is to be deleted
            if(NewIDs.Contains(id) == false)
            {
                IDsToDelete.Add(id);
            }
        }

        //delete the ids

        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        foreach(int OrderID in IDsToDelete)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                //loop to delete all the ids that need to be deleted.
                SqlCommand ordercmd = new SqlCommand("DELETE FROM Orders WHERE OrderID = @OrderID;", connection);
                ordercmd.Parameters.AddWithValue("@OrderID", OrderID);
                ordercmd.ExecuteNonQuery();
            }
        }
        //once orders are deleted, bind the data again from the database
        //as to show the updated version to the user
        bindData();
    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gvOrderQueue_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}