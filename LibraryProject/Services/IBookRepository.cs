using System.Collections.Generic;
using LibraryProject.Model;

namespace LibraryProject.Services
{
    interface IBookRepository
    {
        void AddBook(Book book);
        void BorrowBook(Book book, Person person);
        Book GetBook(string bookData);
        IEnumerable<Book> GetAllBooks();
        void RemoveBook(Book book);
    }
}