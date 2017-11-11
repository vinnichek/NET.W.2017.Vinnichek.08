using System;
using Book.Logic.BookStorage;
using static Book.Logic.ComparerMethods;
using Book.Logic;
using static Book.Logic.Finder.FinderMethods;
using System.Globalization;

namespace ConsoleAppForBook
{
    class MainClass
    {
        static void Main(string[] args)
        {
            Book.Logic.Book firstBook = new Book.Logic.Book("12345", "Suzanne Collins", "The Hunger Games", "Scholastic Press",
                                     2008, 234, 20);
            Book.Logic.Book secondBook = new Book.Logic.Book("23456", "J.K. Rowling", "Harry Potter and the Order of the Phoenix", "Scholastic Inc.",
                                     2004, 312, 17);
            Book.Logic.Book thirdBook = new Book.Logic.Book("34567", "Harper Lee", "To Kill a Mockingbird", "Harper Perennial Modern Classics",
                                     2006, 245, 21);
            Book.Logic.Book fourthBook = new Book.Logic.Book("45678", "Jane Austen", "Pride and Prejudice", "Modern Library",
                                     2000, 634, 18);
            Book.Logic.Book fifthBook = new Book.Logic.Book("56789", "Stephenie Meyer", "Twilight", "Little, Brown and Company ",
                                     2006, 134, 25);
            Book.Logic.Book sixthBook = new Book.Logic.Book("56789", "Stephenie Meyer", "Twilight", "Little, Brown and Company ",
                                    2006, 134, 25);

            Console.WriteLine(firstBook.ToString());

            IFormatProvider fp = new BookFormatProvider();
            Console.WriteLine(string.Format(fp, "{0:AT}", firstBook));

            Console.WriteLine(fifthBook);

            Console.WriteLine(fifthBook.Equals(sixthBook)); //true
            Console.WriteLine(firstBook.Equals(secondBook)); //false

            Console.WriteLine(fifthBook.CompareTo(thirdBook)); //1
            Console.WriteLine(sixthBook.CompareTo(fifthBook)); //0

            BookListService service = new BookListService();
            service.AddBook(firstBook);
            service.AddBook(secondBook);
            service.AddBook(thirdBook);
            //service.AddBook(thirdBook); //exeption
            service.RemoveBook(thirdBook);
            service.AddBook(thirdBook);
            service.AddBook(fourthBook);
            service.AddBook(fifthBook);

            Console.WriteLine("\r\n");
            Console.WriteLine("------List of books.------");
            Console.WriteLine(service);

            IBookStorage binaryStorage = new BookBinaryStorage(@"/Users/vinnichek/Projects/Task/ConsoleAppForBook/Books.txt");
            //service.SaveToStorage(binaryStorage);
            //service.LoadFromStorage(binaryStorage);

            Console.WriteLine(service.FindBookByTag(new FindBookByAuthor("Suzanne Collins")));
            Console.WriteLine(service.FindBookByTag(new FindBookByPrice(25)));

            Console.WriteLine("\r\n");
            Console.WriteLine("------Sorting by authors.------");
            service.SortBookByTag(new CompareByAuthor());
            Console.WriteLine(service);

            Console.WriteLine("\r\n");
            Console.WriteLine("------Sorting by price.------");
            service.SortBookByTag(new CompareByPrice());
            Console.WriteLine(service);
        }
    }
}
