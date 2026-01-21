# LIBRARY MANAGEMENT SYSTEM

# 📚 Library Management System (LMS)

This project is a **console-based Library Management System** built using **C#** to demonstrate **Object-Oriented Programming (OOP)** concepts such as encapsulation, inheritance, abstraction, polymorphism, composition, and aggregation.


---

##  Core Classes and Their Responsibilities

### 1 Book
Represents a book in the library.

**Attributes**
- `BookID` (int): Unique identifier for the book  
- `Title` (string): Name of the book  
- `Author` (string): Author of the book  
- `IsIssued` (bool): Indicates whether the book is currently issued  
- `dueDate` (DateTime?): Internal due date (private)

**Methods**
- `ShowDueDate()` – Displays the due date if the book is issued  
- `ReservationStatus()` – Shows whether the book is available or issued  
- `BookRequest()` – Issues the book if available  
- `RenewInfo()` – Extends the due date  
- `Feedback(string)` – Accepts user feedback  

---

### 2 Account
Represents a user’s library activity and fine details.

**Attributes**
- `NoBorrowedBooks` – Count of borrowed books  
- `NoReservedBooks` – Count of reserved books  
- `NoReturnedBooks` – Count of returned books  
- `NoLostBooks` – Count of lost books  
- `FineAmount` – Total fine amount  

**Methods**
- `BorrowBook()` – Updates borrowed count  
- `ReserveBook()` – Updates reserved count  
- `ReturnBook(bool isLate)` – Handles book return and fine  
- `ReportLostBook()` – Updates lost books and fine  

---

### 3 User (Abstract Class)
Base class for all users of the library.

**Attributes**
- `Id` – User ID  
- `Name` – User name  
- `Account` – Associated account (composition)

**Methods**
- `Verify()` – Verifies the user (overridden in child classes)  
- `CheckAccount()` – Displays account details  
- `GetBookInfo(Book)` – Shows book information  

---

### 4 Student (Inherits User)
Represents a student library member.

**Attributes**
- `RollNumber` – Student roll number  
- `Department` – Student department  

**Rules**
- Can borrow up to **3 books**

**Methods**
- Overrides `Verify()`  
- `BorrowBook()` – Enforces student borrowing limit  

---

### 5 Staff (Inherits User)
Represents a staff library member.

**Attributes**
- `EmployeeId` – Staff employee ID  
- `Department` – Staff department  

**Rules**
- Can borrow up to **5 books**

**Methods**
- Overrides `Verify()`  
- `BorrowBook()` – Enforces staff borrowing limit  

---

### 6 LibraryDatabase
Acts as the storage system for all books.

**Attributes**
- `List<Book> books` – Collection of all library books  

**Methods**
- `AddBook(Book)` – Adds a new book  
- `RemoveBook(int)` – Removes a book  
- `GetBookById(int)` – Searches a book  
- `DisplayAllBooks()` – Displays all books  

---

### 7 Librarian
Handles library operations using the database.

**Attributes**
- `LibraryDatabase database` – Reference to the library database  

**Methods**
- `AddBook(Book)`  
- `RemoveBook(int)`  
- `IssueBook(User, int)`  
- `ReturnBook(User, int, bool)`  

---

### 8 LibraryManagementSystem
The main controller that runs the application.

**Responsibilities**
- Creates objects  
- Connects all components  
- Demonstrates system flow  

---

##  OOP Concepts Used
- Encapsulation  
- Abstraction  
- Inheritance  
- Polymorphism  
- Composition  
- Aggregation  

---


> 📖 Books are stored → 👩‍🎓 Users borrow them → 👩‍🏫 Librarian manages everything → 🧾 Account keeps records.


