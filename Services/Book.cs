using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Book
    {
        datamodel.Entities db = new datamodel.Entities();

        public IEnumerable<datamodel.Book> GetAllBooks()
        {
            //var m_books = db.Books;
            //формировать строку из автора книги + название + год
            //db.Books.Load(); vBooks
            return db.Books;
        }

        public datamodel.Book GetById(int id)
        {
            return db.Books.FirstOrDefault(p => p.Id == id);

        }
        public List<datamodel.Book> GetBooks(string term)
        {
            var t = db.Books.Where(p => p.BookName.StartsWith(term));

            return t.ToList();
        }
    }
}
