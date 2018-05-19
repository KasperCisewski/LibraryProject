using LibraryProject.Model;
using LibraryProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Builders
{
    class PeopleListWithBorrowedBooksBuilder
    {
        private readonly IPersonRepository _personRepository;
        private readonly IBookRepository _bookRepository;

        public PeopleListWithBorrowedBooksBuilder(IPersonRepository personRepository,IBookRepository bookRepository)
        {
            _personRepository = personRepository;
            _bookRepository = bookRepository;
        }
        
        public string BuildBorrowedBookList()
        {
            var borrowedBookList = new StringBuilder();

            foreach (var person in _personRepository.GetAllPeople().Where(x=>x.BorrowedBooks.Count()>0))
            {
                borrowedBookList.AppendLine($"{person.FirstName} {person.LastName} - {person.BorrowedBooks.Count()}");
            }

            return borrowedBookList.ToString();
        }
    }
}
