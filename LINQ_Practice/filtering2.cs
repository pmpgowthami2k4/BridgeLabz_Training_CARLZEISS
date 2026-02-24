//using static System.Runtime.InteropServices.JavaScript.JSType;

//Date - Based Filtering
//Given a list of Order objects with OrderDate , write a LINQ query to fetch all orders placed in
//the current year using lambda expressions.
    
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

public class Order
{
    public int ID { get; set; }
    public DateTime OrderDate { get; set; }

    public Order(int id, DateTime date)
    {
        ID = id;
        OrderDate = date;
    }

}

class filtering2
{
    static void Main()
    {
        List<Order> Orders = new List<Order>
        {
            new Order(1, new DateTime(2024, 1, 15)),
            new Order(2, new DateTime(2023, 5, 10)),
            new Order(3, new DateTime(2024, 3, 20)),
            new Order(4, new DateTime(DateTime.Now.Year, 6, 5)),
            new Order(5, new DateTime(DateTime.Now.Year, DateTime.Now.Month, 25))

        };

        var currentYrOrders = Orders.Where(o => o.OrderDate.Year == DateTime.Now.Year);

        foreach(var order in currentYrOrders)
        {
            Console.WriteLine($"Order ID: {order.ID}, Order Date: {order.OrderDate.ToShortDateString()}");
        }
    }



}