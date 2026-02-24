//. Given a list of orders ( OrderId , CustomerId, Amount ), group orders by CustomerId and
//calculate the total order amount per customer.
    
using System;
using System.Collections.Generic;
using System.Text;

class Orders
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public int Amount { get; set; }
    public Orders(int orderId, int customerId, int amount)
    {
        OrderId = orderId;
        CustomerId = customerId;
        Amount = amount;
    }
}

class groupingquestion4
{
    static void Main()
    {
        List<Orders> orders = new List<Orders>
    {
        new Orders(1, 101, 250),
        new Orders(2, 102, 150),
        new Orders(3, 101, 300),
        new Orders(4, 103, 200),
        new Orders(5, 102, 350)
    };

        var result = orders.GroupBy(o => o.CustomerId).Select(p => new
        {
            Customer = p.Key,
            TotalAmt = p.Sum(q => q.Amount)
        });

        foreach (var item in result)
        {
            Console.WriteLine($"Customer {item.Customer} == Total Amount: {item.TotalAmt}");
        }
    }
    }

