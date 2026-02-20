using System.Collections.Generic;
using System.IO;
using REV5.Models;
using REV5.Exceptions;  

namespace REV5.Services
{
    public class FileService
    {
        public void SaveToFile(string path, List<Employee> employees)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (var emp in employees)
                {
                    writer.WriteLine(
                        $"{emp.Id},{emp.Name},{emp.Email},{emp.Phone},{emp.Department},{emp.CalculateSalary()}");
                }
            }
        }

        public void ReadFromFile(string path)
        {
            if (!File.Exists(path))
                return;

            using (StreamReader reader = new StreamReader(path))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    System.Console.WriteLine(line);
                }
            }
        }

        //json serialization
        public void SaveToJson(string path, List<Employee> employees)
        {
            string json = System.Text.Json.JsonSerializer.Serialize(employees);
            File.WriteAllText(path, json);
        }

        //json deserialization
        public List<Employee> ReadFromJson(string path)
        {
            if (!File.Exists(path))
                return new List<Employee>();
            string json = File.ReadAllText(path);
            return System.Text.Json.JsonSerializer.Deserialize<List<Employee>>(json);
        }
    }

}