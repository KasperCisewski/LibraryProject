using LibraryProject.Model;
using System.Collections.Generic;

namespace LibraryProject.Services
{
    public interface IPersonValidator
    {
        bool IsPersonInList(string firstName, string lastName, List<Person> ListOfPeople);
    }
}