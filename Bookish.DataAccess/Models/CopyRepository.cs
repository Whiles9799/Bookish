using System;
using System.Collections.Generic;
using System.Configuration;
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
            var copies = _db.Query<Copy>("SELECT * FROM Copies WHERE BookID = @BookID", book);
            return copies;
        }

        public IEnumerable<Copy> getMultiple(int amount)
        {
            var copies = _db.Query<Copy>($"SELECT TOP {amount} * FROM Copies");
            return copies;
        }
        
        public bool Insert(Copy copy)
        {
            var userID = copy.UserID == 0 ? "NULL" : copy.UserID.ToString();
            string sqlString = $"INSERT INTO Copies(BookID, UserID, DueDate) OUTPUT INSERTED.CopyID VALUES ('{copy.BookID}', {userID}, '{copy.DueDate}')";
            var id = _db.QuerySingle<int>(sqlString);
            if (id != 0)
            {
                copy.CopyID = id;
                return true;
            }
            return false;
        }

        public bool Delete(int copyID)
        {
            string sqlString = $"DELETE FROM Copies WHERE CopyID = @copyID'";
            if (_db.Execute(sqlString, copyID) > 0)
            {
                return true;
            }

            return false;
        }

        public bool Update(Copy copy)
        {
            string sqlString =
                $"UPDATE [Copies] SET [BookID] = @BookID ,[UserID] = @UserID, [DueDate] = @DueDate WHERE CopyID = " +
                copy.CopyID;
            
            int rowsAffected = _db.Execute(sqlString, copy);
            
            if (rowsAffected > 0)
            {
                return true;
            }

            return false;
        }
    }
}