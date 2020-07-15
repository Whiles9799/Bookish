using System;
using Bookish.DataAccess.Models;

namespace Bookish.DataAccess
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Pass { get; set; }

        public User(int userId, string username, string pass)
        {
            UserID = userId;
            Username = username;
            Pass = pass;
        }

        public User(string username, string pass)
        {
            Username = username;
            Pass = pass;
        }
        
        

        public bool BorrowCopy(Copy copy, CopyRepository copyRepo)
        {
            copy.UserID = UserID;
            copy.DueDate = DateTime.Today.AddDays(28);
            return copyRepo.Update(copy);
        }
    }
}