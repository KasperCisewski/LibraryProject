using LibraryProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Services
{
    class PersonValidator : IPersonValidator
    {

        public bool IsPersonInList(string firstName, string lastName,List<Person> peopleList)
        {
            if(peopleList.Any(x=>(x.FirstName==firstName)&&(x.LastName==lastName)))
            {
                return true;
            }
            return false;
        }
    }
}
