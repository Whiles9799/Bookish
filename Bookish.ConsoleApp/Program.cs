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
                var user = userRepo.GetByCopy(copy);
                if (user != null) Console.WriteLine(user.Username);
            }
        }
    }
}