//using System.Collections.Generic;
//using System.Data;
//using System.Threading.Tasks;
//using Dapper;
//using DataBaseLayer.Interfaces;
//using ModelLayer.Entities;

//namespace DataBaseLayer.Repositories
//{
//    public class NoteDL : INoteDL
//    {
//        private readonly IDbConnection _db;

//        public NoteDL(IDbConnection db)
//        {
//            _db = db;
//        }

//        public async Task<int> CreateNote(Note note)
//        {
//            var sql = @"INSERT INTO Notes (Title, Description, Reminder, UserId)
//                        VALUES (@Title, @Description, @Reminder, @UserId);
//                        SELECT CAST(SCOPE_IDENTITY() as int)";

//            return await _db.ExecuteScalarAsync<int>(sql, note);
//        }

//        public async Task<IEnumerable<Note>> GetAllNotes(int userId)
//        {
//            var sql = @"SELECT * FROM Notes 
//                        WHERE UserId = @UserId AND IsTrash = 0";

//            return await _db.QueryAsync<Note>(sql, new { UserId = userId });
//        }

//        //soft delete
//        public async Task<bool> MoveToTrash(int noteId, int userId)
//        {
//            var sql = "UPDATE Notes SET IsTrash = 1 WHERE NotesId = @noteId AND UserId = @userId";
//            var result = await _db.ExecuteAsync(sql, new { noteId, userId });
//            return result > 0;
//        }

//        //get trash notes
//        public async Task<IEnumerable<Note>> GetTrashNotes(int userId)
//        {
//            var sql = "SELECT * FROM Notes WHERE UserId = @userId AND IsTrash = 1";
//            return await _db.QueryAsync<Note>(sql, new { userId });
//        }

//        //restore
//        public async Task<bool> RestoreNote(int noteId, int userId)
//        {
//            var sql = "UPDATE Notes SET IsTrash = 0 WHERE NotesId = @noteId AND UserId = @userId";
//            var result = await _db.ExecuteAsync(sql, new { noteId, userId });
//            return result > 0;
//        }

//        //permanent delete
//        public async Task<bool> DeletePermanently(int noteId, int userId)
//        {
//            var sql = "DELETE FROM Notes WHERE NotesId = @noteId AND UserId = @userId";
//            var result = await _db.ExecuteAsync(sql, new { noteId, userId });
//            return result > 0;
//        }

//        //get note by id
//        //public async Task<Note> GetNoteById(int noteId, int userId)
//        //{
//        //    var sql = @"SELECT * FROM Notes 
//        //        WHERE NoteId = @NoteId AND UserId = @UserId AND IsDeleted = 0";

//        //    return await _db.QueryFirstOrDefaultAsync<Note>(sql, new
//        //    {
//        //        NoteId = noteId,
//        //        UserId = userId
//        //    });
//        //}
//        // get note by id
//        public async Task<Note> GetNoteById(int noteId, int userId)
//        {
//            var sql = @"SELECT * FROM Notes 
//                WHERE NotesId = @NoteId 
//                AND UserId = @UserId 
//                AND IsTrash = 0";

//            return await _db.QueryFirstOrDefaultAsync<Note>(sql, new
//            {
//                NoteId = noteId,
//                UserId = userId
//            });
//        }

//        public async Task<bool> UpdateNote(int noteId, int userId, UpdateNoteDto dto)
//        {
//            var sql = @"UPDATE Notes 
//                SET Title = @Title,
//                    Description = @Description,
//                    UpdatedAt = GETUTCDATE()
//                WHERE NotesId = @NoteId 
//                AND UserId = @UserId 
//                AND IsTrash = 0";

//            var result = await _db.ExecuteAsync(sql, new
//            {
//                dto.Title,
//                dto.Description,
//                NoteId = noteId,
//                UserId = userId
//            });

//            return result > 0;
//        }


//        //ARCHIV NOTE
//        public async Task<bool> ArchiveNote(int noteId, int userId)
//        {
//            var sql = @"UPDATE Notes 
//                SET IsArchive = 1 
//                WHERE NotesId = @NoteId AND UserId = @UserId";

//            var result = await _db.ExecuteAsync(sql, new
//            {
//                NoteId = noteId,
//                UserId = userId
//            });

//            return result > 0;
//        }

//        //UNARCHIVE NOTE
//        public async Task<bool> UnarchiveNote(int noteId, int userId)
//        {
//            var sql = @"UPDATE Notes 
//                SET IsArchive = 0 
//                WHERE NotesId = @NoteId AND UserId = @UserId";

//            var result = await _db.ExecuteAsync(sql, new
//            {
//                NoteId = noteId,
//                UserId = userId
//            });

//            return result > 0;
//        }

//        //GET ARCHIVED NOTES        
//        public async Task<IEnumerable<Note>> GetArchivedNotes(int userId)
//        {
//            var sql = @"SELECT * FROM Notes 
//                WHERE UserId = @UserId AND IsArchive = 1";

