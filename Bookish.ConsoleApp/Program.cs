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
            var userRepo = new UserRepository();
            var copyRepo = new CopyRepository();
            foreach (var copy in copyRepo.getMultiple(10))
            {
                Console.WriteLine(userRepo.GetByCopy(copy).Username);
            }
        }
    }
}