using System.Linq;
using Bookish.DataAccess.Models;

namespace Bookish.DataAccess
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }

        public Book(int bookId, string title, string author, string isbn)
        {
            BookID = bookId;
            Title = title;
            Author = author;
            ISBN = isbn;
        }
        
        public Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
        }

        public bool AddCopies(int amount, CopyRepository copyRepo)
        {
            bool inserted = true;
            foreach (var i in Enumerable.Range(0, amount))
            {
                var copy = new Copy(BookID);
                inserted &= copyRepo.Insert(copy);
            }

            return inserted;
        }
    }
}