using Dapper;
using CollaboratorService.Application.Interfaces;
using CollaboratorService.Domain.Entities;
using CollaboratorService.Infrastructure.Data;

namespace CollaboratorService.Infrastructure.Repositories
{
    public class CollaboratorRepository : ICollaboratorRepository
    {
        private readonly DbConnectionFactory _factory;

        public CollaboratorRepository(DbConnectionFactory factory)
        {
            _factory = factory;
        }

        public async Task<int> AddAsync(Collaborator collaborator)
        {
            var sql = @"INSERT INTO Collaborators
                        (NoteId, OwnerUserId, CollaboratorEmail, CreatedAt)
                        VALUES
                        (@NoteId, @OwnerUserId, @CollaboratorEmail, @CreatedAt)";

            using var connection = _factory.CreateConnection();
            return await connection.ExecuteAsync(sql, collaborator);
        }

        public async Task<IEnumerable<Collaborator>> GetByNoteIdAsync(int noteId)
        {
            var sql = "SELECT * FROM Collaborators WHERE NoteId=@NoteId";

            using var connection = _factory.CreateConnection();
            return await connection.QueryAsync<Collaborator>(sql, new { NoteId = noteId });
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Collaborators WHERE Id=@Id";

            using var connection = _factory.CreateConnection();
            return await connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
