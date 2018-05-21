using LibraryProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Builders
{
    class AvailableBookListBuilder
    {
        private readonly IBookRepository _bookRepository;

        public AvailableBookListBuilder(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public string BuildAvailableBookList()
        {
            var avaiableBookList = new StringBuilder();

            var availableBooks = _bookRepository.GetAllBooks().Where(x => x.IdPerson == null);

            foreach (var book in availableBooks)
            {
                avaiableBookList.AppendLine($"{book.BookName} - {book.AuthorSurname} - {book.ISBNNumber}");
            }
            return avaiableBookList.ToString();
        }
    }
}
