using Dapper;
using LabelService.Application.DTOs;
using LabelService.Application.Interfaces;
using LabelService.Domain.Entities;
using LabelService.Infrastructure.Data;

namespace LabelService.Infrastructure.Repositories
{
    public class NoteLabelRepository : INoteLabelRepository
    {
        private readonly DbConnectionFactory _factory;

        public NoteLabelRepository(DbConnectionFactory factory)
        {
            _factory = factory;
        }

        public async Task<int> AddAsync(NoteLabel model)
        {
            var sql = @"INSERT INTO NoteLabels(NoteId,LabelId)
                        VALUES(@NoteId,@LabelId)";

            using var con = _factory.CreateConnection();
            return await con.ExecuteAsync(sql, model);
        }

        public async Task<IEnumerable<NoteLabelResponseDto>> GetByNoteIdAsync(int noteId)
        {
            var sql = @"
        SELECT 
            nl.Id AS MappingId,
            nl.NoteId,
            nl.LabelId,
            l.Name AS LabelName
        FROM NoteLabels nl
        INNER JOIN Labels l
            ON nl.LabelId = l.Id
        WHERE nl.NoteId = @NoteId";

            using var con = _factory.CreateConnection();

            return await con.QueryAsync<NoteLabelResponseDto>(
                sql,
                new { NoteId = noteId });
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM NoteLabels WHERE Id=@Id";

            using var con = _factory.CreateConnection();
            return await con.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<IEnumerable<NoteLabelResponseDto>> GetNotesByLabelAsync(string labelName)
        {
            var sql = @"
        SELECT 
            nl.Id AS MappingId,
            nl.NoteId,
            nl.LabelId,
            l.Name AS LabelName
        FROM NoteLabels nl
        INNER JOIN Labels l
            ON nl.LabelId = l.Id
        WHERE l.Name = @LabelName";

            using var con = _factory.CreateConnection();

            return await con.QueryAsync<NoteLabelResponseDto>(
                sql,
                new { LabelName = labelName });
        }
    }
}