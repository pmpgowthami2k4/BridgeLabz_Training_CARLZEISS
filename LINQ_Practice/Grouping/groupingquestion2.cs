//. Given a list of Product objects ( Name , Category, Price ), group products by Category
//and calculate the average price for each category.
    
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

public class Product1
{
    public string Name { get; set; }
    public string Category { get; set; }
    public int price { get; set; }
   public Product1(string name, string category, int price)
    {
        Name = name;
        Category = category;
        this.price = price;
    }
}

class groupingquestion2
{
    static void Main()
    {
        List<Product1> products = new List<Product1>
        { new Product1("Laptop", "Electronics", 1000),
          new Product1("Smartphone", "Electronics", 500),
          new Product1("Table", "Furniture", 200),
          new Product1("Chair", "Furniture", 100),
          new Product1("Headphones", "Electronics", 150),
          new Product1("Sofa", "Furniture", 800)

        };

        var results = products.GroupBy(p=> p.Category).Select(g => new { Category = g.Key, AveragePrice = g.Average(p => p.price) });

        Console.WriteLine("Avg price by category: ");
        foreach (var result in results)
        {
            Console.WriteLine($"Category: {result.Category}, Average Price: {result.AveragePrice}");
        }
        }

    }

