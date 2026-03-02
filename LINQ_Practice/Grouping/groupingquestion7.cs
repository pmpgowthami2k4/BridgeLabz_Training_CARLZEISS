//Group products by category and nd the most expensive product in each category.

using System;
using System.Collections.Generic;
using System.Linq;

public class Product7
{
    public string Name { get; set; }
    public int Price { get; set; }
    public string Category { get; set; }

    // Constructor
    public Product7(string name, int price, string category)
    {
        Name = name;
        Price = price;
        Category = category;
    }
}

class GroupingQuestion7
{
    static void Main()
    {
        List<Product7> products = new List<Product7>
        {
            new Product7("Laptop", 80000, "Electronics"),
            new Product7("Mobile", 40000, "Electronics"),
            new Product7("Headphones", 5000, "Electronics"),
            new Product7("Shampoo", 300, "Personal Care"),
            new Product7("Soap", 100, "Personal Care"),
            new Product7("Rice", 2500, "Groceries")
        };

        // Group by Category and find most expensive product
        var result = products
                        .GroupBy(p => p.Category)
                        .Select(g => g.OrderByDescending(p => p.Price)
                                      .First());

        Console.WriteLine("Most Expensive Product in Each Category:\n");

        foreach (var product in result)
        {
            Console.WriteLine($"{product.Category} - {product.Name} - Rs.{product.Price}");
        }
    }
}