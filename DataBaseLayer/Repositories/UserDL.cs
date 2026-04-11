using System.Data;
using System.Threading.Tasks;
using Dapper;
using DataBaseLayer.Interfaces;
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
    }
}