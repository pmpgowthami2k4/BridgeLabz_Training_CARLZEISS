using System;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

//[Serializable]
class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Employee( int id, string name)
    {
        Id = id;
        Name = name;
    }

}

class serializableProgram
{
        static void Main()
    {
        Employee employee = new Employee(1, "John Doe");
        
        FileStream fs = new FileStream("employee.json", FileMode.Create);

        //BinaryFormatter formatter = new BinaryFormatter();

        JsonSerializer.Serialize(fs, employee);
        fs.Close();

        Console.WriteLine("Serialilzed!!");
    }
}