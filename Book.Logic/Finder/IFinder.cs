using System;
using System.Collections.Generic;

namespace Book.Logic.Finder
{
    /// <summary>
    /// Check book by given criteria.
    /// </summary>
    /// <param name="book">Book to check.</param>
    /// <returns>True if book suitable; false if not.</returns>
    public interface IFinder
    {
        bool FindBook(Book book);
    }
}
