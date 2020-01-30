using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Product
/// </summary>
public class Product
{
    public int ProductID;

    public Product()
    {
    ProductID = 0;
    }

    public Product(int PID)
    {
        ProductID = PID;
  
    }

    public int getProductID()
    {
        return ProductID;
    }

}