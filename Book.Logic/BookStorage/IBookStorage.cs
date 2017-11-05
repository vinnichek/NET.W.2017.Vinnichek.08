using System;
using System.Collections.Generic;

namespace Book.Logic.BookStorage
{
    public interface IBookStorage
    {
        /// <summary>
        /// Read information from storage.
        /// </summary>
        /// <returns>Collection of objects.</returns>
        IEnumerable<Book> ReadFromStorage();

        /// <summary>
        /// Write information to storage.
        /// </summary>
        /// <param name="bookList">Collection of objects.</param>
        void WriteToStorage(IEnumerable<Book> bookList);
    }
}
