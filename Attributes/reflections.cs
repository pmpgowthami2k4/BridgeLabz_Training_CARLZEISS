using System;
using System.Reflection;
//classinfo, fieldinfo, propertyinfo, methodinfo, parameterinfo

[AttributeUsage(AttributeTargets.All)]
public class InfoAttribute : Attribute
{
    public string Message;
    public InfoAttribute(string message)
    {
        Message = message;
         
    }
}

[Info("Employee Main Class")]
class Employee1
{
    [Info("Employee ID field")]
    public int Id;

    [Info("Employee Name Property")]
    public string Name;

    [Info("Salary Calculation Method")]
    public void CalculateSalary(
        [Info("Base Salary Parameter")] double baseSalary,
        [Info("Bonus Parameter")] double bonus)
    {
        Console.WriteLine("Salary: " + (baseSalary + bonus));
    }
}


class reflectionsProgram
{

    static void Main()
    {
        Type type = typeof(Employee1);

        Console.WriteLine("CLASS INFO");
        foreach (InfoAttribute attr in type.GetCustomAttributes(false))
        {
            Console.WriteLine("Class Attribute: " + attr.Message);
        }

        Console.WriteLine("\nFIELDS");
        FieldInfo[] fields = type.GetFields();
        foreach (FieldInfo field in fields)
        {
            Console.WriteLine("Field: " + field.Name);

            foreach (InfoAttribute attr in field.GetCustomAttributes(false))
            {
                Console.WriteLine("  Attribute: " + attr.Message);
            }
        }

        Console.WriteLine("\nPROPERTIES");
        PropertyInfo[] properties = type.GetProperties();
        foreach (PropertyInfo prop in properties)
        {
            Console.WriteLine("Property: " + prop.Name);

            foreach (InfoAttribute attr in prop.GetCustomAttributes(false))
            {
                Console.WriteLine("  Attribute: " + attr.Message);
            }
        }

        Console.WriteLine("\nMETHOD");
        MethodInfo[] methods = type.GetMethods(
            BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

        foreach (MethodInfo method in methods)
        {
            Console.WriteLine("Method: " + method.Name);

            foreach (InfoAttribute attr in method.GetCustomAttributes(false))
            {
                Console.WriteLine("  Attribute: " + attr.Message);
            }

            Console.WriteLine("  Parameters:");

            ParameterInfo[] parameters = method.GetParameters();
            foreach (ParameterInfo param in parameters)
            {
                Console.WriteLine("    Parameter: " + param.Name +
                                  " | Type: " + param.ParameterType);

                foreach (InfoAttribute attr in param.GetCustomAttributes(false))
                {
                    Console.WriteLine("      Attribute: " + attr.Message);
                }
            }
        }

    }
}