//            return await _db.QueryAsync<Note>(sql, new { UserId = userId });
//        }

//        //PIN
//        public async Task<bool> PinNote(int noteId, int userId)
//        {
//            var sql = @"UPDATE Notes 
//                SET IsPin = 1 
//                WHERE NotesId = @NoteId AND UserId = @UserId";

//            var result = await _db.ExecuteAsync(sql, new
//            {
//                NoteId = noteId,
//                UserId = userId
//            });

//            return result > 0;
//        }




//        //UNPIN
//        public async Task<bool> UnpinNote(int noteId, int userId)
//        {
//            var sql = @"UPDATE Notes 
//                SET IsPin = 0 
//                WHERE NotesId = @NoteId AND UserId = @UserId";

//            var result = await _db.ExecuteAsync(sql, new
//            {
//                NoteId = noteId,
//                UserId = userId
//            });

//            return result > 0;
//        }

//        //change color
//        public async Task<bool> ChangeColor(int noteId, int userId, string colour)
//        {
//            var sql = @"UPDATE Notes 
//                SET Colour = @Colour
//                WHERE NotesId = @NoteId AND UserId = @UserId";

//            var result = await _db.ExecuteAsync(sql, new
//            {
//                Colour = colour,
//                NoteId = noteId,
//                UserId = userId
//            });

//            return result > 0;
//        }

//        //Add Label to Note
//        public async Task<bool> AddLabelToNote(int noteId, int labelId)
//        {
//            var sql = @"INSERT INTO NoteLabels (NoteId, LabelId)
//                VALUES (@NoteId, @LabelId)";

//            var result = await _db.ExecuteAsync(sql, new
//            {
//                NoteId = noteId,
//                LabelId = labelId
//            });

//            return result > 0;
//        }

//        public async Task<bool> RemoveLabelFromNote(int noteId, int labelId)
//        {
//            var sql = @"DELETE FROM NoteLabels 
//                WHERE NoteId = @NoteId AND LabelId = @LabelId";

//            var result = await _db.ExecuteAsync(sql, new
//            {
//                NoteId = noteId,
//                LabelId = labelId
//            });

//            return result > 0;
//        }

//        public async Task<IEnumerable<Note>> GetNotesByLabel(int labelId)
//        {
//            var sql = @"SELECT N.* FROM Notes N
//                INNER JOIN NoteLabels NL ON N.NotesId = NL.NoteId
//                WHERE NL.LabelId = @LabelId
//                AND N.IsTrash = 0";

//            return await _db.QueryAsync<Note>(sql, new { LabelId = labelId });
//        }

//    }
//}
//======================================================================================================
//M0NGO SETUP
using DataBaseLayer.Context;
using DataBaseLayer.Interfaces;
using ModelLayer.Entities;
using ModelLayer.DTOs;
using MongoDB.Driver;

public class NoteDL : INoteDL
{
    private readonly IMongoCollection<Note> _notes;

    public NoteDL(MongoContext context)
    {
        _notes = context.Notes;
    }

    public async Task<int> CreateNote(Note note)
    {
        await _notes.InsertOneAsync(note);
        return 1;
    }

    public async Task<IEnumerable<Note>> GetAllNotes(string userId)
    {
        return await _notes.Find(n => n.UserId == userId).ToListAsync();
    }

    public async Task<Note> GetNoteById(string noteId, string userId)
    {
        return await _notes.Find(n => n.NotesId == noteId && n.UserId == userId)
                           .FirstOrDefaultAsync();
    }

    public async Task<bool> MoveToTrash(string noteId, string userId)
    {
        var update = Builders<Note>.Update.Set(n => n.IsTrash, true);

        var result = await _notes.UpdateOneAsync(
            n => n.NotesId == noteId && n.UserId == userId,
            update
        );

        return result.ModifiedCount > 0;
    }

    public async Task<bool> RestoreNote(string noteId, string userId)
    {
        var update = Builders<Note>.Update.Set(n => n.IsTrash, false);

        var result = await _notes.UpdateOneAsync(
            n => n.NotesId == noteId && n.UserId == userId,
            update
        );

        return result.ModifiedCount > 0;
    }

    public async Task<bool> DeletePermanently(string noteId, string userId)
    {
        var result = await _notes.DeleteOneAsync(
            n => n.NotesId == noteId && n.UserId == userId
        );

        return result.DeletedCount > 0;
    }

    // 🔥 UPDATE NOTE
    public async Task<bool> UpdateNote(string noteId, string userId, UpdateNoteDto dto)
    {
        var update = Builders<Note>.Update
            .Set(n => n.Title, dto.Title)
            .Set(n => n.Description, dto.Description)
            .Set(n => n.UpdatedAt, DateTime.UtcNow);

        var result = await _notes.UpdateOneAsync(
            n => n.NotesId == noteId && n.UserId == userId,
            update
        );

        return result.ModifiedCount > 0;
    }

