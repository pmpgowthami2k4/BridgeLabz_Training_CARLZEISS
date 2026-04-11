using System.Data;
using Dapper;
using DataBaseLayer.Interfaces;
using ModelLayer.Entities;

namespace DataBaseLayer.Repositories
{
    public class LabelDL : ILabelDL
    {
        private readonly IDbConnection _db;

        public LabelDL(IDbConnection db)
        {
            _db = db;
        }

        public async Task<int> CreateLabel(string name, int userId)
        {
            var sql = @"INSERT INTO Labels (Name, UserId)
                        VALUES (@Name, @UserId);
                        SELECT CAST(SCOPE_IDENTITY() as int)";

            return await _db.ExecuteScalarAsync<int>(sql, new
            {
                Name = name,
                UserId = userId
            });
        }

        public async Task<IEnumerable<Label>> GetLabels(int userId)
        {
            var sql = @"SELECT * FROM Labels WHERE UserId = @UserId";
            return await _db.QueryAsync<Label>(sql, new { UserId = userId });
        }

        public async Task<bool> UpdateLabel(int labelId, int userId, string name)
        {
            var sql = @"UPDATE Labels 
                        SET Name = @Name
                        WHERE LabelId = @LabelId AND UserId = @UserId";

            var result = await _db.ExecuteAsync(sql, new
            {
                Name = name,
                LabelId = labelId,
                UserId = userId
            });

            return result > 0;
        }

        public async Task<bool> DeleteLabel(int labelId, int userId)
        {
            var sql = @"DELETE FROM Labels 
                        WHERE LabelId = @LabelId AND UserId = @UserId";

            var result = await _db.ExecuteAsync(sql, new
            {
                LabelId = labelId,
                UserId = userId
            });

            return result > 0;
        }
    }
}
