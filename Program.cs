using System;
using System.Globalization;
using System.Collections.Generic;
namespace LibraryManagementSystem
{
    public class Book
    {
        public int BookID { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public bool IsIssued { get; private set; }

        private DateTime? dueDate;

        public Book(int bookID, string title, string author)
        {
            BookID = bookID;
            Title = title;
            Author = author;
            IsIssued = false;
            dueDate = null;
        }

        public void ShowDueDate()
        {
            if (dueDate.HasValue)
            {
                Console.WriteLine($"Due Date: {dueDate.Value.ToShortDateString()}");

            }
            else { Console.WriteLine("This Book is not issued."); }
            
        }


        public void ReservationStatus()
        {
            Console.WriteLine(IsIssued ? "This books is currently issued" : "This book is available");
        }

        public void BookRequest()
        {
            if (!IsIssued)
            {
                IsIssued = true;
                dueDate = DateTime.Now.AddDays(14);
                Console.WriteLine("Book issued sucessfully");
            }
            else
            {
                Console.WriteLine("Book is already issued");

            }


        }

        public void RenewInfo()
        {
            if (IsIssued && dueDate.HasValue)
            {
                dueDate = dueDate.Value.AddDays(7);
                Console.WriteLine("Book renewd for 7 more days");
            }
            else
            {
                Console.WriteLine("Book is not issued, cannot renew");
            }

        }

        public void Feedback(string feedback)
        {
            Console.WriteLine($"Feedback received: {feedback}");
        }
    }

        public class Account
        {
            public int NoBorowedBooks { get; private set; }
            public int NoReservedBooks { get; private set; }
            public int NoReturnedBooks { get; private set; }
            public int NoLostBooks { get; private set; }
            public double FineAmount { get; private set; }

            public Account()
            {
                NoBorowedBooks = 0;
                NoReservedBooks = 0;    
                NoReturnedBooks = 0;
                NoLostBooks = 0;    
                FineAmount = 0;

            }

            public void BorrowBook()
            {
                NoBorowedBooks++;
            }

            public void ReservedBook()
            {
                NoReservedBooks++;
            }
            public void ReturnBook(bool isLate)
            {
                NoReturnedBooks++;
                if (isLate)
                {
                    FineAmount += CalculateFine();
                }
            }
            public void ReportLostBook()
            {
                NoLostBooks++;
                FineAmount += 500; 
            }

            private double CalculateFine()
            {
                return 20;
            }

        }

    abstract class User
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        protected Account Account;
        protected User(int id, string name)
        {
            Id = id;
            Name = name;
            Account = new Account();
        }

        public virtual void Verify()
        {
            Console.WriteLine($"{Name} verfied ");
        }

        public void CheckAccount()
        {
            Console.WriteLine($"Borrowed Books: {Account.NoBorowedBooks}");
            Console.WriteLine($"Reserved Books: {Account.NoReservedBooks}");
            Console.WriteLine($"Returned Books: {Account.NoReturnedBooks}");
            Console.WriteLine($"Lost Books: {Account.NoLostBooks}");
            Console.WriteLine($"Fine: {Account.FineAmount}");
        }
        public void BorrowBook()
        {
            Account.BorrowBook();
        }

        public void ReturnBook(bool isLate)
        {
            Account.ReturnBook(isLate);
        }

        public void GetBookInfo(Book book)
        {
            Console.WriteLine($"Book: {book.Title} by {book.Author}");
            book.ReservationStatus();

        }
    }

    class Student : User
    {
        public string RollNumber { get; private set; }
        public string Department { get; private set; }

        private const int MaxBorrowLimit = 3;

        public Student(int id, string name, string rollNumber, string department)
            : base(id, name)
        {
            RollNumber = rollNumber;
            Department = department;
        }

        public override void Verify()
        {
            Console.WriteLine($"Student {Name} ({RollNumber}) verified.");
        }

        public void BorrowBook()
        {
            if (Account.NoBorowedBooks >= MaxBorrowLimit)
            {
                Console.WriteLine("Borrow limit reached. Cannot borrow more books.");
                return;
            }

            Account.BorrowBook();
            Console.WriteLine("Book borrowed successfully by student.");
        }
    }


