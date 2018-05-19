using LibraryProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Services
{
    class LibraryService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookValidator _bookValidator;
        private readonly IPersonRepository _personRepository;
        private readonly IPersonValidator _personValidator;

        public LibraryService(IBookRepository bookRepository,IBookValidator bookValidator,IPersonRepository personRepository,IPersonValidator personValidator)
        {
            _bookRepository = bookRepository;
            _bookValidator = bookValidator;
            _personRepository = personRepository;
            _personValidator = personValidator;
        }

        public string TrySaveBook(Book book)
        {
            if (_bookValidator.IsElevenDigitsInISBNNumber(book.ISBNNumber))
            {
                _bookRepository.AddBook(book);
                return $"You added a book: {book.BookName}";
            }
            return "Is something wrong with ISBN number";
        }
        public string TryRemoveBook(string bookName)
        {
            var books = _bookRepository.GetAllBooks().ToList();
            if (_bookValidator.IsBookNameInBooks(bookName,books))
            {
                if (_bookValidator.IsBookInLibrary(bookName, books))
                {
                    _bookRepository.RemoveBook(bookName);
                    return $"{bookName} removed";
                }
                return $"{bookName} is borrowed by someone, it cann`t be removed now";
            }
            return $"{bookName} is not exist in List of books, next time, you should write a good book name";
        }

        public string TryToBorrowBook(string bookName,string firstName,string lastName)
        {
            var allBooksInLibrary = _bookRepository.GetAllBooks().ToList();
            var allPeopleInLibrary = _personRepository.GetAllPeople().ToList();

            if(_bookValidator.IsBookNameInBooks(bookName,allBooksInLibrary))
            {
                var book = allBooksInLibrary.First(x => x.BookName == bookName);
                Person person;
                if (_personValidator.IsPersonInList(firstName,lastName,allPeopleInLibrary)) // taka linia zamiast -  _personRepository.GetAllPeople(_bookRepository.GetAllBooks().ToList()).ToList())
                {                 
                    person = allPeopleInLibrary.First(x => (x.FirstName == firstName && x.LastName == lastName));
                    book.IdPerson = person.PersonID;
                    book.DateLastBorrow = DateTime.Now;
                    person.BorrowedBooks.Add(book);
                    _bookRepository.UpdateBooks(book);
                    _personRepository.UpdatePersonList(person);

                    return $"Add borrow book to user: {firstName} {lastName}";
                }
                person= _personRepository.AddPersonToList(firstName,lastName,allPeopleInLibrary);

                book.IdPerson = person.PersonID;
                book.DateLastBorrow = DateTime.Now;
                person.BorrowedBooks.Add(book);
                _bookRepository.UpdateBooks(book);
                _personRepository.UpdatePersonList(person);
                
                return $"Create new user, and he borrows his first book, congratulation {firstName}!";
            }
            return $"{bookName} is not exist in List of books, next time, you should write a good book name";
        }
    }
}
