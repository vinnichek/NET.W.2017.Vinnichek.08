using System;
using System.Collections.Generic;
using System.Globalization;

namespace Book.Logic
{
    public class Book : IEquatable<Book>, IComparable, IComparable<Book>, IFormattable
    {
        #region Fields
        private string bookISBN;
        private string author;
        private string title;
        private string publishingHouse;
        private int yearOfPublishing;
        private int numberOfPages;
        private decimal price;
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
        public Book(string bookISBN, string author, string title, string publishingHouse,
                    int yearOfPublishing, int numberOfPages, decimal price)
        {
            BookISBN = bookISBN;
            Author = author;
            Title = title;
            PublishingHouse = publishingHouse;
            YearOfPublishing = yearOfPublishing;
            NumberOfPages = numberOfPages;
            Price = price;
        }
        #endregion

        #region Properties

        /// <summary>
        /// ISBN of book.
        /// </summary>
        public string BookISBN
        {
            get => bookISBN;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException($"{nameof(value)} is null or empty.");
                bookISBN = value;
            }
        }

        /// <summary>
        /// Author of book.
        /// </summary>
        public string Author
        {
            get => author;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException($"{nameof(value)} is null or empty.");
                author = value;
            }
        }

        /// <summary>
        /// Title of the book.
        /// </summary>
        public string Title
        {
            get => title;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException($"{nameof(value)} is null or empty.");
                title = value;
            }
        }

        /// <summary>
        /// Publishing house of book.
        /// </summary>
        public string PublishingHouse
        {
            get => publishingHouse;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException($"{nameof(value)} is null or empty.");
                publishingHouse = value;
            }
        }

        /// <summary>
        /// Year of publishing of book.
        /// </summary>
        public int YearOfPublishing
        {
            get => yearOfPublishing;
            set
            {
                if (value < 1100)
                    throw new ArgumentException($"{nameof(value)} is not valid.");
                yearOfPublishing = value;
            }
        }

        /// <summary>
        /// Number of pages of book.
        /// </summary>
        public int NumberOfPages
        {
            get => numberOfPages;
            set
            {
                if (value < 4)
                    throw new ArgumentException($"{nameof(value)} can't be less then 4 pages.");
                numberOfPages = value;
            }
        }

        /// <summary>
        /// Price of book.
        /// </summary>
        public decimal Price
        {
            get => price;
            set
            {
                if (value < 0)
                    throw new ArgumentException($"{nameof(value)} can't be less then 0.");
                price = value;
            }
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Return string representation of book.
        /// </summary>
        /// <returns>String representation of book.</returns>
        public string ToString(string format, IFormatProvider formatProvider) 
        {
            if (string.IsNullOrEmpty(format))
                format = "BATPYNP";

            if (formatProvider == null)
                formatProvider = CultureInfo.CurrentCulture;
            
            switch (format.ToUpperInvariant())
            {
                case "AT":
                    return $"{author} - {title}";
                case "BAT":
                    return $"{bookISBN}. {author} - {title}";
                case "BATP":
                    return $"{bookISBN}. {author} - {title}, {publishingHouse}";
                case "BATPY":
                    return $"{bookISBN}. {author} - {title}, {publishingHouse}, {yearOfPublishing}";
                case "BATPYN":
                    return $"{bookISBN}. {author} - {title}, {publishingHouse}, {yearOfPublishing}, {numberOfPages} pages";
                case "BATPYNP":
                    return $"{bookISBN}. {author} - {title}, {publishingHouse}, {yearOfPublishing}, {numberOfPages} pages, {price}$";
                case "BATPYNP+":
                    return $"ISBN: {bookISBN}. Author: {author}. Title: {title}. Publishing house: {publishingHouse}. Year of publishing: {yearOfPublishing}. Number of pages {numberOfPages} pages. Price: {price}$";
            }
            throw new FormatException("Unsupported format: " + format);
        }

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
            return string.Compare(this.Title, book.Title, StringComparison.CurrentCulture);
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
