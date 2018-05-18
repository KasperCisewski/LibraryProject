using LibraryProject.Model;

namespace LibraryProject.Services
{
    interface IBookValidator
    {
        bool Validate(Book book);
        bool IsElevenDigitsInISBNNumber(string iSBNNumber);
    }
}