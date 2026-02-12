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


