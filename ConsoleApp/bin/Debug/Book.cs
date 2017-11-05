using System;
using System.Collections.Generic;

namespace Book.Logic
{
    public class Book : IEquatable<Book>, IComparable , IComparable<Book>
    {
        private readonly long bookISBN;
        private readonly string author;
        private readonly string title;
        private readonly string publishingHouse;
        private readonly int yearOfPublishing;
        private readonly int numberOfPages;
        private readonly decimal price;

        public long BookISBN => bookISBN;
        public string Author => author;
        public string Title => title;
        public string PublishingHouse => publishingHouse;
        public int YearOfPublishing => yearOfPublishing;
        public int NumberOfPages => numberOfPages;
        public decimal Price => price;

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

        public override string ToString() => $"{bookISBN}. {author} - {title}, {publishingHouse}, {yearOfPublishing}, {numberOfPages} pages, {price}$";

        public bool Equals(Book other)
        {
            if (ReferenceEquals(other, null)) return false;
            return this.bookISBN == other.bookISBN && this.author == other.author &&
                       this.title == other.title && this.publishingHouse == other.publishingHouse &&
                       this.yearOfPublishing == other.yearOfPublishing &&
                       this.numberOfPages == other.numberOfPages && this.price == other.price;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            return Equals(obj as Book);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int CompareTo(Book book)
        {
            if (ReferenceEquals(book, null)) throw new ArgumentNullException($"{nameof(book)} is null.");
            return this.Title.CompareTo(book.Title);
        }

        int IComparable.CompareTo(object obj)
        {
            if (ReferenceEquals(obj, null)) throw new ArgumentNullException($"{nameof(obj)} is null.");
            return this.CompareTo(obj as Book);
        }

        public static int Compare(Book lhs, Book rhs, IComparer<Book> comparer)
        {
            if (ReferenceEquals(comparer, null)) throw new ArgumentNullException($"{nameof(comparer)} is null.");
            return comparer.Compare(lhs, rhs);
        }
    }
}