    class Staff : User
    {
        public string EmployeeId { get; private set; }
        public string Department { get; private set; }

        private const int MaxBorrowLimit = 5;

        public Staff(int id, string name, string employeeId, string department)
            : base(id, name)
        {
            EmployeeId = employeeId;
            Department = department;
        }

        public override void Verify()
        {
            Console.WriteLine($"Staff member {Name} (ID: {EmployeeId}) verified.");
        }

        public void BorrowBook()
        {
            if (Account.NoBorowedBooks >= MaxBorrowLimit)
            {
                Console.WriteLine("Borrow limit reached. Cannot borrow more books.");
                return;
            }

            Account.BorrowBook();
            Console.WriteLine("Book borrowed successfully by staff.");
        }
    }

    class LibraryDatabase
    {
        private List<Book> books;
        public LibraryDatabase()
        {
            books = new List<Book>();
        }
        public void AddBook(Book book)
        {
            books.Add(book);
            Console.WriteLine($"Book '{book.Title}' added to Library.");
        }
        public void RemoveBook(int bookId)
        {
            Book book = GetBookById(bookId);

            if (book != null)
            {
                books.Remove(book);
                Console.WriteLine($"Book '{book.Title}' removed from library.");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }
        public Book GetBookById(int bookId)
        {
            foreach (Book book in books)
            {
                if (book.BookID == bookId)
                {
                    return book;
                }
            }
            return null;
        }
        public void DisplayAllBooks()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("No books available in library.");
                return;
            }

            Console.WriteLine("Library Books:");
            foreach (Book book in books)
            {
                Console.WriteLine(
                    $"ID: {book.BookID}, Title: {book.Title}, Author: {book.Author}, Issued: {book.IsIssued}"
                );
            }
        }


    }

    class Librarian
    {
        private LibraryDatabase database;

        public Librarian(LibraryDatabase database)
        {
            this.database = database;
        }

        public void AddBook(Book book)
        {
            database.AddBook(book);
        }

        public void RemoveBook(int bookId)
        {
            database.RemoveBook(bookId);
        }

        public void IssueBook(User user, int bookId)
        {
            Book book = database.GetBookById(bookId);

            if (book == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            if (book.IsIssued)
            {
                Console.WriteLine("Book is already issued.");
                return;
            }

            book.BookRequest();      // Book changes its own state
            user.BorrowBook(); // User account updated
        }

        public void ReturnBook(User user, int bookId, bool isLate)
        {
            Book book = database.GetBookById(bookId);

            if (book == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            if (!book.IsIssued)
            {
                Console.WriteLine("Book was not issued.");
                return;
            }

            user.ReturnBook(isLate);
            Console.WriteLine("Book returned successfully.");
        }
    }


    class LibraryManagementSystem
    {
        public static void Run()
        {
            // Create core objects
            LibraryDatabase database = new LibraryDatabase();
            Librarian librarian = new Librarian(database);

            // Create books
            Book b1 = new Book(1, "Clean Code", "Robert C. Martin");
            Book b2 = new Book(2, "Design Patterns", "GoF");

            librarian.AddBook(b1);
            librarian.AddBook(b2);

            // Display books
            database.DisplayAllBooks();
            Console.WriteLine();

            // Create users
            Student student = new Student(101, "Alice", "CS21", "Computer Science");
            Staff staff = new Staff(201, "Bob", "EMP45", "IT");

            // Verify users (polymorphism)
            User u1 = student;
            User u2 = staff;

            u1.Verify();
            u2.Verify();
            Console.WriteLine();

            // Issue books
            librarian.IssueBook(student, 1);
            librarian.IssueBook(staff, 2);
            Console.WriteLine();

            database.DisplayAllBooks();
            Console.WriteLine();

            // Return book (late)
            librarian.ReturnBook(student, 1, true);
            student.CheckAccount();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            LibraryManagementSystem.Run();
            Console.ReadLine();
        }

    }









}