using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;

public class Person
{
    private string v;

    public string Name { get; set; }
    public string City { get; set; }

    public Person(string name, string city)
    {
        Name = name;
        City = city;
    }

    public Person(string v)
    {
        this.v = v;
    }

   
    public override string? ToString()
    {
        return ($"Name : {Name}  City : {City} ");
    }
}

class questiontest
{
    static void Main()
    {
        List<Person> persons = new List<Person>
        {
            new Person("Raj","Rajahmundry"),
            new Person("Gowthami", "Delhi"),
            new Person ("Tom", "Hyderabad"),
            new Person ("Ram","Rajahmundry"),
            new Person ("A", "Rajahmundry")
        };

        var result = persons.GroupBy(p => p.City).OrderBy(x => x.Key);

        foreach ( var item in result)
        {
            Console.WriteLine($"City : {item.Key}");
            foreach (var item2 in item.OrderBy( y => y.Name)) Console.WriteLine($"Name :{item2.Name} "); 
        }


    }
}