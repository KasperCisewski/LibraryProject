
using LibraryProject.Builders;
using LibraryProject.Model;
using LibraryProject.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject
{
    class Program
    {
        private static BookRepository _bookRepository;
        private static BookService _bookService;
        private static PeopleListWithBorrowedBooksBuilder _peopleListWithBorrowedBooksBuilder;
        private static NotBorrowedBooksBuilder _notBorrowedBooksBuilder;

        static void Main(string[] args)
        {         
            if (args.Length > 0)
                _bookRepository = new BookRepository(args[0]);
            else
                _bookRepository = new BookRepository(Path.Combine(Environment.CurrentDirectory)+"ListOfObject.json"); // lub  Environment.CurrentDirectory,   @"..\..\..\Project2\xml\File.xml" );

            _bookService = new BookService(_bookRepository, new BookValidator());
            _peopleListWithBorrowedBooksBuilder=new PeopleListWithBorrowedBooksBuilder(_bookRepository);
            _notBorrowedBooksBuilder = new NotBorrowedBooksBuilder(_bookRepository);
            Menu();

            return;
        }
        static void Menu()
        {
            string productName;
            do
            {
                Console.WriteLine("Press a number, if you want to exit, press 'q' ");
                WriteOptions();
                productName = Console.ReadLine();
                int.TryParse(productName, out var chosenNumber);
                switch (chosenNumber)
                {
                    case 1:
                        AddBookToCatalog();
                        break;
                    case 2:
                        RemoveBookFromCatalog();
                        break;
                    case 3:
                        SearchingBookByName();
                        break;
                    case 4:
                        SearchingBookByNotBorrowedInLastTime();
                        break;
                    case 5:
                        BorrowingBook();
                        break;
                    case 6:
                        ShowPeopleListWithHisBorrowedBooks();
                        break;
                    default:
                        Console.WriteLine("your number isn`t match");
                        break;
                }
            } while (productName.ToLower() != "q");
        }

        static void WriteOptions()
        {
            Console.WriteLine("1. Add book to catalog ");
            Console.WriteLine("2. Delete book from catalog ");
            Console.WriteLine("3. Searching book by bookname,author, or ISBN number ");
            Console.WriteLine("4. Searching book which have not been borrower for weeks ");
            Console.WriteLine("5. Borrowing a book ");
            Console.WriteLine("6. Showing list of people which have borrowerd books ");
            Console.WriteLine("q. Quit ");
        }

        static void AddBookToCatalog()
        {
            Console.WriteLine("What`s book name?");
            string bookName = Console.ReadLine();
            Console.WriteLine("What`s author surname?");
            string surname = Console.ReadLine();
            Console.WriteLine("What`s ISBN Number?");
            string ISBNNumber = Console.ReadLine();
            var book = new Book(bookName, surname, ISBNNumber);

            Console.WriteLine(_bookService.TakeAndTrySaveBook(book));       
        }
        static void RemoveBookFromCatalog()
        {
            
        }
        static void SearchingBookByName()
        {

        }
        static void SearchingBookByNotBorrowedInLastTime()
        {

        }
        static void BorrowingBook()
        {

        }
        static void ShowPeopleListWithHisBorrowedBooks()
        {

        }

    }
}
