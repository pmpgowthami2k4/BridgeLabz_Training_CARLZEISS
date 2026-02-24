//. Write a LINQ query to perform a left join between customers and orders, showing customers even
//if they have no orders.

using System;
using System.Collections.Generic;
using System.Linq;

public class Customer
{
    public int CustomerId { get; set; }
    public string Name { get; set; }
}

public class Orders2
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
}

public class JoinsQuestion2
{
    static void Main()
    {
        List<Customer> customers = new List<Customer>
        {
            new Customer { CustomerId = 1, Name = "Ravi" },
            new Customer { CustomerId = 2, Name = "Priya" },
            new Customer { CustomerId = 3, Name = "Arjun" }
        };

        List<Orders2> orders = new List<Orders2>
        {
            new Orders2 { OrderId = 101, CustomerId = 1 },
            new Orders2 { OrderId = 102, CustomerId = 1 },
            new Orders2 { OrderId = 103, CustomerId = 2 }
        };

        var result = from c in customers
                     join o in orders
                     on c.CustomerId equals o.CustomerId
                     into orderGroup
                     from o in orderGroup.DefaultIfEmpty()
                     select new
                     {
                         CustomerName = c.Name,
                         OrderId = o?.OrderId
                     };

        foreach (var item in result)
        {
            Console.WriteLine($"Customer: {item.CustomerName}, Order: {item.OrderId}");
        }
    }
}
//var result = leftCollection
//.GroupJoin(
//    rightCollection,
//    left => left.Key,
//    right => right.Key,
//    (left, group) => new { left, group }
//)
//.SelectMany(
//    x => x.group.DefaultIfEmpty(),
//    (x, right) => new
//    {
//        x.left.Property,
//        RightProperty = right?.Property
//    //});



//var result = from right in rightCollection
//             join left in leftCollection
//             on right.Key equals left.Key
//             into groupJoin
//             from left in groupJoin.DefaultIfEmpty()
//             select new
//             {
//                 right.Property,
//                 LeftProperty = left?.Property
//             };