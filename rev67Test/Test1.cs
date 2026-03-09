using Microsoft.VisualStudio.TestTools.UnitTesting;
using REV6,7;

namespace Testing
{
    [TestClass]
    public class Test1
    {
        [TestMethod]
        public void TestAddBook()
        {
            var library = LibraryServiceImpl.Instance;
            var book1 = new Book(1, "The Great Gatsby", "F. Scott Fitzgerald", "Fiction");

            library.AddBook(book1);

            Assert.IsTrue(library.DisplayBooks().Contains(book1));
        }

        [TestMethod]
        public void TestRemoveBook_NotFound()
        {
            var library = LibraryServiceImpl.Instance;

            Assert.ThrowsException<BookNotFoundException>(() =>
                library.RemoveBook(999));
        }

        [TestMethod]
        public void TestSingletonInstance()
        {
            var instance1 = LibraryServiceImpl.Instance;
            var instance2 = LibraryServiceImpl.Instance;

            Assert.AreSame(instance1, instance2);
        }
    }
}