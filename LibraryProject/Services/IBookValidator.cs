using LibraryProject.Model;
using System.Collections.Generic;

namespace LibraryProject.Services
{
    interface IBookValidator
    {
        bool Validate(Book book);
        bool IsElevenDigitsInISBNNumber(string iSBNNumber);
        bool IsBookNameInBooks(string bookName, List<Book> bookList);
        bool IsBookInLibrary(string bookName, List<Book> bookList);
        bool IsBookInPersonBorrowedList(string bookName, List<Book> bookList);
    }
}