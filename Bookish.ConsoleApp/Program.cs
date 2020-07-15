using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Bookish.DataAccess;
using Bookish.DataAccess.Models;

namespace Bookish.ConsoleApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var bookRepo = new BookRepository();
            var books = bookRepo.GetMultiple(10);
            foreach (var book in books)
            {
                Console.WriteLine(book.Author);
            }
            
            var bookToInsert = new Book("Pride and Prejudice", "Jane Austen???", "77");
            Console.WriteLine(bookRepo.Insert(bookToInsert));
        }
    }
}