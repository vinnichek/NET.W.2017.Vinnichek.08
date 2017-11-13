using System;
using Book.Logic;
using NUnit.Framework;

namespace Book.Tests
{
    [TestFixture]
    public class BookTests
    {
        [TestCase("{0:AT}", TestName = "ToString_Author_Title", ExpectedResult = "Suzanne Collins - The Hunger Games")]
        [TestCase("{0:BAT}", TestName = "ToString_ISBN_Author_Title", ExpectedResult = "12345. Suzanne Collins - The Hunger Games")]
        [TestCase("{0:BATP}", TestName = "ToString_ISBN_Author_Title_PublishingHouse", ExpectedResult = "12345. Suzanne Collins - The Hunger Games, Scholastic Press")]
        [TestCase("{0:BATPY}", TestName = "ToString_ISBN_Author_Title_PublishingHouse_YearOfPublishing", ExpectedResult = "12345. Suzanne Collins - The Hunger Games, Scholastic Press, 2008")]
        [TestCase("{0:BATPYN}", TestName = "ToString_ISBN_Author_Title_PublishingHouse_YearOfPublishing_NumberOfPages", ExpectedResult = "12345. Suzanne Collins - The Hunger Games, Scholastic Press, 2008, 234 pages")]
        [TestCase("{0:BATPYNP}", TestName = "ToString_ISBN_Author_Title_PublishingHouse_YearOfPublishing_NumberOfPages_Price", ExpectedResult = "12345. Suzanne Collins - The Hunger Games, Scholastic Press, 2008, 234 pages, 20$")]

        public string TestToString(string format, IFormatProvider provider)
        {
            Book.Logic.Book book = new Book.Logic.Book("12345", "Suzanne Collins", "The Hunger Games", "Scholastic Press", 2008, 234, 20);
            return book.ToString(format, provider);
        }

        [TestCase("{0:BATPYNP+}", TestName = "Format_All", ExpectedResult = "ISBN: 12345. Author: Suzanne Collins. Title: The Hunger Games. Publishing house: Scholastic Press. Year of publishing: 2008. Number of pages 234 pages. Price: 20$")]

        public string TestFormatBook(string format)
        {
            Book.Logic.Book book = new Book.Logic.Book("12345", "Suzanne Collins", "The Hunger Games", "Scholastic Press",
                                     2008, 234, 20);
            return string.Format(new BookFormatProvider(), format, book);
        }
    }
}
