using System;
using System.Collections.Generic;

namespace Book.Logic
{
    public class Book : IEquatable<Book>, IComparable, IComparable<Book>
    {
        #region Fields
        private readonly long bookISBN;
        private readonly string author;
        private readonly string title;
        private readonly string publishingHouse;
        private readonly int yearOfPublishing;
        private readonly int numberOfPages;
        private readonly decimal price;
        #endregion

        #region Properties
        public long BookISBN => bookISBN;
        public string Author => author;
        public string Title => title;
        public string PublishingHouse => publishingHouse;
        public int YearOfPublishing => yearOfPublishing;
        public int NumberOfPages => numberOfPages;
        public decimal Price => price;
        #endregion

        #region Ctors

        /// <summary>
        /// Ctor for Book instance.
        /// </summary>
        /// <param name="bookISBN">Book ISBN.</param>
        /// <param name="author">Book author.</param>
        /// <param name="title">Book title.</param>
        /// <param name="publishingHouse">Book publishing house.</param>
        /// <param name="yearOfPublishing">Year of publishing.</param>
        /// <param name="numberOfPages">Number of pages.</param>
        /// <param name="price">Book price.</param>
        public Book(long bookISBN, string author, string title, string publishingHouse,
                    int yearOfPublishing, int numberOfPages, decimal price)
        {
            this.bookISBN = bookISBN;
            this.author = author;
            this.title = title;
            this.publishingHouse = publishingHouse;
            this.yearOfPublishing = yearOfPublishing;
            this.numberOfPages = numberOfPages;
            this.price = price;
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Return string representation of book.
        /// </summary>
        /// <returns>String representation of book.</returns>
        public override string ToString() => $"{bookISBN}. {author} - {title}, {publishingHouse}, {yearOfPublishing}, {numberOfPages} pages, {price}$";

        /// <summary>
        /// Compare two books.
        /// </summary>
        /// <param name="other">Book for comparing.</param>
        /// <returns>True if books are equal; false if not.</returns>
        public bool Equals(Book other)
        {
            if (ReferenceEquals(other, null)) return false;
            return this.bookISBN == other.bookISBN && this.author == other.author &&
                       this.title == other.title && this.publishingHouse == other.publishingHouse &&
                       this.yearOfPublishing == other.yearOfPublishing &&
                       this.numberOfPages == other.numberOfPages && this.price == other.price;
        }

        /// <summary>
        /// Check two books for equality.
        /// </summary>
        /// <param name="obj">Object for comparing.</param>
        /// <returns>True - if books are equal; false - if not.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            return Equals(obj as Book);
        }

        /// <summary>
        /// Calculate hash code.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Compare two books by title.
        /// </summary>
        /// <param name="book">Book to compare.</param>
        /// <returns>-1 - if object is less than parameter book; 1 - if greater; 0 - if they are equal.</returns>
        public int CompareTo(Book book)
        {
            if (ReferenceEquals(book, null)) throw new ArgumentNullException($"{nameof(book)} is null.");
            return this.Title.CompareTo(book.Title);
        }

        /// <summary>
        /// Compare two books.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>-1 - if object is less than parameter book; 1 - if greater; 0 - if they are equal.</returns>
        int IComparable.CompareTo(object obj)
        {
            if (ReferenceEquals(obj, null)) throw new ArgumentNullException($"{nameof(obj)} is null.");
            return this.CompareTo(obj as Book);
        }

        /// <summary>
        /// Compare two books by given criteria.
        /// </summary>
        /// <param name="lhs">One book.</param>
        /// <param name="rhs">Another book.</param>
        /// <returns>-1 - if left book less then right; 1 - if greater; 0 - if equals.</returns>
        public static int Compare(Book lhs, Book rhs, IComparer<Book> comparer)
        {
            if (ReferenceEquals(comparer, null)) throw new ArgumentNullException($"{nameof(comparer)} is null.");
            return comparer.Compare(lhs, rhs);
        }
        #endregion
    }
}
