using System;

using System.Collections.Generic;

namespace Book.Logic
{
    public class ComparerMethods
    {
        #region Public Methods

        /// <summary>
        /// Compare two books by books' ISBN.
        /// </summary>
        /// <param name="lhs">One book to compare.</param>
        /// <param name="rhs">Another book to compare.</param>
        /// <returns>-1, if left book is less; 1, if greater; 0, if they are equal.</returns>
        public class CompareByBookISBN : IComparer<Book>
        {
            public int Compare(Book lhs, Book rhs)
            {
                if (ReferenceEquals(lhs, null)) throw new ArgumentException($"{nameof(lhs)} is null.");
                if (ReferenceEquals(rhs, null)) throw new ArgumentException($"{nameof(rhs)} is null.");

                return lhs.BookISBN.CompareTo(rhs.BookISBN);
            }
        }

        /// <summary>
        /// Compare two books by books' authors.
        /// </summary>
        /// <param name="lhs">One book to compare.</param>
        /// <param name="rhs">Another book to compare.</param>
        /// <returns>-1, if left book is less; 1, if greater; 0, if they are equal.</returns>
        public class CompareByAuthor : IComparer<Book>
        {
            public int Compare(Book lhs, Book rhs)
            {
                if (ReferenceEquals(lhs, null)) throw new ArgumentException($"{nameof(lhs)} is null.");
                if (ReferenceEquals(rhs, null)) throw new ArgumentException($"{nameof(rhs)} is null.");

                return lhs.Author.CompareTo(rhs.Author);
            }
        }

        /// <summary>
        /// Compare two books by books' titles.
        /// </summary>
        /// <param name="lhs">One book to compare.</param>
        /// <param name="rhs">Another book to compare.</param>
        /// <returns>-1, if left book is less; 1, if greater; 0, if they are equal.</returns>
        public class CompareByTitle : IComparer<Book>
        {
            public int Compare(Book lhs, Book rhs)
            {
                if (ReferenceEquals(lhs, null)) throw new ArgumentException($"{nameof(lhs)} is null.");
                if (ReferenceEquals(rhs, null)) throw new ArgumentException($"{nameof(rhs)} is null.");

                return lhs.Title.CompareTo(rhs.Title);
            }
        }

        /// <summary>
        /// Compare two books by books' publishing houses.
        /// </summary>
        /// <param name="lhs">One book to compare.</param>
        /// <param name="rhs">Another book to compare.</param>
        /// <returns>-1, if left book is less; 1, if greater; 0, if they are equal.</returns>
        public class CompareByPublishingHouse : IComparer<Book>
        {
            public int Compare(Book lhs, Book rhs)
            {
                if (ReferenceEquals(lhs, null)) throw new ArgumentException($"{nameof(lhs)} is null.");
                if (ReferenceEquals(rhs, null)) throw new ArgumentException($"{nameof(rhs)} is null.");

                return lhs.PublishingHouse.CompareTo(rhs.PublishingHouse);
            }
        }

        /// <summary>
        /// Compare two books by books' publishing years.
        /// </summary>
        /// <param name="lhs">One book to compare.</param>
        /// <param name="rhs">Another book to compare.</param>
        /// <returns>-1, if left book is less; 1, if greater; 0, if they are equal.</returns>
        public class CompareByYearOfPublishing : IComparer<Book>
        {
            public int Compare(Book lhs, Book rhs)
            {
                if (ReferenceEquals(lhs, null)) throw new ArgumentException($"{nameof(lhs)} is null.");
                if (ReferenceEquals(rhs, null)) throw new ArgumentException($"{nameof(rhs)} is null.");

                return lhs.YearOfPublishing.CompareTo(rhs.YearOfPublishing);
            }
        }

        /// <summary>
        /// Compare two books by books' number of pages.
        /// </summary>
        /// <param name="lhs">One book to compare.</param>
        /// <param name="rhs">Another book to compare.</param>
        /// <returns>-1, if left book is less; 1, if greater; 0, if they are equal.</returns>
        public class CompareByNumberOfPages : IComparer<Book>
        {
            public int Compare(Book lhs, Book rhs)
            {
                if (ReferenceEquals(lhs, null)) throw new ArgumentException($"{nameof(lhs)} is null.");
                if (ReferenceEquals(rhs, null)) throw new ArgumentException($"{nameof(rhs)} is null.");

                return lhs.NumberOfPages.CompareTo(rhs.NumberOfPages);
            }
        }

        /// <summary>
        /// Compare two books by books' price.
        /// </summary>
        /// <param name="lhs">One book to compare.</param>
        /// <param name="rhs">Another book to compare.</param>
        /// <returns>-1, if left book is less; 1, if greater; 0, if they are equal.</returns>
        public class CompareByPrice : IComparer<Book>
        {
            public int Compare(Book lhs, Book rhs)
            {
                if (ReferenceEquals(lhs, null)) throw new ArgumentException($"{nameof(lhs)} is null.");
                if (ReferenceEquals(rhs, null)) throw new ArgumentException($"{nameof(rhs)} is null.");

                return lhs.Price.CompareTo(rhs.Price);
            }
        }
        #endregion
    }
}
