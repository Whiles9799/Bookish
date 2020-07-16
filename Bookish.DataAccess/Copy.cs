using System;

namespace Bookish.DataAccess
{
    public class Copy
    {
        public int CopyID { get; set; }
        public int BookID { get; set; }
        public int UserID { get; set; }
        public DateTime DueDate { get; set; }

        public Copy(int copyId, int bookId, int userId, DateTime dueDate)
        {
            CopyID = copyId;
            BookID = bookId;
            UserID = userId;
            DueDate = dueDate;
        }

        public Copy(int bookId, int userId, DateTime dueDate)
        {
            BookID = bookId;
            UserID = userId;
            DueDate = dueDate;
        }

        public Copy(int bookID)
        {
            BookID = bookID;
        }
        
        
    }
}