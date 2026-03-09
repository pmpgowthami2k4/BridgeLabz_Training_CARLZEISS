//📚 *Library Management System – Assignment*

//*Section 1: Basic OOP Concepts *
//1️⃣ Create a class **Book * *with the following properties:

//• `BookId` (int) – Unique identifier
//• `Title` (string) – Book title
//• `Author` (string) – Author name
//• `Category` (string) – Book category
//• `IsAvailable` (bool) – Availability status
//---
//*Section 2: Interface Implementation*

//2️⃣ Create an interface **ILibraryService * *with the following methods:

//AddBook(Book book)
//RemoveBook(int bookId)
//IssueBook(int bookId)
//ReturnBook(int bookId)
//DisplayBooks()

//-- -

//*Section 3: Business Logic*

//3️⃣ Implement **AddBook()** using attributes

//Requirements:
//• BookId must be unique
//• New books should be **available by default** 


//4️⃣ Implement **RemoveBook()** using attributes

//Conditions:
//• Book should exist
//• Issued books **cannot be removed**

//5️⃣ Implement **IssueBook()** 

//Rules:
//• Book must exist
//• Book must be **available**
//• If already issued, show message:
//"Book already issued"

//6️⃣ Implement** ReturnBook()**

//Rules:
//• Book must exist
//• Book must currently be issued

//---

//*Section 4: LINQ Operations*

//Use **LINQ** for the following:

//7️⃣ Display all books * *sorted by Title**

//8️⃣ Display **only available books**

//9️⃣ Display books by **Category**

//🔟 Count how many books are currently **issued**

//---

//*Section 5: Custom Attribute*

//1️⃣1️⃣ Create a **custom attribute `BookCategoryAttribute`**

//Allowed categories:

//• Fiction
//• Science
//• Technology
//• History
//• Biography

//Apply this attribute to the **Category property**.

//---

//*Section 6: Exception Handling*

//1️⃣2️⃣ Create custom exceptions:

//• BookNotFoundException
//• BookAlreadyIssuedException
//• InvalidCategoryException

//Throw exceptions when:

//• Book ID does not exist
//• Book is already issued
//• Invalid category is provided

//---

//*Section 7: Design Pattern*

//1️⃣3️⃣ Implement **Singleton Design Pattern** for `LibraryServiceImpl`.

//Requirement:
//Only** one instance of the library service** should exist.

//---

//*Section 8: Advanced LINQ*

//1️⃣4️⃣ Find the **Top 3 authors who have the most books in the library** using LINQ.
//use regex attribute anywhere 

//===================================================


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

//===========================

//*Section 4: LINQ Operations*

class Program
{
    static void Main(string[] args)
    {
        var libraryService = LibraryServiceImpl.Instance;
        List<Book> books = new List<Book>
        {
            new Book(1, "The Great Gatsby", "F. Scott Fitzgerald", "Fiction"),
            new Book(2, "A Brief History of Time", "Stephen Hawking", "Science"),
            new Book(3, "The Art of Computer Programming", "Donald Knuth", "Technology"),
            new Book(4, "Sapiens: A Brief History of Humankind", "Yuval Noah Harari", "History"),
            new Book(5, "Steve Jobs", "Walter Isaacson", "Biography")
        };

        Console.WriteLine("\nAll Books:");

        //linq to display all books sorted by title
        var sortedBooks = books.OrderBy(b => b.Title).ToList();
        Console.WriteLine("Sorted Books");
        foreach (var book in sortedBooks)
        {
            Console.WriteLine($"ID: {book.BookId}, Title: {book.Title}, Author: {book.Author}, Category: {book.Category}, Available: {book.IsAvailable}");
        }

        //linq to display only available books
        var avlbooks = books.Where(b => b.IsAvailable).ToList();
        Console.WriteLine("Available books");
        foreach (var book in avlbooks)
        {
            Console.WriteLine($"ID: {book.BookId}, Title: {book.Title}, Author: {book.Author}, Category: {book.Category}, Available: {book.IsAvailable}");
        }


        //linq to display books by category
        var categoryBooks = books.GroupBy(b => b.Category).ToList();
        Console.WriteLine("Books by category");
        foreach (var group in categoryBooks)
        {
            Console.WriteLine($"Category: {group.Key}");
            foreach (var book in group)
            {
                Console.WriteLine($"ID: {book.BookId}, Title: {book.Title}, Author: {book.Author}, Available: {book.IsAvailable}");
            }
        }

        //linq to count
        var issuecount = books.Count(b => !b.IsAvailable);
        Console.WriteLine($"Number of books issued: {issuecount}");

        //linq to find top 3 authors 
        var topAuthors = books.GroupBy(b => b.Author)
                              .Select(b => new { Author = b.Key, Count = b.Count() })
                              .OrderByDescending(b => b.Count)
                              .Take(3)
                              .ToList();

    }
}



