using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Bookish.DataAccess.Models;

namespace Bookish.ConsoleApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var books = Book.GetMultiple(10);
            foreach (var book in books)
            {
                Console.WriteLine(book.Author);
            }
        }
    }
}