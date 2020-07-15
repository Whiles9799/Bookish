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
            
            var copyRepo = new CopyRepository();
            var newCopy = new Copy(2);
            copyRepo.Insert(newCopy);
            newCopy.DueDate = DateTime.Today.AddDays(5);
            newCopy.UserID = 1;
            if (copyRepo.Update(newCopy))
            {
                Console.WriteLine("Updated");
            }
            foreach (var copy in copyRepo.getMultiple(10))
            {
                Console.WriteLine(copy.DueDate);
            }
        }
    }
}