
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
        private static LibraryService _libraryService;
        private static PeopleListWithBorrowedBooksBuilder _peopleListWithBorrowedBooksBuilder;
        private static NotBorrowedBooksBuilder _notBorrowedBooksBuilder;
        private static BookListFiltringByData _bookListFiltringByData;
        private static AvailableBookListBuilder _availableBookListBuilder;
        private static readonly BorrowedBookListBuilder _borrowedBookListBuilder = new BorrowedBookListBuilder();

        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
               _bookRepository = new BookRepository(args[0]);
            }
            else
                _bookRepository = new BookRepository(Path.Combine(Environment.CurrentDirectory) + "ListOfObject.json"); // lub  Environment.CurrentDirectory,   @"..\..\..\Project2\xml\File.xml" );

            _libraryService = new LibraryService(_bookRepository, new BookValidator(),new PersonRepository(),new PersonValidator());
            _peopleListWithBorrowedBooksBuilder=new PeopleListWithBorrowedBooksBuilder(new PersonRepository(),_bookRepository);
            _notBorrowedBooksBuilder = new NotBorrowedBooksBuilder(_bookRepository);
            _bookListFiltringByData = new BookListFiltringByData(_bookRepository);
            _availableBookListBuilder = new AvailableBookListBuilder(_bookRepository);
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
                        SearchingBookByNameAuthorISBNNumber();
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
                    case 7:
                        GivingBackBook();
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
            Console.WriteLine("7. Giving back book to library");
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

            Console.WriteLine(_libraryService.TrySaveBook(book));       
        }

        static void RemoveBookFromCatalog()
        {
            Console.WriteLine("It`s list of books");
            Console.Write(_notBorrowedBooksBuilder.BuildNotBorrowedBookList(0));
            Console.WriteLine("Which book, you want to delete? Give precise bookname like on the list.");
            string bookName = Console.ReadLine();

            Console.WriteLine(_libraryService.TryRemoveBook(bookName));
        }

        static void SearchingBookByNameAuthorISBNNumber()
        {
            Console.WriteLine("Write bookName, author or ISBN number of book which you are looking for");
            string dataDescribedBook = Console.ReadLine();

            Console.Write(_bookListFiltringByData.BuildFiltredBookList(dataDescribedBook));

        }

        static void SearchingBookByNotBorrowedInLastTime()
        {
            Console.WriteLine("Give a number of weeks");
            if(int.TryParse(Console.ReadLine(),out var numberOfWeeks))
            {
               Console.Write(_notBorrowedBooksBuilder.BuildNotBorrowedBookList(numberOfWeeks));
            }
            else
            {
                Console.WriteLine("Text was not a number" );
            }

        }

        static void BorrowingBook()
        {
            Console.WriteLine("Write Your name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Write Your surname: ");
            string lastName = Console.ReadLine();

            Console.Write(_availableBookListBuilder.BuildAvailableBookList());

            Console.WriteLine("Select a book from the list by name(First Column)");

            string bookName = Console.ReadLine();

            Console.Write(_libraryService.TryToBorrowBook(bookName, firstName, lastName));

        }

        static void ShowPeopleListWithHisBorrowedBooks()
        {
            Console.WriteLine("The number of books borrowed by people: ");
            Console.Write(_peopleListWithBorrowedBooksBuilder.BuildBorrowedBookList());
        }
        static void GivingBackBook()
        {
            Console.WriteLine("Write your name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Write you Lastname: ");
            string lastName = Console.ReadLine();
            var person = _libraryService.TakePersonIfExist(firstName, lastName);
            if(person!=null)
            {
                Console.WriteLine("There is your borrowed book list");
                Console.WriteLine(_borrowedBookListBuilder.BuildBorrowedBookList(person));
                Console.WriteLine("Which book you want to give back?");
                string bookName = Console.ReadLine();
                Console.WriteLine(_libraryService.TryToGiveBackBook(person,bookName));
                return;
            }
            Console.WriteLine("We don`t  have a person like you in our data bases");
        }

    }

}


