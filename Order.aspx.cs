using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Home_Order : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //only load data on first page load
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
            User User1 = (User)Session["User"];
            string fullname = User1.getfirstname() + " " + User1.getlastname();
        }
        catch
        {
            Response.Redirect("Login.aspx");
        }

        //get product object from session
        Product Product = (Product)Session["Product"];
        //get the objects ID
        int ProductID = Product.getProductID();

        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(cs))
        {
            //get data about the product and bind it to gridview
            connection.Open();
            SqlCommand getProduct = new SqlCommand("SELECT Product.Name,  Price, Size, Colour, Class.Name AS ClassName, Image FROM Product, Class WHERE Product.ClassID = Class.ClassID AND ProductID = @ProductID;", connection);
            getProduct.Parameters.AddWithValue("@ProductID", ProductID);
            SqlDataReader dr = getProduct.ExecuteReader();
            gvProduct.DataSource = dr;
            gvProduct.DataBind();

            connection.Close();
        }

        //assign the read only textboxes their values from the gridview 
        txtProduct.Text = gvProduct.Rows[0].Cells[0].Text;
        txtPrice.Text = "£" + gvProduct.Rows[0].Cells[1].Text;

        int Quantity = Convert.ToInt32(ddlQuantity.SelectedValue);
        double price = Convert.ToDouble(gvProduct.Rows[0].Cells[1].Text);
        double TotalPrice = Quantity * price;
        txtTotal.Text = "£" + TotalPrice.ToString();


    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("MemberProducts.aspx");
    }
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        ConfirmOrder();
        Response.Redirect("ConfirmOrder.aspx");
    }

    private void ConfirmOrder()
    {
        //function to confirm order
        int Quantity = Convert.ToInt32(ddlQuantity.SelectedValue);
        double price = Convert.ToDouble(gvProduct.Rows[0].Cells[1].Text);

        //get product object from session
        Product Product = (Product)Session["Product"];
        int ProductID = Product.getProductID();

        DateTime today = DateTime.Today;

        Double TotalPrice = Quantity * price;
        txtTotal.Text = "£" + TotalPrice.ToString();

        //instantiate new order class, with appropriate properties
        //associated to the current order
        Order OrderDetails = new Order(ProductID, Quantity, price, TotalPrice, today, gvProduct.Rows[0].Cells[0].Text);
        //save order in session
        Session["Order"] = OrderDetails;
    }
    protected void ddlQuantity_SelectedIndexChanged(object sender, EventArgs e)
    {
        //change the total price when new quantity is selected
        int Quantity = Convert.ToInt32(ddlQuantity.SelectedValue);
        double price = Convert.ToDouble(gvProduct.Rows[0].Cells[1].Text);
        double TotalPrice = Quantity * price;
        txtTotal.Text = "£" + TotalPrice.ToString();
    
    }
}