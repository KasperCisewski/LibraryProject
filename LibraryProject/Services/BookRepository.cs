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

            File.AppendAllText(FilePath, "\n"+ jsonData);
         
        }
        public void RemoveBook(string bookName)
        {
            var bookList = GetAllBooks().ToList();
            bookList.RemoveAll(x => x.BookName == bookName);
            bookList.OrderBy(x => x.BookName);

            SaveBooksToFile(bookList);
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
                    if(!string.IsNullOrWhiteSpace(line))
                    bookList.Add(JsonConvert.DeserializeObject<Book>(line));
                }
            }
            bookList.OrderBy(x => x.BookName);
            return bookList;
        }

    
        public void UpdateBooks(Book book)
        {
            var bookList = GetAllBooks().ToList();
            bookList.RemoveAll(x => x.BookName == book.BookName);
            bookList.Add(book);
            SaveBooksToFile(bookList);
        }

        private void SaveBooksToFile(List<Book> bookList)
        {
            List<string> jsonObjects = new List<string>();
            foreach (var item in bookList)
            {
                jsonObjects.Add(JsonConvert.SerializeObject(item));
            }
            File.WriteAllLines(FilePath, jsonObjects);
        }     
    }
}
