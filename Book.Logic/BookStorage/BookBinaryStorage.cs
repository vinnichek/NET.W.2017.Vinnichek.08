using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace Book.Logic.BookStorage
{
    public class BookBinaryStorage : IBookStorage
    {
        #region Fields
        private string path;
        #endregion

        #region Properties
        public string Path
        {
            get => path;
            set
            {
                CheckPath(value);
                path = value;
            }
        }
        #endregion

        #region Ctors
        public BookBinaryStorage(string path)
        {
            Path = path;
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Write information about books to file.
        /// </summary>
        /// <returns>Write List of Book to file.</returns>
        public void WriteToStorage(IEnumerable<Book> bookList)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                if (ReferenceEquals(bookList, null))
                    throw new ArgumentNullException($"{nameof(bookList)} is null.");
                foreach (Book book in bookList)
                {
                    writer.Write(book.BookISBN);
                    writer.Write(book.Author);
                    writer.Write(book.Title);
                    writer.Write(book.PublishingHouse);
                    writer.Write(book.YearOfPublishing);
                    writer.Write(book.NumberOfPages);
                    writer.Write(book.Price);
                }
            }
        }

        /// <summary>
        /// Read information about books from file.
        /// </summary>
        /// <returns>Read from the file List of Book instances.</returns>
        public IEnumerable<Book> ReadFromStorage()
        {
            List<Book> bookList = new List<Book>();
            string bookISBN, author, title, publishingHouse;
            int yearOfPublishing, numberOfPages;
            decimal price;

            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate)))
            {
                while (reader.PeekChar() > -1)
                {
                    bookISBN = reader.ReadString();
                    author = reader.ReadString();
                    title = reader.ReadString();
                    publishingHouse = reader.ReadString();
                    yearOfPublishing = reader.ReadInt32();
                    numberOfPages = reader.ReadInt32();
                    price = reader.ReadDecimal();

                    bookList.Add(new Book(bookISBN, author, title, publishingHouse,
                                          yearOfPublishing, numberOfPages, price));
                }
            }
            return bookList;
        }
        #endregion

        #region Private Methods
        private void CheckPath(string path)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentNullException($"{nameof(path)} is null.");
            if (!File.Exists(path)) throw new ArgumentNullException($"{nameof(path)} does not exist.");
        }
        #endregion
    }
}
