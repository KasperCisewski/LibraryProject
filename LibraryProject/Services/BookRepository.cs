using LibraryProject.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace LibraryProject.Services
{
    public class BookRepository : IBookRepository
    {

        public string FilePath { get; set; }

        public BookRepository(string filePath)
        {
            FilePath = filePath;
        }

        public void AddBook(Book book)
        {
            
            if (FilePath.Contains(".json"))
            {
                string jsonData = JsonConvert.SerializeObject(book);
                File.AppendAllText(FilePath, "\n" + jsonData);
                return;
            }

            Stream fs = new FileStream(FilePath, FileMode.Append);
            XmlWriter writer = new XmlTextWriter(fs, Encoding.Unicode);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Book));

            xmlSerializer.Serialize(writer, book);


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
            if (FilePath.Contains(".json"))
            {
                using (StreamReader sr = new StreamReader(FilePath))
                {
                    foreach (var line in File.ReadLines(FilePath))
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                            bookList.Add(JsonConvert.DeserializeObject<Book>(line));
                    }
                }
            }
            else
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Book));
                Stream fs = new FileStream(FilePath, FileMode.Open);
                XmlReader reader = XmlReader.Create(fs);
                bookList = (List<Book>)serializer.Deserialize(reader);
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
            List<string> dataObjects = new List<string>();
            if (FilePath.Contains(".json"))
            {
                foreach (var item in bookList)
                {
                    dataObjects.Add(JsonConvert.SerializeObject(item));
                    File.WriteAllLines(FilePath, dataObjects);

                }
            }
            else
            {
                Stream fs = new FileStream(FilePath, FileMode.Create);
                XmlWriter writer = new XmlTextWriter(fs, Encoding.Unicode);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Book));

                foreach(var book in bookList)
                {
                    xmlSerializer.Serialize(writer, book);
                    fs = new FileStream(FilePath, FileMode.Append);
                    writer = new XmlTextWriter(fs, Encoding.Unicode);
                }
            }
            
        }     
    }
}
