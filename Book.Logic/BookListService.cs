using System;
using System.Collections.Generic;
using System.Text;
using Book.Logic.BookStorage;
using Book.Logic.Finder;

namespace Book.Logic
{
    public class BookListService
    {
        #region Fields
        private List<Book> bookList = new List<Book>();
        #endregion

        #region Public Methods

        /// <summary>
        /// Add book to the collection.
        /// </summary>
        /// <param name="book">Book for adding.</param>
        public void AddBook(Book book)
        {
            if (ReferenceEquals(book, null))
                throw new ArgumentException($"{nameof(book)} is null.");
            if (bookList.Contains(book))
                throw new ArgumentException($"{nameof(book)} exists.");
            bookList.Add(book);
        }

        /// <summary>
        /// Remove book from the collection.
        /// </summary>
        /// <param name="book">Book for removing.</param>
        public void RemoveBook(Book book)
        {
            if (ReferenceEquals(book, null))
                throw new ArgumentException($"{nameof(book)} is null.");
            if (!bookList.Contains(book))
                throw new ArgumentException($"{nameof(book)} don't exists.");
            bookList.Remove(book);
        }

        /// <summary>
        /// Find book by given criteria.
        /// </summary>
        /// <param name="finder">Criteria for finding.</param>
        public Book FindBookByTag(IFinder finder)
        {
            if (ReferenceEquals(finder, null))
                throw new ArgumentException($"{nameof(finder)} is null.");
            foreach (Book book in bookList)
            {
                if (finder.FindBook(book))
                    return book;
            }
            return null;
        }

        /// <summary>
        /// Sort book by given criteria.
        /// </summary>
        /// <param name="comparer">Criteria for sorting.</param>
        public void SortBookByTag(IComparer<Book> comparer)
        {
            if (ReferenceEquals(comparer, null))
                throw new ArgumentException($"{nameof(comparer)} is null.");
            bookList.Sort(comparer);
        }

        /// <summary>
        /// Save collection of books to storage.
        /// </summary>
        /// <param name="storage">Storage to save.</param>
        public void SaveToStorage(IBookStorage storage)
        {
            if (ReferenceEquals(storage, null))
                throw new ArgumentException($"{nameof(storage)} is null.");
            storage.WriteToStorage(bookList);
        }

        /// <summary>
        /// Load collection of books from storage.
        /// </summary>
        /// <param name="storage">Storage to load.</param>
        public void LoadFromStorage(IBookStorage storage)
        {
            if (ReferenceEquals(storage, null)) throw new ArgumentException($"{nameof(storage)} is null.");
            IEnumerable<Book> bookList = storage.ReadFromStorage();
            foreach (Book book in bookList)
            {
                this.AddBook(book);
            }
        }

        /// <summary>
        /// Return string representation of collection of books.
        /// </summary>
        ///<returns>String representation of collection of books.</returns>
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append("Books:\r\n");
            foreach (Book books in bookList)
            {
                str.Append(books);
                str.Append("\r\n");
            }
            return str.ToString();
        }
        #endregion
    }
}