    // 🔥 ARCHIVE
    public async Task<bool> ArchiveNote(string noteId, string userId)
    {
        var update = Builders<Note>.Update.Set(n => n.IsArchive, true);

        var result = await _notes.UpdateOneAsync(
            n => n.NotesId == noteId && n.UserId == userId,
            update
        );

        return result.ModifiedCount > 0;
    }

    public async Task<bool> UnarchiveNote(string noteId, string userId)
    {
        var update = Builders<Note>.Update.Set(n => n.IsArchive, false);

        var result = await _notes.UpdateOneAsync(
            n => n.NotesId == noteId && n.UserId == userId,
            update
        );

        return result.ModifiedCount > 0;
    }

    // 🔥 PIN
    public async Task<bool> PinNote(string noteId, string userId)
    {
        var update = Builders<Note>.Update.Set(n => n.IsPin, true);

        var result = await _notes.UpdateOneAsync(
            n => n.NotesId == noteId && n.UserId == userId,
            update
        );

        return result.ModifiedCount > 0;
    }

    public async Task<bool> UnpinNote(string noteId, string userId)
    {
        var update = Builders<Note>.Update.Set(n => n.IsPin, false);

        var result = await _notes.UpdateOneAsync(
            n => n.NotesId == noteId && n.UserId == userId,
            update
        );

        return result.ModifiedCount > 0;
    }

    // 🔥 FILTERS
    public async Task<IEnumerable<Note>> GetTrashNotes(string userId)
    {
        return await _notes.Find(n => n.UserId == userId && n.IsTrash)
                           .ToListAsync();
    }

    public async Task<IEnumerable<Note>> GetArchivedNotes(string userId)
    {
        return await _notes.Find(n => n.UserId == userId && n.IsArchive)
                           .ToListAsync();
    }

    // 🔥 COLOR
    public async Task<bool> ChangeColor(string noteId, string userId, string colour)
    {
        var update = Builders<Note>.Update.Set(n => n.Colour, colour);

        var result = await _notes.UpdateOneAsync(
            n => n.NotesId == noteId && n.UserId == userId,
            update
        );

        return result.ModifiedCount > 0;
    }

    // 🔥 LABELS (EMBEDDED)
    public async Task<bool> AddLabelToNote(string noteId, string labelName)
    {
        var update = Builders<Note>.Update.AddToSet(n => n.Labels, labelName);

        var result = await _notes.UpdateOneAsync(
            n => n.NotesId == noteId,
            update
        );

        return result.ModifiedCount > 0;
    }

    public async Task<bool> RemoveLabelFromNote(string noteId, string labelName)
    {
        var update = Builders<Note>.Update.Pull(n => n.Labels, labelName);

        var result = await _notes.UpdateOneAsync(
            n => n.NotesId == noteId,
            update
        );

        return result.ModifiedCount > 0;
    }

    public async Task<IEnumerable<Note>> GetNotesByLabel(string labelName)
    {
        return await _notes.Find(n => n.Labels.Contains(labelName))
                           .ToListAsync();
    }

    // SET REMINDER
    public async Task<bool> SetReminder(string noteId, string userId, DateTime reminder)
    {
        var update = Builders<Note>.Update
            .Set(n => n.Reminder, reminder);

        var result = await _notes.UpdateOneAsync(
            n => n.NotesId == noteId && n.UserId == userId,
            update
        );

        return result.ModifiedCount > 0;
    }


    // REMOVE REMINDER
    public async Task<bool> RemoveReminder(string noteId, string userId)
    {
        var update = Builders<Note>.Update
            .Unset(n => n.Reminder);

        var result = await _notes.UpdateOneAsync(
            n => n.NotesId == noteId && n.UserId == userId,
            update
        );

        return result.ModifiedCount > 0;
    }


    // GET ALL REMINDER NOTES
    public async Task<IEnumerable<Note>> GetReminderNotes(string userId)
    {
        return await _notes.Find(n =>
            n.UserId == userId &&
            n.Reminder != null
        ).ToListAsync();
    }

    // ADD COLLABORATOR
    public async Task<bool> AddCollaborator(string noteId, string userId, string email)
    {
        var update = Builders<Note>.Update.AddToSet(n => n.Collaborators, email);

        var result = await _notes.UpdateOneAsync(
            n => n.NotesId == noteId && n.UserId == userId,
            update
        );

        return result.ModifiedCount > 0;
    }


    // REMOVE COLLABORATOR
    public async Task<bool> RemoveCollaborator(string noteId, string userId, string email)
    {
        var update = Builders<Note>.Update.Pull(n => n.Collaborators, email);

        var result = await _notes.UpdateOneAsync(
            n => n.NotesId == noteId && n.UserId == userId,
            update
        );

        return result.ModifiedCount > 0;
    }


    // GET SHARED NOTES
    public async Task<IEnumerable<Note>> GetSharedNotes(string email)
    {
        return await _notes.Find(n => n.Collaborators.Contains(email))
                           .ToListAsync();
    }
}