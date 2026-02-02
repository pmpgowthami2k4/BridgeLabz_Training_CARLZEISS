//using System.Net.NetworkInformation;
//using System.Reflection;

////6.The "Universal Remote" Interface
////Scenario: Model a Smart Home system where different devices (Light, AC, TV) have different 
////methods for turn_on(). Create a RemoteControl class that can trigger any device without 
////knowing its type. 
////● Concepts: Polymorphism and Abstract Base Classes (ABC). 
////● Input: List of device objects. 
////● Output: Status logs of devices being activated. 
////● Hint: Define an abstract Device class with an @abstractmethod.


using System;
using System.Collections.Generic;

abstract class Device
{
       public abstract void TurnOn();

}

class Light: Device
{
    public override void TurnOn(
)
    {
        Console.WriteLine("Light turned ON");
    }
}


class AC : Device
{
    public override void TurnOn()
    {
        Console.WriteLine("AC turned ON");
   }
}

class TV : Device
{
    public override void TurnOn()
    {
        Console.WriteLine("TV turned ON");
    }
}


class RemoteControl
{
    
    public void ActivateDevices(List<Device> devices)
    {
        foreach (Device device in devices)
        {
            device.TurnOn(); 
        }
    }
}


class Program
{
    static void Main()
    {
      
        List<Device> devices = new List<Device>
        {
            new Light(),
            new AC(),
            new TV()
        };

        RemoteControl remote = new RemoteControl();

        Console.WriteLine("Activating devices...\n");
        remote.ActivateDevices(devices);
    }
}
