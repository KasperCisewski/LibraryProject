using System.Collections.Generic;
using LibraryProject.Model;

namespace LibraryProject.Services
{
    public interface IPersonRepository
    {
        Person AddPersonToList(string firstName,string lastName,List<Person> peopleList);
        IEnumerable<Person> GetAllPeople();
        void UpdatePersonList(Person person);
    }
}