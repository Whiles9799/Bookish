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
            return null;
        }

        public IEnumerable<Copy> getByUser(User user)
        {
            var copies = _db.Query<Copy>("SELECT * FROM Copies WHERE UserID = @UserId", user);
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
            var sqlString = $"INSERT INTO Copies(BookID, UserID, DueDate) OUTPUT INSERTED.CopyID VALUES ('{copy.BookID}', {userID}, '{copy.DueDate}')";
            var id = _db.QuerySingle<int>(sqlString);
            if (id == 0) return false;
            copy.CopyID = id;
            return true;
        }

        public bool Delete(int copyID)
        {
            var sqlString = $"DELETE FROM Copies WHERE CopyID = '{copyID}'";
            return _db.Execute(sqlString) > 0;
        }

        public bool Update(Copy copy)
        {
            var sqlString =
                $"UPDATE [Copies] SET [BookID] = @BookID ,[UserID] = @UserID, [DueDate] = @DueDate WHERE CopyID = " +
                copy.CopyID;
            
            var rowsAffected = _db.Execute(sqlString, copy);
            
            return rowsAffected > 0;
        }
    }
}