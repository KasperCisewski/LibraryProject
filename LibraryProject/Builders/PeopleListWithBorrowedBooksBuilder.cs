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
        private readonly IBookRepository _bookRepository;

        public PeopleListWithBorrowedBooksBuilder(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }


        public string BuildBorrowedBookList()
        {
            var borrowedBookList = new StringBuilder();
            var books = _bookRepository.GetAllBooks().Where(x => x.Person != null);



            return borrowedBookList.ToString();
        }
    }
}
