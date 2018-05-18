using LibraryProject.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Services
{
    class BookRepository : IBookRepository
    {

        public string FilePath { get; set; }

        public BookRepository(string filePath)
        {
            FilePath = filePath;
        }

        public void AddBook(Book book)
        {
          string jsonData = JsonConvert.SerializeObject(book);

            File.WriteAllText(FilePath, jsonData);
        }
        public void RemoveBook(Book book)
        {

        }
        public Book GetBook(string bookData)
        {
            var bookList = GetAllBooks().ToList();
            return bookList.First(x => (bookData.Contains(x.BookName) || bookData.Contains(x.AuthorSurname) || bookData.Contains(x.ISBNNumber)));
        }

        public IEnumerable<Book> GetAllBooks()
        {
            var bookList = new List<Book>();
            using (StreamReader sr = new StreamReader(FilePath)) 
            {
                foreach (var line in File.ReadLines(FilePath))
                {
                    bookList.Add(JsonConvert.DeserializeObject<Book>(line));
                }
            }

            return bookList;
        }

    
        public void BorrowBook(Book book,Person person)
        {

        }
   

      
    }
}
