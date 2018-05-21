using NUnit.Framework;
using LibraryProject.Services;
using LibraryProject.Model;
using LibraryProject.Builders;

namespace LibraryUnitTestProject
{
    [TestFixture]
    public class UnitTest1
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookValidator _bookValidator;
        private readonly IPersonRepository _personRepository;
        private readonly IPersonValidator _personValidator;

        private LibraryService _libraryService;



        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void TestMethod1()
        {
            var person = new Person(0, "kasper", "cisewski");
            BorrowedBookListBuilder borrowedBookListBuilder = new BorrowedBookListBuilder();
            var expected = "";
            var actual = borrowedBookListBuilder.BuildBorrowedBookList(person);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
