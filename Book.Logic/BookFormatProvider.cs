using System;
using System.Globalization;
using System.Text;

namespace Book.Logic
{
    public class BookFormatProvider : IFormatProvider, ICustomFormatter
    {

        IFormatProvider parent;

        public BookFormatProvider() : this(CultureInfo.CurrentCulture) { }

        public BookFormatProvider(IFormatProvider parent)
        {
            this.parent = parent;
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter)) return this;
            return null;
        }

        public string Format(string format, object arg, IFormatProvider prov)
        {
            var book = arg as Book;

            if (arg == null || format != "BATPYNP+")
               return string.Format(parent, "{0:" + format + "}", arg);
          
            if (format == "BATPYNP+") return $"ISBN: {book.BookISBN}. Author: {book.Author}. Title: {book.Title}. Publishing house: {book.PublishingHouse}. Year of publishing: {book.YearOfPublishing}. Number of pages {book.NumberOfPages} pages. Price: {book.Price}$";
        
            throw new FormatException("Unsupported format: " + format);        
        }

    }
}
