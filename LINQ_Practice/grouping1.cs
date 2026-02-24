using System;
using System.Collections.Generic;
using System.Text;

public class Product
{
    public string ProductName { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }

    public Product(string productName, string category,decimal price)
    { ProductName = productName;
        Category = category;
        Price = price;

    }
}

class grouping1
{
    static void Main()
    {
        List<Product> products = new List<Product>
        { new Product("Laptop", "Electronics", 12000),
            new Product("Mobile", "Electronics", 40000),
            new Product("Shampoo", "Personal Care", 300),
            new Product("Soap", "Personal Care", 100),
            new Product("Rice Bag", "Groceries", 2500)};



        var groupingproducts = products.GroupBy(p => p.Category).Select(p => new { Category = p.Key, Tprice = p.Sum(p => p.Price) });

        Console.WriteLine("Total price by category: ");
        foreach(var item in groupingproducts)
        {
            Console.WriteLine($"{item.Category} :{item.Tprice}");
        }
    }
}