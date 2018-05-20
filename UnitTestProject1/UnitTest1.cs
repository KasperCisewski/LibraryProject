using System;
using LibraryProject.Builders;
using LibraryProject.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var person = new Person(0, "kasper", "cisewski");
            BorrowedBookListBuilder borrowedBookListBuilder = new BorrowedBookListBuilder();
            var expected = "";
            var actual = borrowedBookListBuilder.BuildBorrowedBookList(person);

            Assert.AreEqual(expected, actual);
        }
   
    }
}
