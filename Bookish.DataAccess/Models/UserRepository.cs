using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace Bookish.DataAccess.Models
{
    public class UserRepository
    {
        private static IDbConnection _db = new SqlConnection("Server=localhost;Database=Bookish;Trusted_Connection=True;");

        public IEnumerable<User> GetMultiple(int amount)
        {
            return _db.Query<User>($"SELECT TOP {amount} * FROM Users");
        }

        public User GetByCopy(Copy copy)
        {
            var sqlString =
                "SELECT Users.UserID, Username, Pass FROM Users JOIN Copies ON Copies.UserID = Users.UserID WHERE Copies.CopyID = @CopyID";
            var user = _db.QuerySingleOrDefault<User>(sqlString, copy);
            return user;
        }
        
        public bool Insert(User user)
        {
            const string sqlString = "INSERT INTO Users(Username, Pass) OUTPUT INSERTED.UserID VALUES(@Username, @Pass)";
            var id = _db.QuerySingle<int>(sqlString, user);
            if (id == 0) return false;
            user.UserID = id;
            return true;

        }

        public bool Delete(int userID)
        {
            return _db.Execute("DELETE FROM Users WHERE UserID = @userID", userID) > 0;
        }

        public bool Update(User user)
        {
            const string sqlString = "UPDATE [Users] SET [Username] = @Username, [Pass] = @Pass WHERE UserID = @UserID";
            return _db.Execute(sqlString, user) > 0;
        }
        
    }
}