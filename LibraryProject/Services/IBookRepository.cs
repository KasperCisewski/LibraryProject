using System.Collections.Generic;
using LibraryProject.Model;

namespace LibraryProject.Services
{
    interface IBookRepository
    {
        void AddBook(Book book);
        void UpdateBooks(Book book);
        Book GetBook(string bookData);
        IEnumerable<Book> GetAllBooks();
        void RemoveBook(string bookName);
    }
}