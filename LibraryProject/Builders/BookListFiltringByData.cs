using LibraryProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Builders
{
    class BookListFiltringByData
    {
        private readonly IBookRepository _bookRepository;

        public BookListFiltringByData(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public string BuildFiltredBookList(string data)
        {
            var filtredBookList = new StringBuilder();

            var books = _bookRepository.GetAllBooks().Where(x => (x.AuthorSurname.Contains(data) || x.BookName.Contains(data) || x.ISBNNumber.Contains(data)));

            foreach (var item in books)
            {
                filtredBookList.AppendLine($"{item.BookName} - {item.AuthorSurname} - {item.ISBNNumber}");
            }

            return filtredBookList.ToString();
        }
    }
}
