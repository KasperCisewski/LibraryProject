using System;
using LibraryProject.Builders;
using LibraryProject.Model;
using LibraryProject.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

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
        public void FirstTestBookValidate()
        {
            Init();
            BookValidator bookValidator = new BookValidator();
            bool expected = true;
            var actual = bookValidator.IsThirteenDigitsInISBNNumber("1234567891234");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SecondTestBookValidate()
        {
            Init();
            bool expected = false;
            var actual = _bookValidator.Object.IsThirteenDigitsInISBNNumber("123456789123");
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
        public void SeconBorrwerBookBuilderTest()
        {
            var person = new Person(0, "kasper", "cisewski");
            var book = new Book("znak", "gulczynski", "1234567891234");
            person.BorrowedBooks.Add(book);
            BorrowedBookListBuilder borrowedBookListBuilder = new BorrowedBookListBuilder();
            var expected = "znak - gulczynski - 1234567891234\r\n";
            var actual = borrowedBookListBuilder.BuildBorrowedBookList(person);

            Assert.AreEqual(expected, actual);
        }
    }
}
