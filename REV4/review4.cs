////Problem Statement: Address Book Application

////ContactPerson Fields:

////Id

////Name

////Email

////Phone Number

////Address

////Constraints:

////The Email must be unique within the application.

////The Id should be auto-generated.

////Application Requirements

////Create a C# console-based Address Book application with the following requirements:

////Create a data structure to store contacts where:

////The key is the first character of the contact’s first name.

////The value is a list of contacts.

////Dictionary<char, List<ContactPerson>>


////Add contacts to the dictionary such that each contact is inserted based on the first letter of their first name.

////Display contacts according to the character entered by the user.

using System;
using System.Collections.Generic;
namespace AddressBook
{
    public class Person
    {
        public virtual void Display()
        {
            Console.WriteLine("Person Details: ");
        }
    }
    
    //inhertance
    public class CntctPerson: Person
    {
        public static int counter=1;
        public int Id{get;private set;}
        public string Name{get;set;}
        public string Email{get;set;}
        public string PhoneNumber{get;set;}
        public string Address{get;set;}
        public CntctPerson(string name, string email, string phone, string address)
        {
            Id= counter++;
            Name= name;
            Email= email;
            PhoneNumber= phone;
            Address= address;
        }

        //polymorphism
        public override void Display()
        {
            
            Console.WriteLine($"Id: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Phone: {PhoneNumber}");
            Console.WriteLine($"Address: {Address}");
        }
        
    }

    //abs
    public interface Imanager
    {
        void AddContact(CntctPerson contact);
        void DisplayByCharacter(char ch);
    }

    public class Manager:Imanager
    {
        private Dictionary<char, SortedList<int, CntctPerson>> contacts= new Dictionary<char, SortedList<int, CntctPerson>>();
        public void AddContact(CntctPerson contact)
        {


            // emil check linrsrch
            foreach (var group in contacts.Values)
            {
                foreach (var existing in group.Values)
                {
                    if (existing.Email == contact.Email)
                    {
                        Console.WriteLine("Email exists");
                        return;
                    }
                }
            }
            //lin srch

            //SL
            char key= contact.Name[0];
            if (!contacts.ContainsKey(key))
            {
                contacts[key]= new SortedList<int, CntctPerson>();
            }
            contacts[key].Add(contact.Id, contact);
            Console.WriteLine("Contact Added. "); //return the user itself
        }
        public void DisplayByCharacter(char ch)
        {
            //ch = char.ToUpper(ch);
            if (contacts.ContainsKey(ch))
            {
                foreach (var contact in contacts[ch].Values)
                {
                    contact.Display();
                }
            }
            else
            {
                Console.WriteLine("not found");
            }
        }
    }

    


    class review4
    {
        static void Main()
        {
            IManager manager = new Manager();
            while (true)
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Display");
                Console.WriteLine("3. exit");
                Console.WriteLine("Enter choce: ");
                int choice = Convert.ToInt32(Console.ReadLine());


                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter Name: ");
                        string name= Console.ReadLine();
                        Console.WriteLine("Enter Email: ");
                        string email= Console.ReadLine();
                        Console.WriteLine("Enter Phone: ");
                        string phone= Console.ReadLine();
                        Console.WriteLine("Enter Address: ");
                        string address= Console.ReadLine();
                        CntctPerson contact= new CntctPerson(name, email, phone, address);
                        manager.AddContact(contact);
                        break;
                    case 2:
                        Console.WriteLine("Enter First Letter: ");
                        char ch= Convert.ToChar(Console.ReadLine());
                        manager.DisplayByCharacter(ch);
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }


            }
        } 
    }

}

