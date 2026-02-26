using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

//[assembly: AssemblyTitle("My Assembly")]
//[assembly: AssemblyVersion("1.0.0.0")]

//assembly attributes are predefined by the .NET framework and are used to provide metadata about the assembly. they are defined in the System.Reflection namespace and can be applied to an assembly using the [assembly: ] syntax.

//we cannot define our own custom assembly attributes, but we can use the predefined ones to provide information about our assembly, such as its title, version, company, etc. these attributes are stored in the assembly's metadata and can be accessed at runtime using reflection.

class assemblyProgram
{

    static void Main()
    {
        Assembly asm = Assembly.GetExecutingAssembly();

        Console.WriteLine($"AssemblyTitle is {asm.GetName().Name}");
        Console.WriteLine($"AssemblyVersion is {asm.GetName().Version}");

    }
}


