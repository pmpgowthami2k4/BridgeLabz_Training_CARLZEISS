using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

//Custom attribute creation

//AttributeUsage configuration

//Positional parameters

//Named parameters

//AllowMultiple

//Inherited attributes

//Class-level attributes

//Method-level attributes

//Parameter-level attributes

//Reflection using Type

//Reflection using MethodInfo

//Runtime metadata retrieval



[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited =true)] //level,multiple,inherit
public class ProjectInfoAttribute : Attribute
{
    public string Name;
    public string Version;

    public ProjectInfoAttribute(string name, string version)
    {
        Name = name;
        Version = version;
    }
    public string Description { get; set; }
}

[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)] 
public class ParamInfoAttribute : Attribute
{
    public string Info;

    public ParamInfoAttribute(string info)
    {
        Info = info;
    }
}



[ProjectInfo("application service", "1.0", Description = "This class represents the application service.")]
class ApplicationService
{
    [ProjectInfo("CalculateBudget method", "1.0", Description = "This method calculates the budget for the project.")]
    public void CalculateBudget()
    {
        Console.WriteLine("Calculating budget...");
    }
    public void Add(
    [ParamInfo("First Number")] int a,
    [ParamInfo("Second Number")] int b)
    {
        Console.WriteLine($"Budget is {a+b}");
    }

}


class customAttributesProgram
{
    static void Main()
    {
        //CLASS LEVEL ATTRIBUTES


        Type type = typeof(ApplicationService);

        
        object[] classAttributes = type.GetCustomAttributes(false);
        //inherit = false → Only attributes declared directly on this type

        //inherit = true → Also include attributes inherited from base classes


        foreach (ProjectInfoAttribute attr in classAttributes)
        {
            Console.WriteLine("Class Info:");
            Console.WriteLine("Name: " + attr.Name );
            Console.WriteLine("Version: " + attr.Version);
            Console.WriteLine("Description: " + attr.Description);
            Console.WriteLine("================");
        }


        //METHOD LEVEL ATTRIBUTES

        MethodInfo methodinfo = type.GetMethod("CalculateBudget");
        object[] methodAttributes = methodinfo.GetCustomAttributes(false);
        foreach (ProjectInfoAttribute attr in methodAttributes)
        {
            
                Console.WriteLine($"\nMethod info: \nName: {attr.Name}, \nVersion: {attr.Version}, \nDescription: {attr.Description}");

            Console.WriteLine("================");



        }
    }
}