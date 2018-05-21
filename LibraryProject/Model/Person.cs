using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Model
{
    public class Person
    {
        
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Book> BorrowedBooks { get; set; }

        public Person(int personID,string firstName,string lastName)
        {
            PersonID = personID;
            FirstName = firstName;
            LastName = lastName;
            BorrowedBooks = new List<Book>();
        }
    }
}
