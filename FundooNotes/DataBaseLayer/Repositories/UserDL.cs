using System.Data;
using System.Threading.Tasks;
using Dapper;
using DataBaseLayer.Interfaces;
using Microsoft.Data.SqlClient;
using ModelLayer.Entities;

namespace DataBaseLayer.Repositories
{
    public class UserDL : IUserDL
    {
        private readonly IDbConnection _db;

        public UserDL(IDbConnection db)
        {
            _db = db;
        }

        // 🔹 Register user
        public async Task<User> CreateUser(User user)
        {
            user.CreatedAt = DateTime.UtcNow;
            user.ChangedAt = DateTime.UtcNow;
            user.IsActive = true;

            var sql = @"
                INSERT INTO Users (FirstName, LastName, Email, Password, CreatedAt, ChangedAt, IsActive)
                VALUES (@FirstName, @LastName, @Email, @Password, @CreatedAt, @ChangedAt, @IsActive);
                SELECT CAST(SCOPE_IDENTITY() as int);";

            var userId = await _db.ExecuteScalarAsync<int>(sql, user);
            user.UserId = userId;

            return user;
        }

        // 🔹 Get user by email (for login)
        public async Task<User> GetUserByEmail(string email)
        {
            var sql = @"SELECT * FROM Users WHERE LOWER(Email) = LOWER(@Email)";

            return await _db.QueryFirstOrDefaultAsync<User>(sql, new { Email = email });
        }

        // 🔹 Update user password
        public async Task<bool> UpdatePassword(int userId, string newPassword)
        {
            var query = "UPDATE Users SET Password = @Password WHERE UserId = @UserId";

            var result = await _db.ExecuteAsync(query, new
            {
                Password = newPassword,
                UserId = userId
            });

            return result > 0;
        }
    }
}
//===================================================================================================
//MONGOSETUP

//using DataBaseLayer.Context;
//using DataBaseLayer.Interfaces;
//using ModelLayer.Entities;
//using MongoDB.Driver;

//namespace DataBaseLayer.Repositories
//{
//    public class UserDL : IUserDL
//    {
//        private readonly IMongoCollection<User> _users;

//        public UserDL(MongoContext context)
//        {
//            _users = context.Users;
//        }

//        public async Task<User> CreateUser(User user)
//        {
//            await _users.InsertOneAsync(user);
//            return user;
//        }

//        public async Task<User> GetUserByEmail(string email)
//        {
//            return await _users.Find(u => u.Email == email).FirstOrDefaultAsync();
//        }

//        public async Task<bool> UpdatePassword(string userId, string newPassword)
//        {
//            var update = Builders<User>.Update.Set(u => u.Password, newPassword);

//            var result = await _users.UpdateOneAsync(
//                u => u.UserId == userId,
//                update
//            );

//            return result.ModifiedCount > 0;
//        }
//    }
//}
