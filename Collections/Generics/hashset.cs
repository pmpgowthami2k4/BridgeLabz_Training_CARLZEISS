using System;
using System.Collections.Generic;

    class HashSetDemo
    {
        static void Main()
        {
            HashSet<string> countries = new HashSet<string>();

            
            countries.Add("INDIA");
            countries.Add("USA");
            countries.Add("UK");

            // Adding Duplicate will be ignored
            countries.Add("USA");

            Console.WriteLine("After Adding Elements (Duplicates Ignored):");
            foreach (var item in countries)
            {
                Console.WriteLine(item);
            }

            
            Console.WriteLine($"\nTotal Elements: {countries.Count}");


            Console.WriteLine("\nChecking Availability:");
            Console.WriteLine("Contains INDIA? " + countries.Contains("INDIA"));
            Console.WriteLine("Contains NZ? " + countries.Contains("NZ"));

            
            countries.Remove("UK");
            Console.WriteLine("\nAfter Removing UK:");
            foreach (var item in countries)
            {
                Console.WriteLine(item);
            }

           
            int removedCount = countries.RemoveWhere(x => x.Length > 3);
            Console.WriteLine($"\nRemoved {removedCount} elements using RemoveWhere()");
            foreach (var item in countries)
            {
                Console.WriteLine(item);
            }

            
            countries.Clear();
            Console.WriteLine($"\nAfter Clear(), Count: {countries.Count}");

            
            HashSet<string> set1 = new HashSet<string>
            {
                "IND",
                "USA",
                "UK",
                "NZ"
            };

            HashSet<string> set2 = new HashSet<string>
            {
                "IND",
                "USA",
                "SA",
                "SL"
            };

            Console.WriteLine("\nSet1:");
            foreach (var item in set1)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nSet2:");
            foreach (var item in set2)
            {
                Console.WriteLine(item);
            }


            HashSet<string> unionSet = new HashSet<string>(set1);
            unionSet.UnionWith(set2);

            Console.WriteLine("\nAfter UnionWith:");
            foreach (var item in unionSet)
            {
                Console.WriteLine(item);
            }

            HashSet<string> intersectSet = new HashSet<string>(set1);
            intersectSet.IntersectWith(set2);

            Console.WriteLine("\nAfter IntersectWith:");
            foreach (var item in intersectSet)
            {
                Console.WriteLine(item);
            }

            
            HashSet<string> exceptSet = new HashSet<string>(set1);
            exceptSet.ExceptWith(set2);

            Console.WriteLine("\nAfter ExceptWith (Set1 - Set2):");
            foreach (var item in exceptSet)
            {
                Console.WriteLine(item);
            }

            HashSet<string> symmetricSet = new HashSet<string>(set1);
            symmetricSet.SymmetricExceptWith(set2);

           

            Console.ReadKey();
        }
    }



//namespace AddressBookApp
//{
//    // 1️⃣ ABSTRACTION (Interface)

//    public interface IContactManager
//    {
//        void AddContact(ContactPerson contact);
//        void DisplayByCharacter(char ch);
//    }

//    // 2️⃣ INHERITANCE 
//    public class Person
//    
//        public virtual void Display()
//        {
//            Console.WriteLine("Displaying Person Details");
//        }
//    }

//    // 3️⃣ ENCAPSULATION
//    public class ContactPerson : Person
//    {
//        private static int counter = 1;  // For Auto Id

//        public int Id { get; private set; }   // Auto-generated
//        public string Name { get; set; }
//        public string Email { get; set; }
//        public string PhoneNumber { get; set; }
//        public string Address { get; set; }

//        public ContactPerson(string name, string email, string phone, string address)
//        {
//            Id = counter++;
//            Name = name;
//            Email = email;
//            PhoneNumber = phone;
//            Address = address;
//        }

//        // 4️⃣ POLYMORPHISM (Override)
//        public override void Display()
//        {
//            Console.WriteLine("-----------------------------------");
//            Console.WriteLine($"Id      : {Id}");
//            Console.WriteLine($"Name    : {Name}");
//            Console.WriteLine($"Email   : {Email}");
//            Console.WriteLine($"Phone   : {PhoneNumber}");
//            Console.WriteLine($"Address : {Address}");
//        }
//    }



//    public class ContactManager : IContactManager
//    {
//        // Dictionary<char, SortedList<int, ContactPerson>>
//        private Dictionary<char, SortedList<int, ContactPerson>> contacts
//            = new Dictionary<char, SortedList<int, ContactPerson>>();


//        // Add Contact

//        public void AddContact(ContactPerson contact)
//        {
//            // Email uniqueness check (Linear Search)
//            foreach (var group in contacts.Values)
//            {
//                foreach (var existing in group.Values)
//                {
//                    if (existing.Email == contact.Email)
//                    {
//                        Console.WriteLine("Email already exists! Cannot add.");
//                        return;
//                    }
//                }
//            }

//            char key = char.ToUpper(contact.Name[0]);

//            if (!contacts.ContainsKey(key))
//            {
//                contacts[key] = new SortedList<int, ContactPerson>();
//            }

//            contacts[key].Add(contact.Id, contact);

//            Console.WriteLine("Contact Added Successfully!");
//        }


//        // Display by Character

//        public void DisplayByCharacter(char ch)
//        {
//            ch = char.ToUpper(ch);

//            if (contacts.ContainsKey(ch))
//            {
//                foreach (var contact in contacts[ch].Values)
//                {
//                    contact.Display();
//                }
//            }
//            else
//            {
//                Console.WriteLine("No contacts found for this letter.");
//            }
//        }
//    }


//    class Program
//    {
//        static void Main(string[] args)
//        {
//            ContactManager manager = new ContactManager();

//            while (true)
//            {
//                Console.WriteLine("\n===== ADDRESS BOOK MENU =====");
//                Console.WriteLine("1. Add Contact");
//                Console.WriteLine("2. Display By First Letter");
//                Console.WriteLine("3. Exit");

//                Console.Write("Enter Choice: ");
//                int choice = Convert.ToInt32(Console.ReadLine());

//                switch (choice)
//                {
//                    case 1:
//                        Console.Write("Enter Name: ");
//                        string name = Console.ReadLine();

//                        Console.Write("Enter Email: ");
//                        string email = Console.ReadLine();

//                        Console.Write("Enter Phone: ");
//                        string phone = Console.ReadLine();

//                        Console.Write("Enter Address: ");
//                        string address = Console.ReadLine();

//                        ContactPerson contact =
//                            new ContactPerson(name, email, phone, address);

//                        manager.AddContact(contact);
//                        break;

//                    case 2:
//                        Console.Write("Enter First Letter: ");
//                        char ch = Convert.ToChar(Console.ReadLine());

//                        manager.DisplayByCharacter(ch);
//                        break;

//                    case 3:
//                        return;

//                    default:
//                        Console.WriteLine("Invalid Choice");
//                        break;
//                }
//            }
//        }
//    }
//}
