using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Policy;
using Dapper;

namespace Bookish.DataAccess.Models
{

    public class BookRepository
    {
        private static IDbConnection _db = new SqlConnection("Server=localhost;Database=Bookish;Trusted_Connection=True;");

        public IEnumerable<Book> GetMultiple(int amount)
        {
            var books = _db.Query<Book>($"SELECT TOP {amount} * FROM Books");
            return books;
        }

        public IEnumerable<Book> GetByAuthor(string author)
        {
            var books = _db.Query<Book>($"SELECT * FROM Books WHERE Author LIKE '{author}%'");
            return books;
        }
        
        public IEnumerable<Book> GetByTitle(string title)
        {
            var books = _db.Query<Book>($"SELECT * FROM Books WHERE Title LIKE '{title}%'");
            return books;
        }

        public bool Insert(Book book)
        {
            string sqlString = $"INSERT INTO Books(Title, Author, ISBN) OUTPUT INSERTED.BookID VALUES ('{book.Title}', '{book.Author}', '{book.ISBN}')";
            var id = _db.QuerySingle<int>(sqlString);
            if (id != 0)
            {
                book.BookID = id;
                return true;
            }
            return false;
        }

        public bool Delete(int bookID)
        {
            string sqlString = $"DELETE FROM Books WHERE BookID = '{bookID}'";
            if (_db.Execute(sqlString) > 0)
            {
                return true;
            }

            return false;
        }
        
        
    }
}