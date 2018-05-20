using System.Collections.Generic;
using LibraryProject.Model;

namespace LibraryProject.Services
{
    public interface IBookRepository
    {
        void AddBook(Book book);
        void UpdateBooks(Book book);
        Book GetBook(string bookData);
        IEnumerable<Book> GetAllBooks();
        void RemoveBook(string bookName);
    }
}