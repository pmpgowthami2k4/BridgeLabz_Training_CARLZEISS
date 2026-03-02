//Use GroupJoin to group orders by customer and calculate total amount spent per customer

using System;
using System.Collections.Generic;
using System.Linq;

public class Order7
{
    public int CustomerId { get; set; }
    public decimal Amount { get; set; }
    public Order7(int customerId, decimal amount)
    {
        CustomerId = customerId;
        Amount = amount;
    }
}

public class Customer7
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Customer7(int id, string name)
    {
        Id = id;
        Name = name;
    }
}

class joinsquestion7
{
    static void Main()
    {
        List<Order7> orders = new List<Order7>
        {
            new Order7(1, 100),
            new Order7(1, 150),
            new Order7(2, 200),
            new Order7(3, 250)
        };
        List<Customer7> customers = new List<Customer7>
        {
            new Customer7(1, "Alice"),
            new Customer7(2, "Bob"),
            new Customer7(3, "Charlie")
        };
        var result = customers.GroupJoin(orders,
            c => c.Id,
            o => o.CustomerId,
            (c, o) => new { CustomerName = c.Name, TotalAmount = o.Sum(o => o.Amount) });
        foreach (var item in result)
        {
            Console.WriteLine($"Customer: {item.CustomerName}, Total Amount Spent: {item.TotalAmount}");
        }
    }
}