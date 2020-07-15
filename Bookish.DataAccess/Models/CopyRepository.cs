using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace Bookish.DataAccess.Models
{
    public class CopyRepository
    {
        private static IDbConnection _db = new SqlConnection("Server=localhost;Database=Bookish;Trusted_Connection=True;");

        public IEnumerable<Copy> getByBook(Book book)
        {
            
        }
        
        public bool Insert(Copy copy)
        {
            string sqlString = $"INSERT INTO Copies(BookID, UserID, DueDate) OUTPUT INSERTED.CopyID VALUES ('{copy.BookID}', '{copy.UserID}', '{copy.DueDate}')";
            var id = _db.QuerySingle<int>(sqlString);
            if (id != 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(int copyID)
        {
            string sqlString = $"DELETE FROM Copies WHERE CopyID = '{copyID}'";
            if (_db.Execute(sqlString) > 0)
            {
                return true;
            }

            return false;
        }

        public bool Update(Copy copy)
        {
            
        }
    }
}