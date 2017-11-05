using System;

namespace Book.Logic
{
    public class FinderMethods
    {
        /// <summary>
        /// Find book by book's ISBN.
        /// </summary>
        /// <param name="rhs">Another book to compare.</param>
        /// <returns>-1, if left book is less; 1, if greater; 0, if they are equal.</returns>
        public class FindBookByBookISBN : IFinder
        {
            private long bookISBN;

            /// <summary>
            /// Ctor for FindBookByBookISBN instance.
            /// </summary>
            /// <param name="ISBN">Book's ISBN.</param>
            public FindBookByBookISBN(long ISBN)
            {
                if (ReferenceEquals(bookISBN, null) || (bookISBN == 0))
                    throw new ArgumentNullException($"{nameof(bookISBN)} is null or empty.");
                this.bookISBN = bookISBN;
            }

            /// <summary>
            /// Compare book by give book's ISBN with given ISBN.
            /// </summary>
            /// <param name="book">Book for comparing.</param>
            /// <returns>True if book's ISBN and given ISBN are equal; false if not.</returns>
            public bool FindBook(Book book)
            {
                if (ReferenceEquals(book, null)) throw new ArgumentException($"{nameof(book)} is null.");

                return book.BookISBN == bookISBN;
            }
        }

        public class FindBookByAuthor : IFinder
        {
            private string author;

            /// <summary>
            /// Ctor for FindBookByAuthor instance.
            /// </summary>
            /// <param name="author">Book's author.</param>
            public FindBookByAuthor(string author)
            {
                if (string.IsNullOrEmpty(author)) throw new ArgumentNullException($"{nameof(author)} is null or empty.");
                this.author = author;
            }

            /// <summary>
            /// Compare book by give book's author with given author.
            /// </summary>
            /// <param name="book">Book for comparing.</param>
            /// <returns>True if book's author and given author are equal; false if not.</returns>
            public bool FindBook(Book book)
            {
                if (ReferenceEquals(author, null)) throw new ArgumentException($"{nameof(author)} is null.");
                return book.Author == author;
            }
        }

        public class FindBookByTitle : IFinder
        {
            private string title;

            /// <summary>
            /// Ctor for FindBookByTitle instance.
            /// </summary>
            /// <param name="title">Book's titlr.</param>
            public FindBookByTitle(string title)
            {
                if (string.IsNullOrEmpty(title)) throw new ArgumentNullException($"{nameof(title)} is null or empty.");
                this.title = title;
            }

            /// <summary>
            /// Compare book by give book's title with given title.
            /// </summary>
            /// <param name="book">Book for comparing.</param>
            /// <returns>True if book's title and given title are equal; false if not.</returns>
            public bool FindBook(Book book)
            {
                if (ReferenceEquals(title, null)) throw new ArgumentException($"{nameof(title)} is null.");

                return book.Title == title;
            }
        }

        public class FindBookByPublishingHouse : IFinder
        {
            private string publishingHouse;

            /// <summary>
            /// Ctor for FindBookByPublishingHouse instance.
            /// </summary>
            /// <param name="publishingHouse">Book's publishing house.</param>
            public FindBookByPublishingHouse(string publishingHouse)
            {
                if (string.IsNullOrEmpty(publishingHouse)) throw new ArgumentNullException($"{nameof(publishingHouse)} is null or empty.");
                this.publishingHouse = publishingHouse;
            }

            /// <summary>
            /// Compare book by give book's publishing house with given publishing house.
            /// </summary>
            /// <param name="book">Book for comparing.</param>
            /// <returns>True if book's publishing house and given publishing house are equal; false if not.</returns>
            public bool FindBook(Book book)
            {
                if (ReferenceEquals(publishingHouse, null)) throw new ArgumentException($"{nameof(publishingHouse)} is null.");

                return book.PublishingHouse == publishingHouse;
            }
        }

        public class FindBookByYearOfPublishing : IFinder
        {
            private int yearOfPublishing;

            /// <summary>
            /// Ctor for FindBookByYearOfPublishing instance.
            /// </summary>
            /// <param name="yearOfPublishing">Book's year of publishing.</param>
            public FindBookByYearOfPublishing(int yearOfPublishing)
            {
                if (ReferenceEquals(yearOfPublishing, null) || (yearOfPublishing == 0))
                    throw new ArgumentNullException($"{nameof(yearOfPublishing)} is null or empty.");
                this.yearOfPublishing = yearOfPublishing;
            }

            /// <summary>
            /// Compare book by give book's year of publishing with given year of publishing.
            /// </summary>
            /// <param name="book">Book for comparing.</param>
            /// <returns>True if book's year of publishing and given year of publishing are equal; false if not.</returns>
            public bool FindBook(Book book)
            {
                if (ReferenceEquals(yearOfPublishing, null)) throw new ArgumentException($"{nameof(yearOfPublishing)} is null.");

                return book.YearOfPublishing == yearOfPublishing;
            }
        }

        public class FindBookByNumberOfPages : IFinder
        {
            private int numberOfPages;

            /// <summary>
            /// Ctor for FindBookByNumberOfPages instance.
            /// </summary>
            /// <param name="numberOfPages">Book's number of pages.</param>
            public FindBookByNumberOfPages(int numberOfPages)
            {
                if (ReferenceEquals(numberOfPages, null) || (numberOfPages == 0))
                    throw new ArgumentNullException($"{nameof(numberOfPages)} is null or empty.");
                this.numberOfPages = numberOfPages;
            }

            /// <summary>
            /// Compare book by give book's number of pages with given number of pages.
            /// </summary>
            /// <param name="book">Book for comparing.</param>
            /// <returns>True if book's number of pages and given number of pages are equal; false if not.</returns>
            public bool FindBook(Book book)
            {
                if (ReferenceEquals(numberOfPages, null)) throw new ArgumentException($"{nameof(numberOfPages)} is null.");

                return book.NumberOfPages == numberOfPages;
            }
        }

        public class FindBookByPrice : IFinder
        {
            private decimal price;

            /// <summary>
            /// Ctor for FindBookByPrice instance.
            /// </summary>
            /// <param name="price">Book's price.</param>
            public FindBookByPrice(int price)
            {
                if (ReferenceEquals(price, null) || (price == 0))
                    throw new ArgumentNullException($"{nameof(price)} is null or empty.");
                this.price = price;
            }

            /// <summary>
            /// Compare book by give book's price with given price.
            /// </summary>
            /// <param name="book">Book for comparing.</param>
            /// <returns>True if book's price and given price are equal; false if not.</returns>
            public bool FindBook(Book book)
            {
                if (ReferenceEquals(price, null)) throw new ArgumentException($"{nameof(price)} is null.");

                return book.Price == price;
            }
        }
    }
}
