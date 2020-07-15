using System;

namespace Bookish.DataAccess
{
    public class Copy
    {
        public string CopyID { get; set; }
        public string BookID { get; set; }
        public string UserID { get; set; }
        public DateTime DueDate { get; set; }

        public Copy(string copyId, string bookId, string userId, DateTime dueDate)
        {
            CopyID = copyId;
            BookID = bookId;
            UserID = userId;
            DueDate = dueDate;
        }

        public Copy(string bookId, string userId, DateTime dueDate)
        {
            BookID = bookId;
            UserID = userId;
            DueDate = dueDate;
        }
        
        
    }
}