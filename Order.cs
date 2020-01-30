using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Order
/// </summary>
public class Order
{

    public int ProductID;
    public int Quantity;
    public double Price;
    public double TotalPrice;
    public DateTime Date;
    string ProductName;

    public Order()
    {
        ProductID = 0;
        Quantity = 0;
        Price = 0;
        TotalPrice = 0;
        Date = Convert.ToDateTime("01-01-01");
        ProductName = "";
        
    }

    public Order(int PID, int inQuantity, double inPrice, double inTotal, DateTime date, string ProdName)
    {
        ProductID = PID;
        Quantity = inQuantity;
        Price = inPrice;
        TotalPrice = inTotal;
        Date = date;
        ProductName = ProdName;
    }

    public int getProductID()
    {
        return ProductID;
    }

    public int getQuantity()
    {
        return Quantity;
    }

    public double getTotalPrice()
    {
        return TotalPrice;
    }

    public double getPrice()
    {
        return Price;
    }

    public DateTime getDate()
    {
        return Date;
    }

    public string getName()
    {
        return ProductName;
    }
}