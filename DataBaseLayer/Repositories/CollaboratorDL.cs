using Dapper;
using System.Data;
using ModelLayer.Entities;
using DataBaseLayer.Interfaces;

public class CollaboratorDL : ICollaboratorDL
{
    private readonly IDbConnection _db;

    public CollaboratorDL(IDbConnection db)
    {
        _db = db;
    }

    public async Task<bool> AddCollaborator(int noteId, int userId, string email)
    {
        var sql = @"INSERT INTO Collaborators (NoteId, UserId, CollaboratorEmail)
                    VALUES (@NoteId, @UserId, @Email)";

        var result = await _db.ExecuteAsync(sql, new
        {
            NoteId = noteId,
            UserId = userId,
            Email = email
        });

        return result > 0;
    }

    public async Task<IEnumerable<Collaborator>> GetCollaborators(int noteId)
    {
        var sql = "SELECT * FROM Collaborators WHERE NoteId = @NoteId";
        return await _db.QueryAsync<Collaborator>(sql, new { NoteId = noteId });
    }

    public async Task<bool> RemoveCollaborator(int noteId, string email)
    {
        var sql = @"DELETE FROM Collaborators 
                    WHERE NoteId = @NoteId AND CollaboratorEmail = @Email";

        var result = await _db.ExecuteAsync(sql, new
        {
            NoteId = noteId,
            Email = email
        });

        return result > 0;
    }

    public async Task<IEnumerable<Note>> GetSharedNotes(string email)
    {
        var sql = @"SELECT N.* FROM Notes N
                    INNER JOIN Collaborators C ON N.NotesId = C.NoteId
                    WHERE C.CollaboratorEmail = @Email";

        return await _db.QueryAsync<Note>(sql, new { Email = email });
    }
}