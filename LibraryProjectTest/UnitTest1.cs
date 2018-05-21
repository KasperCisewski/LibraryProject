using System;
using System.Collections.Generic;
using LibraryProject.Builders;
using LibraryProject.Model;
using LibraryProject.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;

namespace LibraryProjectTest
{
    [TestClass]
    public class UnitTest1
    {
        private Mock<IBookRepository> _bookRepository;
        private Mock<IBookValidator> _bookValidator;
        private Mock<IPersonRepository> _personRepository;
        private Mock<IPersonValidator> _personValidator;
        private LibraryService libraryService;

        public void Init()
        {
            _bookRepository = new Mock<IBookRepository>();
            _bookValidator = new Mock<IBookValidator>();
            _personRepository = new Mock<IPersonRepository>();
            _personValidator = new Mock<IPersonValidator>();
            libraryService = new LibraryService(_bookRepository.Object,_bookValidator.Object,_personRepository.Object,_personValidator.Object);


        }



        [TestMethod]
        public void FirstBookISBNNumberValidatorTest()
        {
            Init();
            BookValidator bookValidator = new BookValidator();
            bool expected = true;
            var actual = bookValidator.IsThirteenDigitsInISBNNumber("1234567891234");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SecondBookISBNNumberValidatorTest()
        {
            Init();
            bool expected = false;
            var actual = _bookValidator.Object.IsThirteenDigitsInISBNNumber("123456789123");
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
            foreach(var item in books.Where(x=>(x.BookName==bookName)))
            {
                item.IdPerson = 1;
            }

            var actual = bookValidator.IsBookNameInAvailableBooks(bookName, books);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FirstIsPersonInPeopleListTest()
        {
            string firstName = "kasper";
            string lastName = "cisewski";
            var expected = true;
            PersonValidator personValidator = new PersonValidator();
            List<Person> peopleList = new List<Person>
            {
                new Person(0, "tomek", "baranski"),
                new Person(1,"Marcin","czapiewski"),
                new Person(2,"kasper","cisewski")
            };
            var actual = personValidator.IsPersonInList(firstName, lastName, peopleList);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SecondIsPersonInPeopleListTest()
        {
            string firstName = "kasper";
            string lastName = "cisewski";
            var expected = false;
            PersonValidator personValidator = new PersonValidator();
            List<Person> peopleList = new List<Person>
            {
                new Person(0, "tomek", "baranski"),
                new Person(1,"Marcin","czapiewski")
            };
            var actual = personValidator.IsPersonInList(firstName, lastName, peopleList);

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void FirstBorrowedBookBuilderTest()
        {
            
            var person = new Person(0, "kasper", "cisewski");
            BorrowedBookListBuilder borrowedBookListBuilder = new BorrowedBookListBuilder();
            var expected = "";
            var actual = borrowedBookListBuilder.BuildBorrowedBookList(person);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SecondBorrwerBookBuilderTest()
        {
            var person = new Person(0, "kasper", "cisewski");
            var book = new Book("znak", "gulczynski", "1234567891234");
            person.BorrowedBooks.Add(book);

            BorrowedBookListBuilder borrowedBookListBuilder = new BorrowedBookListBuilder();
            var expected = "znak - gulczynski - 1234567891234\r\n";
            var actual = borrowedBookListBuilder.BuildBorrowedBookList(person);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void FirstBookInLibrary()
        {
           
        }
    }
}
