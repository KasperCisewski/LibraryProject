using LibraryProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Builders
{
    public class BorrowedBookListBuilder
    {
        public string BuildBorrowedBookList(Person person)
        {
            var borrowedBookListByPerson = new StringBuilder();
            foreach (var book in person.BorrowedBooks)
            {
                borrowedBookListByPerson.AppendLine($"{book.BookName} - {book.AuthorSurname} - {book.ISBNNumber}");
            }
            return borrowedBookListByPerson.ToString();
        }
    }
}
