//Join Orders, Customers, and Products to display customer name, product name, and
//order amount.

using System;
using System.Collections.Generic;
using System.Linq;

public class Order5
{
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public decimal Amount { get; set; }
    public Order5(int customerId, int productId, decimal amount)
    {
        CustomerId = customerId;
        ProductId = productId;
        Amount = amount;
    }
}
public class Customer5
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Customer5(int id, string name)
    {
        Id = id;
        Name = name;
    }
}

public class Product5
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Product5(int id, string name)
    {
        Id = id;
        Name = name;
    }
}

class joinsquestion5
{
    static void Main()
    {
        List<Order5> orders = new List<Order5>
        {
            new Order5(1, 1, 100),
            new Order5(1, 2, 150),
            new Order5(2, 1, 200),
            new Order5(3, 3, 250)
        };
        List<Customer5> customers = new List<Customer5>
        {
            new Customer5(1, "Alice"),
            new Customer5(2, "Bob"),
            new Customer5(3, "Charlie")
        };
        List<Product5> products = new List<Product5>
        {
            new Product5(1, "Laptop"),
            new Product5(2, "Smartphone"),
            new Product5(3, "Tablet")
        };
       var result = orders.Join(customers,
            o => o.CustomerId,
            c => c.Id,
            (o,c) => new { order = o, customer = c })
            .Join(products,
            oc => oc.order.ProductId,
            p => p.Id,
            (oc,p) => new { customername = oc.customer.Name, productname = p.Name, orderamount = oc.order.Amount });
        
        
        foreach (var item in result)
        {
            Console.WriteLine($"Customer: {item.customername}, Product: {item.productname}, Amount: Rs.{item.orderamount}");
        }
    }
}