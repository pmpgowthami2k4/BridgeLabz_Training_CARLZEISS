//using System.Data;
//using Dapper;
//using DataBaseLayer.Interfaces;
//using ModelLayer.Entities;

//namespace DataBaseLayer.Repositories
//{
//    public class LabelDL : ILabelDL
//    {
//        private readonly IDbConnection _db;

//        public LabelDL(IDbConnection db)
//        {
//            _db = db;
//        }

//        public async Task<int> CreateLabel(string name, int userId)
//        {
//            var sql = @"INSERT INTO Labels (Name, UserId)
//                        VALUES (@Name, @UserId);
//                        SELECT CAST(SCOPE_IDENTITY() as int)";

//            return await _db.ExecuteScalarAsync<int>(sql, new
//            {
//                Name = name,
//                UserId = userId
//            });
//        }

//        public async Task<IEnumerable<Label>> GetLabels(int userId)
//        {
//            var sql = @"SELECT * FROM Labels WHERE UserId = @UserId";
//            return await _db.QueryAsync<Label>(sql, new { UserId = userId });
//        }

//        public async Task<bool> UpdateLabel(int labelId, int userId, string name)
//        {
//            var sql = @"UPDATE Labels 
//                        SET Name = @Name
//                        WHERE LabelId = @LabelId AND UserId = @UserId";

//            var result = await _db.ExecuteAsync(sql, new
//            {
//                Name = name,
//                LabelId = labelId,
//                UserId = userId
//            });

//            return result > 0;
//        }

//        public async Task<bool> DeleteLabel(int labelId, int userId)
//        {
//            var sql = @"DELETE FROM Labels 
//                        WHERE LabelId = @LabelId AND UserId = @UserId";

//            var result = await _db.ExecuteAsync(sql, new
//            {
//                LabelId = labelId,
//                UserId = userId
//            });

//            return result > 0;
//        }
//    }
//}

//===================================================================================================
//MONGO SETUP
using DataBaseLayer.Context;
using DataBaseLayer.Interfaces;
using ModelLayer.Entities;
using MongoDB.Driver;

namespace DataBaseLayer.Repositories
{
    public class LabelDL : ILabelDL
    {
        private readonly IMongoCollection<Label> _labels;

        public LabelDL(MongoContext context)
        {
            _labels = context.Labels;
        }

        public async Task<int> CreateLabel(string name, string userId)
        {
            var label = new Label
            {
                LabelName = name,
                UserId = userId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _labels.InsertOneAsync(label);

            return 1; // Mongo doesn't return int ID
        }

        public async Task<IEnumerable<Label>> GetLabels(string userId)
        {
            return await _labels.Find(l => l.UserId == userId).ToListAsync();
        }

        public async Task<bool> UpdateLabel(string labelName, string userId, string newName)
        {
            var update = Builders<Label>.Update
                .Set(l => l.LabelName, newName)
                .Set(l => l.UpdatedAt, DateTime.UtcNow);

            var result = await _labels.UpdateOneAsync(
                l => l.LabelName == labelName && l.UserId == userId,
                update
            );

            return result.ModifiedCount > 0;
        }

        public async Task<bool> DeleteLabel(string labelName, string userId)
        {
            var result = await _labels.DeleteOneAsync(
                l => l.LabelName == labelName && l.UserId == userId
            );

            return result.DeletedCount > 0;
        }
    }
}