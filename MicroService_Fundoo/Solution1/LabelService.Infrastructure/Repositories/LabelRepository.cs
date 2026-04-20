using Dapper;
using LabelService.Application.Interfaces;
using LabelService.Domain.Entities;
using LabelService.Infrastructure.Data;

namespace LabelService.Infrastructure.Repositories
{
    public class LabelRepository : ILabelRepository
    {
        private readonly DbConnectionFactory _factory;

        public LabelRepository(DbConnectionFactory factory)
        {
            _factory = factory;
        }

        public async Task<int> AddAsync(Label label)
        {
            var sql = @"INSERT INTO Labels(UserId,Name,CreatedAt)
                        VALUES(@UserId,@Name,@CreatedAt)";

            using var con = _factory.CreateConnection();
            return await con.ExecuteAsync(sql, label);
        }

        public async Task<IEnumerable<Label>> GetByUserIdAsync(string userId)
        {
            var sql = "SELECT * FROM Labels WHERE UserId=@UserId";

            using var con = _factory.CreateConnection();
            return await con.QueryAsync<Label>(sql, new { UserId = userId });
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Labels WHERE Id=@Id";

            using var con = _factory.CreateConnection();
            return await con.ExecuteAsync(sql, new { Id = id });
        }
    }
}
