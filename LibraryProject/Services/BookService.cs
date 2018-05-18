using LibraryProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Services
{
    class BookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookValidator _bookValidator;

        public BookService(IBookRepository bookRepository,IBookValidator bookValidator)
        {
            _bookRepository = bookRepository;
            _bookValidator = bookValidator;
        }

        public string TakeAndTrySaveBook(Book book)
        {
            if (_bookValidator.IsElevenDigitsInISBNNumber(book.ISBNNumber))
            {
                _bookRepository.AddBook(book);
                return $"You added a book: {book.BookName}";
            }
            return "Is something wrong with ISBN number";
        }

    }
}
