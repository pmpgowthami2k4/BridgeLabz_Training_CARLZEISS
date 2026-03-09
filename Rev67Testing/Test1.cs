using Microsoft.VisualStudio.TestTools.UnitTesting;
using static LibraryServiceImpl;

namespace Testing
{

    [TestClass]
    //public class Test1
    public class Test1
    {
        //method to test addbook
        [TestMethod]
        public void TestAddBook()
        {
            var library = LibraryServiceImpl.Instance;
            var book = new Book(1, "Test Book", "Test Author", "Test Category");
            var addedBook = library.AddBook(book);
            Assert.IsNotNull(addedBook);
            Assert.AreEqual(book.BookId, addedBook.BookId);
        }

        //method to test custom exception
        [TestMethod]
        public void TestRemoveBook_NotFound()
        {
            var library = LibraryServiceImpl.Instance;
            Assert.Throws<BookNotFoundException>(() => library.RemoveBook(999));
        }

        //method to test singleton
        [TestMethod]
        public void TestSingletonInstance()
        {
            var instance1 = LibraryServiceImpl.Instance;

            var instance2 = LibraryServiceImpl.Instance; Assert.AreSame(instance1, instance2);
        }


    }
}
