using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace Bookish.DataAccess.Models
{

    public class Book : Model
    {
        private static IDbConnection _db = new SqlConnection("Server=localhost;Database=Bookish;Trusted_Connection=True;");

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
        
        public static IEnumerable<Book> GetMultiple(int amount)
        {
            var books = _db.Query<Book>($"SELECT TOP {amount} * FROM Books");
            return books;
        }

        public bool Insert()
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }
        
    }
}