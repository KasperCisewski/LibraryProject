using LibraryProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Builders
{
    class NotBorrowedBooksBuilder
    {

        private readonly IBookRepository _bookRepository;

        public NotBorrowedBooksBuilder(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public string BuildNotBorrowedBookList(int numberOfWeeks)
        {
            var notBorrowedBookList = new StringBuilder();

            var books = _bookRepository.GetAllBooks().Where(x => ((DateTime.Now - x.DateLastBorrow).TotalDays / 7) < numberOfWeeks);

            foreach (var item in books)
            {
                notBorrowedBookList.AppendLine($"{item.BookName} - {item.AuthorSurname} - {item.ISBNNumber}");
            }

            return notBorrowedBookList.ToString();
        }
    }
}
