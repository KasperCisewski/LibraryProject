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
    public class PersonValidatorUnitTest
    {
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
    }
}
