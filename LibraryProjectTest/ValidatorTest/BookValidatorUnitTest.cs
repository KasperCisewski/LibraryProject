using LibraryProject.Model;
using LibraryProject.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProjectTest.ValidatorTest
{
    [TestClass]
    public class BookValidatorUnitTest
    {

        [TestMethod]
        public void FirstBookISBNNumberValidatorTest()
        {
            BookValidator bookValidator = new BookValidator();
            bool expected = true;
            var actual = bookValidator.HasThirteenDigitsInISBNNumber("1234567891234");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SecondBookISBNNumberValidatorTest()
        {
            BookValidator bookValidator = new BookValidator();
            bool expected = false;
            var actual = bookValidator.HasThirteenDigitsInISBNNumber("123456789123");
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void FirstIsBookNameInLibraryTest()
        {
            BookValidator bookValidator = new BookValidator();
            bool expected = true;
            string bookName = "Star book";
            List<Book> books = new List<Book>
            {
                new Book("Book about nothing","Richards","9994443332221"),
                new Book("Star book","galikowski","1234567891111"),
                new Book("Lord of the rings","tolkien","1111222233334")
            };
            var actual = bookValidator.IsBookNameInBooks(bookName, books);
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void SecondIsBookNameInLibraryTest()
        {
            BookValidator bookValidator = new BookValidator();
            bool expected = false;
            string bookName = "Star book";
            List<Book> books = new List<Book>
            {
                new Book("Book about nothing","Richards","9994443332221"),
                new Book("Lord of the rings","tolkien","1111222233334")
            };
            var actual = bookValidator.IsBookNameInBooks(bookName, books);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FirstIsBookInAvailableBooksTest()
        {
            BookValidator bookValidator = new BookValidator();
            bool expected = true;
            string bookName = "Star book";
            List<Book> books = new List<Book>
            {
                new Book("Book about nothing","Richards","9994443332221"),
                new Book("Star book","galikowski","1234567891111"),
                new Book("Lord of the rings","tolkien","1111222233334")
            };

            var actual = bookValidator.IsBookNameInAvailableBooks(bookName, books);
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void SecondIsBookInAvailableBooksTest()
        {

            BookValidator bookValidator = new BookValidator();
            bool expected = false;
            string bookName = "Star book";
            List<Book> books = new List<Book>
            {
                new Book("Book about nothing","Richards","9994443332221"),
                new Book("Star book","galikowski","1234567891111"),
                new Book("Lord of the rings","tolkien","1111222233334")
            };
            books.First(x => (x.BookName == bookName));
            foreach (var item in books.Where(x => (x.BookName == bookName)))
            {
                item.IdPerson = 1;
            }

            var actual = bookValidator.IsBookNameInAvailableBooks(bookName, books);
            Assert.AreEqual(expected, actual);
        }
    }
}
