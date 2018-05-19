using LibraryProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Model
{
    public class Book
    { 
        public string BookName { get; set; }
        public string AuthorSurname { get; set; }
        public string ISBNNumber { get; set; }
        public DateTime DateLastBorrow { get; set; }
        public int? IdPerson { get; set; }

        public Book(string bookName,string authorSurname,string iSBNNumber)
        {
            BookName = bookName;
            AuthorSurname = authorSurname;
            ISBNNumber = iSBNNumber;
            IdPerson = null;
        }
    }
}
