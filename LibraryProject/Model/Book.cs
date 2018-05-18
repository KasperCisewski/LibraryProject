using LibraryProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Model
{
    class Book
    { 
        public string BookName { get; set; }
        public string AuthorSurname { get; set; }
        public string ISBNNumber { get; set; }
        public DateTime DateLastBorrow { get; set; }
        public Person Person { get; set; }

        public Book(string bookName,string authorSurname,string iSBNNumber)
        {
            BookName = bookName;
            AuthorSurname = authorSurname;
            ISBNNumber = iSBNNumber;
        }
    }
}
