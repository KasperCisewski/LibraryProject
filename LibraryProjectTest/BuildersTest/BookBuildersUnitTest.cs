using LibraryProject.Builders;
using LibraryProject.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProjectTest.BuildersTest
{
    [TestClass]
    public class BookBuildersUnitTest
    {

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
    }
}
