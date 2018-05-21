using LibraryProject.Model;
using System.Collections.Generic;

namespace LibraryProject.Services
{
    public interface IBookValidator
    {
        bool Validate(Book book);
        bool HasThirteenDigitsInISBNNumber(string iSBNNumber);
        bool IsBookNameInBooks(string bookName, List<Book> bookList);
        bool IsBookInLibrary(string bookName, List<Book> bookList);
        bool IsBookInPersonBorrowedList(string bookName, List<Book> bookList);
    }
}