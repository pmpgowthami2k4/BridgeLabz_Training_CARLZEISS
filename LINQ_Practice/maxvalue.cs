/*using System.Linq.Expressions;

Finding Maximum Value
Write a LINQ query to nd the highest-priced product from a list of products using lambda
expressions.
*/    

using System;
using System.Collections.Generic;
using System.Text;

public class Product2
{
    public string Name { get; set; }
    public int Price { get; set; }

    public Product2(string name, int price)
    {
        Name = name;
        Price = price;
    }
}

class maxvalue
{
    static void Main()
    {
        List<Product2> products = new List<Product2>
        {
            new Product2("Laptop", 800),
            new Product2("Smartphone", 500),
            new Product2("Tablet", 300),
            new Product2("Headphones", 150)
        };

        var maxPriceProduct = products.MaxBy(x => x.Price);
        Console.WriteLine($"Max price product : {maxPriceProduct.Name} : {maxPriceProduct.Price}");

    }
}