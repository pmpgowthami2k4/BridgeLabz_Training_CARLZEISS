using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Collections.Generic;
using System.Globalization;

class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }    
    public double Salary { get; set; }
}


class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>{

            new Employee { Id= 1, Name = "Alice", Salary = 50000  },
            new Employee { Id= 2, Name = "Rahul", Salary = 60000  },
            new Employee { Id= 1, Name = "Alan", Salary = 80000  }
        };

        string txtPath = "employees.txt";
        string csvPath = "employees.csv";
        string jsonPath = "employees.json";


        //write txt using streamwriter
        using (StreamWriter writer = new StreamWriter(txtPath))
        {
            foreach (var emp in employees)
            {
                writer.WriteLine($"Id: {emp.Id}, Name: {emp.Name}, Salary: {emp.Salary}");
            }
        }



        //read txt using streamreader
        Console.WriteLine("Reading TXT file:");
        using (StreamReader reader = new StreamReader(txtPath))
        {
            string line = reader.ReadLine() ;
            while ((line) != null)
            {
                Console.WriteLine(line);
            }
        }




        //write csv using file class

        List<string> csvLines = new List<string>();
        csvLines.Add("Id,Name,Salary");

        foreach(var emp in employees)
        {
            csvLines.Add($"{emp.Id},{emp.Name},{emp.Salary}");
        }
        File.WriteAllLines(csvPath, csvLines);




        //read csv usng file.readalllines
        Console.WriteLine("Reading csv file");
        string[] csvData = File.ReadAllLines(csvPath);
        foreach(var line in csvData)
        {
            Console.WriteLine(line);
        }

        //json serialization

        string jsonString = JsonSerializer.Serialize(employees);
        File.WriteAllText(jsonPath,jsonString);

        //read json

        Console.WriteLine("Reading json");
        string jsonRead = File.ReadAllText(jsonPath);
        List<Employee> empList = JsonSerializer.Deserialize<List<Employee>>(jsonRead);

        foreach (var emp in empList)
        {
            Console.WriteLine($"{emp.Id} {emp.Name} {emp.Salary}");
        }

        //filestream + bufferedstream
        Console.WriteLine("Writing using filestream and buffered stream");
        using (FileStream fs = new FileStream("buffered.txt", FileMode.Create))
        using (BufferedStream bs = new BufferedStream(fs))
        {
            byte[] data = Encoding.UTF8.GetBytes("This is a test of buffered stream.");
            bs.Write(data, 0, data.Length);
        }

        //memory stream or bytearray
        Console.WriteLine("usign memstream");
        using (MemoryStream ms = new MemoryStream())
        {
            byte[] bytes = Encoding.UTF8.GetBytes("This is a test of memory stream.");
            ms.Write(bytes, 0, bytes.Length);

            ms.Position = 0; // reset position to read from the beginning
            byte[] readBytes = ms.ToArray();

            Console.WriteLine(Encoding.UTF8.GetString(readBytes));
        }
        Console.WriteLine("all ops done");





    }
}
