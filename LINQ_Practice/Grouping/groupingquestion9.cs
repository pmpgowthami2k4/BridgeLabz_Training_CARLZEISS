//. Group sales records by month and calculate the total sales per month

using System;
using System.Collections.Generic;
using System.Linq;

public class Sale
{
    public DateTime SaleDate { get; set; }
    public decimal Amount { get; set; }

    public Sale(DateTime date, decimal amount)
    {
        SaleDate = date;
        Amount = amount;
    }
}


class groupingquestion9
{
    static void Main()
    {
        List<Sale> sales = new List<Sale>
        {
            new Sale(new DateTime(2025, 1, 10), 1000),
            new Sale(new DateTime(2025, 1, 20), 2000),
            new Sale(new DateTime(2025, 2, 5), 1500),
            new Sale(new DateTime(2025, 2, 25), 2500),
            new Sale(new DateTime(2025, 3, 15), 3000)
        };

        var monthlySales = sales
                            .GroupBy(s => new { s.SaleDate.Year, s.SaleDate.Month })
                            .Select(g => new
                            {
                                Year = g.Key.Year,
                                Month = g.Key.Month,
                                TotalSales = g.Sum(s => s.Amount)
                            })
                            .OrderBy(x => x.Year)
                            .ThenBy(x => x.Month);

        Console.WriteLine("Total Sales Per Month:\n");

        foreach (var item in monthlySales)
        {
            Console.WriteLine($"{item.Month}-{item.Year:D2} :  Rs.{item.TotalSales}");
        }
    }
}