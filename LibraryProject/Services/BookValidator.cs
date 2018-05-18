using LibraryProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Services
{
    class BookValidator : IBookValidator
    {
        public bool Validate(Book book)
        {
            if(IsElevenDigitsInISBNNumber(book.ISBNNumber))
            {
                return true;
            }
            return false;
        }
        public bool IsElevenDigitsInISBNNumber(string iSBNNumber)
        {
            if(iSBNNumber.Length==13)
            {
                return true;
            }
            return false;
        }
    }
}
