using System.ComponentModel.DataAnnotations;
using static LibraryServiceImpl;
//1️⃣ Create a class **Book * *with the following properties:

//• `BookId` (int) – Unique identifier
//• `Title` (string) – Book title
//• `Author` (string) – Author name
//• `Category` (string) – Book category
//• `IsAvailable` (bool) – Availability status
 public class Book
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }

    [BookCategory("Fiction", "Science", "Technology", "History", "Biography")]
    public string Category { get; set; }
    public bool IsAvailable { get; set; } = true;

    public Book(int bookId, string title, string author, string category)
    {
        BookId = bookId;
        Title = title;
        Author = author;
        Category = category;
    }
}


public class LibraryServiceImpl : ILibraryService
{ //singleton implementation section 7
    private static LibraryServiceImpl instance; //pvt static inst
    private Dictionary<int, Book> books;  //pvt dict to store 
    private LibraryServiceImpl() //pvr ctor
    {
        books = new Dictionary<int, Book>();
    }
    public static LibraryServiceImpl Instance //pub method
    {
        get
        {
            if (instance == null) //single lock //lazy initialization
            {
                instance = new LibraryServiceImpl();
            }
            return instance;
        }
    }
    //*Section 3: Business Logic*
    //public void AddBook(Book book)
    //{
    //    if (books.ContainsKey(book.BookId))
    //    {
    //        Console.WriteLine("Book ID must be unique.");
    //        return;
    //    }
    //    books.Add(book.BookId, book);
    //    Console.WriteLine($"Book '{book.Title}' added successfully.");
    //}

    public Book AddBook(Book book)
    {
        if (books.ContainsKey(book.BookId))
        {
            Console.WriteLine("Book ID must be unique.");
            return null;   //throw exception
        }

        books.Add(book.BookId, book);
        Console.WriteLine($"Book '{book.Title}' added successfully.");

        return book;  // returning  entire object
    }
    public void RemoveBook(int bookId)
    {
        if (!books.ContainsKey(bookId))
        {
            Console.WriteLine("Book not found.");
            return;
        }
        if (!books[bookId].IsAvailable)
        {
            Console.WriteLine("Issued books cannot be removed.");
            return;
        }
        books.Remove(bookId);
        Console.WriteLine($"Book with ID {bookId} removed successfully.");
    }
    public void IssueBook(int bookId)
    {
        if (!books.ContainsKey(bookId))
        {
            Console.WriteLine("Book not found.");
            return;
        }
        if (!books[bookId].IsAvailable)
        {
            Console.WriteLine("Book already issued.");
            return;
        }
        books[bookId].IsAvailable = false;
        Console.WriteLine($"Book with ID {bookId} issued.");
    }
    public void ReturnBook(int bookId)
    {
        if (!books.ContainsKey(bookId))
        {
            Console.WriteLine("Book not found.");
            return;
        }
        if (books[bookId].IsAvailable)
        {
            Console.WriteLine("Book is available.");
            return;
        }
        books[bookId].IsAvailable = true;
        Console.WriteLine($"Book with ID {bookId} returned.");
    }
    public void DisplayBooks()
    {
        var sortedBooks = books.Values.OrderBy(b => b.Title).ToList();
        foreach (var book in sortedBooks)
        {
            Console.WriteLine($"ID: {book.BookId}, Title: {book.Title}, Author: {book.Author}, Category: {book.Category}, Available: {book.IsAvailable}");
        }
    }

    void ILibraryService.AddBook(Book book)
    {
        throw new NotImplementedException();
    }

    //*Section 5: Custom Attribute*

    //Create a **custom attribute `BookCategoryAttribute`**

    //Allowed categories:

    //• Fiction
    //• Science
    //• Technology
    //• History
    //• Biography

    //Apply this attribute to the **Category property**.
    public class BookCategoryAttribute : ValidationAttribute
    {
        private string[] AllowedCategories; /* = { "Fiction", "Science", "Technology", "History", "Biography" };*/
        public BookCategoryAttribute(params string[] AllowedCategories)
        {
            this.AllowedCategories = AllowedCategories;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string category)
            {
                if (AllowedCategories.Contains(category))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult($"Invalid category. Allowed categories are: {string.Join(", ", AllowedCategories)}");
                }
            }
            return new ValidationResult("Category mst be string");
        }
    }

    //*Section 6: Exception Handling*

    //1️⃣2️⃣ Create custom exceptions:

    //• BookNotFoundException
    //• BookAlreadyIssuedException
    //• InvalidCategoryException

    //Throw exceptions when:

    //• Book ID does not exist
    //• Book is already issued
    //• Invalid category is provided

    public class BookNotFoundException : Exception
    {
        public BookNotFoundException(string message) : base(message) { }
    }

    public class BookAlreadyIssuedException : Exception
    {
        public BookAlreadyIssuedException(string message) : base(message) { }
    }

    public class InvalidCategoryException : Exception
    {
        public InvalidCategoryException(string message) : base(message) { }
    }


}