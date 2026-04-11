using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using DataBaseLayer.Interfaces;
using ModelLayer.Entities;

namespace DataBaseLayer.Repositories
{
    public class NoteDL : INoteDL
    {
        private readonly IDbConnection _db;

        public NoteDL(IDbConnection db)
        {
            _db = db;
        }

        public async Task<int> CreateNote(Note note)
        {
            var sql = @"INSERT INTO Notes (Title, Description, Reminder, UserId)
                        VALUES (@Title, @Description, @Reminder, @UserId);
                        SELECT CAST(SCOPE_IDENTITY() as int)";

            return await _db.ExecuteScalarAsync<int>(sql, note);
        }

        public async Task<IEnumerable<Note>> GetAllNotes(int userId)
        {
            var sql = @"SELECT * FROM Notes 
                        WHERE UserId = @UserId AND IsTrash = 0";

            return await _db.QueryAsync<Note>(sql, new { UserId = userId });
        }

        //soft delete
        public async Task<bool> MoveToTrash(int noteId, int userId)
        {
            var sql = "UPDATE Notes SET IsTrash = 1 WHERE NotesId = @noteId AND UserId = @userId";
            var result = await _db.ExecuteAsync(sql, new { noteId, userId });
            return result > 0;
        }

        //get trash notes
        public async Task<IEnumerable<Note>> GetTrashNotes(int userId)
        {
            var sql = "SELECT * FROM Notes WHERE UserId = @userId AND IsTrash = 1";
            return await _db.QueryAsync<Note>(sql, new { userId });
        }

        //restore
        public async Task<bool> RestoreNote(int noteId, int userId)
        {
            var sql = "UPDATE Notes SET IsTrash = 0 WHERE NotesId = @noteId AND UserId = @userId";
            var result = await _db.ExecuteAsync(sql, new { noteId, userId });
            return result > 0;
        }

        //permanent delete
        public async Task<bool> DeletePermanently(int noteId, int userId)
        {
            var sql = "DELETE FROM Notes WHERE NotesId = @noteId AND UserId = @userId";
            var result = await _db.ExecuteAsync(sql, new { noteId, userId });
            return result > 0;
        }

        //get note by id
        //public async Task<Note> GetNoteById(int noteId, int userId)
        //{
        //    var sql = @"SELECT * FROM Notes 
        //        WHERE NoteId = @NoteId AND UserId = @UserId AND IsDeleted = 0";

        //    return await _db.QueryFirstOrDefaultAsync<Note>(sql, new
        //    {
        //        NoteId = noteId,
        //        UserId = userId
        //    });
        //}
        // get note by id
        public async Task<Note> GetNoteById(int noteId, int userId)
        {
            var sql = @"SELECT * FROM Notes 
                WHERE NotesId = @NoteId 
                AND UserId = @UserId 
                AND IsTrash = 0";

            return await _db.QueryFirstOrDefaultAsync<Note>(sql, new
            {
                NoteId = noteId,
                UserId = userId
            });
        }

        public async Task<bool> UpdateNote(int noteId, int userId, UpdateNoteDto dto)
        {
            var sql = @"UPDATE Notes 
                SET Title = @Title,
                    Description = @Description,
                    UpdatedAt = GETUTCDATE()
                WHERE NotesId = @NoteId 
                AND UserId = @UserId 
                AND IsTrash = 0";

            var result = await _db.ExecuteAsync(sql, new
            {
                dto.Title,
                dto.Description,
                NoteId = noteId,
                UserId = userId
            });

            return result > 0;
        }


        //ARCHIV NOTE
        public async Task<bool> ArchiveNote(int noteId, int userId)
        {
            var sql = @"UPDATE Notes 
                SET IsArchive = 1 
                WHERE NotesId = @NoteId AND UserId = @UserId";

            var result = await _db.ExecuteAsync(sql, new
            {
                NoteId = noteId,
                UserId = userId
            });

            return result > 0;
        }

        //UNARCHIVE NOTE
        public async Task<bool> UnarchiveNote(int noteId, int userId)
        {
            var sql = @"UPDATE Notes 
                SET IsArchive = 0 
                WHERE NotesId = @NoteId AND UserId = @UserId";

            var result = await _db.ExecuteAsync(sql, new
            {
                NoteId = noteId,
                UserId = userId
            });

            return result > 0;
        }

        //GET ARCHIVED NOTES        
        public async Task<IEnumerable<Note>> GetArchivedNotes(int userId)
        {
            var sql = @"SELECT * FROM Notes 
                WHERE UserId = @UserId AND IsArchive = 1";

            return await _db.QueryAsync<Note>(sql, new { UserId = userId });
        }

        //PIN
        public async Task<bool> PinNote(int noteId, int userId)
        {
            var sql = @"UPDATE Notes 
                SET IsPin = 1 
                WHERE NotesId = @NoteId AND UserId = @UserId";

            var result = await _db.ExecuteAsync(sql, new
            {
                NoteId = noteId,
                UserId = userId
            });

            return result > 0;
        }




        //UNPIN
        public async Task<bool> UnpinNote(int noteId, int userId)
        {
            var sql = @"UPDATE Notes 
                SET IsPin = 0 
                WHERE NotesId = @NoteId AND UserId = @UserId";

            var result = await _db.ExecuteAsync(sql, new
            {
                NoteId = noteId,
                UserId = userId
            });

            return result > 0;
        }

        //change color
        public async Task<bool> ChangeColor(int noteId, int userId, string colour)
        {
            var sql = @"UPDATE Notes 
                SET Colour = @Colour
                WHERE NotesId = @NoteId AND UserId = @UserId";

            var result = await _db.ExecuteAsync(sql, new
            {
                Colour = colour,
                NoteId = noteId,
                UserId = userId
            });

            return result > 0;
        }

        //Add Label to Note
        public async Task<bool> AddLabelToNote(int noteId, int labelId)
        {
            var sql = @"INSERT INTO NoteLabels (NoteId, LabelId)
                VALUES (@NoteId, @LabelId)";

            var result = await _db.ExecuteAsync(sql, new
            {
                NoteId = noteId,
                LabelId = labelId
            });

            return result > 0;
        }

        public async Task<bool> RemoveLabelFromNote(int noteId, int labelId)
        {
            var sql = @"DELETE FROM NoteLabels 
                WHERE NoteId = @NoteId AND LabelId = @LabelId";

            var result = await _db.ExecuteAsync(sql, new
            {
                NoteId = noteId,
                LabelId = labelId
            });

            return result > 0;
        }

        public async Task<IEnumerable<Note>> GetNotesByLabel(int labelId)
        {
            var sql = @"SELECT N.* FROM Notes N
                INNER JOIN NoteLabels NL ON N.NotesId = NL.NoteId
                WHERE NL.LabelId = @LabelId
                AND N.IsTrash = 0";

            return await _db.QueryAsync<Note>(sql, new { LabelId = labelId });
        }

    }
}