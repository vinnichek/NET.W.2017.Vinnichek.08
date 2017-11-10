using System;
using NUnit.Framework;
using Book.Logic;

namespace Book.Tests
{
    [TestFixture]
    public class BookTests
    {
        [TestCase(null, null, TestName = "ToStringAll", ExpectedResult = "12345. Suzanne Collins - The Hunger Games, Scholastic Press, 2008, 234 pages, 20$")]
        [TestCase("AT", null, TestName = "ToString_Author_Title", ExpectedResult = "Suzanne Collins - The Hunger Games")]
        [TestCase("BAT", null, TestName = "ToString_ISBN_Author_Title", ExpectedResult = "12345. Suzanne Collins - The Hunger Games")]
        [TestCase("BATP", null, TestName = "ToString_ISBN_Author_Title_PublishingHouse", ExpectedResult = "12345. Suzanne Collins - The Hunger Games, Scholastic Press")]
        [TestCase("BATPY", null, TestName = "ToString_ISBN_Author_Title_PublishingHouse_YearOfPublishing", ExpectedResult = "12345. Suzanne Collins - The Hunger Games, Scholastic Press, 2008")]
        [TestCase("BATPYN", null, TestName = "ToString_ISBN_Author_Title_PublishingHouse_YearOfPublishing_NumberOfPages", ExpectedResult = "12345. Suzanne Collins - The Hunger Games, Scholastic Press, 2008, 234 pages")]
        [TestCase("BATPYNP", null, TestName = "ToString_ISBN_Author_Title_PublishingHouse_YearOfPublishing_NumberOfPages_Price", ExpectedResult = "12345. Suzanne Collins - The Hunger Games, Scholastic Press, 2008, 234 pages, 20$")]
        [TestCase("BATPYNP+", null, TestName = "ToStringStandartAll", ExpectedResult = "ISBN: 12345. Author: Suzanne Collins. Title: The Hunger Games. Publishing house: Scholastic Press. Year of publishing: 2008. Number of pages 234 pages. Price: 20$")]

        public string TestToString(string format, IFormatProvider provider)
        {
            Book.Logic.Book book = new Book.Logic.Book("12345", "Suzanne Collins", "The Hunger Games", "Scholastic Press",
                                     2008, 234, 20);
            return book.ToString(format, provider);
        }
    }
}
