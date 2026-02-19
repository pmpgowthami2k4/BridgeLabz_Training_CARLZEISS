using System;
using System.Globalization;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("REGEX PRACTICE PROGRAM\n");

        // 1️ MATCHES - Find all numbers in text
        Console.WriteLine("\nFinding numbers:");
        Console.Write("Enter Number: ");
        string text = Console.ReadLine();
        string numberPattern = @"\d+";
        if (Regex.IsMatch(text, numberPattern))
        {
            MatchCollection matches = Regex.Matches(text, numberPattern);
            foreach (Match match in matches)
            {
                Console.WriteLine("Found: " + match.Value);
            }
        }
        else
        {
            Console.WriteLine("No numbers found.");
        }
        //Regex numberRegex = new Regex(@"\d+");

        //Console.WriteLine("Finding Numbers:");
        //MatchCollection matches = numberRegex.Matches(text);

        //foreach (Match match in matches)
        //{
        //    Console.WriteLine("Found: " + match.Value);
        //}

        //REPLACE
        Console.WriteLine("\nReplace Digits:");
        string replaceExample = Regex.Replace(text, @"\d", "*");
        Console.WriteLine(replaceExample);

        //Email Validation
        Console.WriteLine("\nEmail Validation:");
        Console.Write("Enter Email: ");
        string email = Console.ReadLine();

        string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        if (Regex.IsMatch(email, emailPattern))
            Console.WriteLine("Valid Email");
        else
            Console.WriteLine("Invalid Email");

        //Ph.num Validation (10 digits)
        Console.WriteLine("\nPhone Validation:");
        Console.Write("Enter Phone: ");
        string phone = Console.ReadLine();

        string phonePattern = @"^[6-9]\d{9}$";

        if (Regex.IsMatch(phone, phonePattern))
            Console.WriteLine("Valid Phone");
        else
            Console.WriteLine("Invalid Phone");

        // 4️ Password Validation
        Console.WriteLine("\nPassword Validation:");
        Console.Write("Enter Password: ");
        string password = Console.ReadLine();

        string passwordPattern =
            @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*?&]).{8,}$";

        if (Regex.IsMatch(password, passwordPattern))
            Console.WriteLine("Strong Password");
        else
            Console.WriteLine("Weak Password");

    
      
        // split
        Console.WriteLine("\nSplit by Comma:");
        Console.WriteLine("Write a sentence with commas");
        string splitText = Console.ReadLine();
        string[] splits = Regex.Split(splitText, ",");

        foreach (var word in splits)
        {
            Console.WriteLine(word);
        }


        //Match()
        Console.WriteLine("Write a sentece");
        string sentence = Console.ReadLine();
        string matchPattern = @"\w+";
        if(Regex.IsMatch(sentence, matchPattern))
        {
            Console.WriteLine("First word: " + Regex.Match(sentence, matchPattern).Value);
        }
        else
        {
            Console.WriteLine("No match found");
        }

        //Regex matchRegex = new Regex(@"\w+");
        //Match match1 = matchRegex.Match(sentence);

        //if (match1.Success)
        //{
        //    Console.WriteLine("First word: "     + match1.Value);
        //}
    } 
}



