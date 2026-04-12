//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using BusinessLayer.Cache;
//using BusinessLayer.Interfaces;
//using DataBaseLayer.Interfaces;
//using ModelLayer.DTOs;
//using ModelLayer.Entities;

//namespace BusinessLayer.Service
//{
//    public class NoteBL : INoteBL
//    {
//        private readonly INoteDL _noteDL;
//        private readonly ICacheService _cacheService; // ADD

//        public NoteBL(INoteDL noteDL, ICacheService cacheService) // ADD
//        {
//            _noteDL = noteDL;
//            _cacheService = cacheService;
//        }

//        public async Task<int> CreateNote(CreateNoteDto dto, string userId)
//        {
//            var note = new Note
//            {
//                Title = dto.Title,
//                Description = dto.Description,
//                Reminder = dto.Reminder,
//                UserId = userId,
//                CreatedAt = DateTime.UtcNow,
//                UpdatedAt = DateTime.UtcNow,
//                IsArchive = false,
//                IsPin = false,
//                IsTrash = false
//            };

//            var result = await _noteDL.CreateNote(note);

//            // ❌ CLEAR CACHE
//            await _cacheService.RemoveData($"notes_{userId}");

//            return result;
//        }

//        public async Task<IEnumerable<Note>> GetNotes(string userId)
//        {
//            string cacheKey = $"notes_{userId}";

//            Console.WriteLine("Checking cache...");

//            var cachedData = await _cacheService.GetData<IEnumerable<Note>>(cacheKey);

//            if (cachedData != null)
//            {
//                Console.WriteLine("Data from CACHE !!!");
//                return cachedData;
//            }

//            Console.WriteLine("Data from DATABASE !!");

//            var notes = await _noteDL.GetAllNotes(userId);

//            Console.WriteLine("Saving to cache...");

//            await _cacheService.SetData(cacheKey, notes, DateTimeOffset.Now.AddMinutes(5));

//            return notes;
//        }

//        public async Task<bool> MoveToTrash(int noteId, string userId)
//        {
//            var result = await _noteDL.MoveToTrash(noteId, userId);
//            await _cacheService.RemoveData($"notes_{userId}");
//            return result;
//        }

//        public async Task<IEnumerable<Note>> GetTrashNotes(string userId)
//        {
//            return await _noteDL.GetTrashNotes(userId);
//        }

//        public async Task<bool> RestoreNote(int noteId, string userId)
//        {
//            var result = await _noteDL.RestoreNote(noteId, userId);
//            await _cacheService.RemoveData($"notes_{userId}");
//            return result;
//        }

//        public async Task<bool> DeletePermanently(int noteId, string userId)
//        {
//            var result = await _noteDL.DeletePermanently(noteId, userId);
//            await _cacheService.RemoveData($"notes_{userId}");
//            return result;
//        }

//        public async Task<Note> GetNoteById(int noteId, string userId)
//        {
//            var note = await _noteDL.GetNoteById(noteId, userId);

//            if (note == null)
//                throw new Exception("Note not found");

//            return note;
//        }

//        public async Task<bool> UpdateNote(int noteId, string userId, UpdateNoteDto dto)
//        {
//            var result = await _noteDL.UpdateNote(noteId, userId, dto);
//            await _cacheService.RemoveData($"notes_{userId}");
//            return result;
//        }

//        public async Task<bool> ArchiveNote(int noteId, string userId)
//        {
//            var result = await _noteDL.ArchiveNote(noteId, userId);
//            await _cacheService.RemoveData($"notes_{userId}");
//            return result;
//        }

//        public async Task<bool> UnarchiveNote(int noteId, string userId)
//        {
//            var result = await _noteDL.UnarchiveNote(noteId, userId);
//            await _cacheService.RemoveData($"notes_{userId}");
//            return result;
//        }

//        public async Task<IEnumerable<Note>> GetArchivedNotes(string userId)
//        {
//            return await _noteDL.GetArchivedNotes(userId);
//        }

//        public async Task<bool> PinNote(int noteId, string userId)
//        {
//            var result = await _noteDL.PinNote(noteId, userId);
//            await _cacheService.RemoveData($"notes_{userId}");
//            return result;
//        }

//        public async Task<bool> UnpinNote(int noteId, string userId)
//        {
//            var result = await _noteDL.UnpinNote(noteId, userId);
//            await _cacheService.RemoveData($"notes_{userId}");
//            return result;
//        }

//        public async Task<bool> ChangeColor(int noteId, string userId, string colour)
//        {
//            var result = await _noteDL.ChangeColor(noteId, userId, colour);
//            await _cacheService.RemoveData($"notes_{userId}");
//            return result;
//        }

//        public async Task<bool> AddLabelToNote(int noteId, int labelId)
//        {
//            return await _noteDL.AddLabelToNote(noteId, labelId);
//        }

//        public async Task<bool> RemoveLabelFromNote(int noteId, int labelId)
//        {
//            return await _noteDL.RemoveLabelFromNote(noteId, labelId);
//        }

//        public async Task<IEnumerable<Note>> GetNotesByLabel(int labelId)
//        {
//            return await _noteDL.GetNotesByLabel(labelId);
//        }
//    }
//}

//===================================================================================================
// MONGO SETUP
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Cache;
using BusinessLayer.Interfaces;
using DataBaseLayer.Interfaces;
using ModelLayer.DTOs;
using ModelLayer.Entities;

namespace BusinessLayer.Service
{
    public class NoteBL : INoteBL
    {
        private readonly INoteDL _noteDL;
        private readonly ICacheService _cacheService;

        public NoteBL(INoteDL noteDL, ICacheService cacheService)
        {
            _noteDL = noteDL;
            _cacheService = cacheService;
        }

        public async Task<int> CreateNote(CreateNoteDto dto, string userId)
        {
            var note = new Note
            {
                Title = dto.Title,
                Description = dto.Description,
                UserId = userId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsArchive = false,
                IsPin = false,
                IsTrash = false
            };

            var result = await _noteDL.CreateNote(note);

            await _cacheService.RemoveData($"notes_{userId}");

            return result;
        }

        public async Task<IEnumerable<Note>> GetNotes(string userId)
        {
            string cacheKey = $"notes_{userId}";

            var cachedData = await _cacheService.GetData<IEnumerable<Note>>(cacheKey);

            if (cachedData != null)
                return cachedData;

            var notes = await _noteDL.GetAllNotes(userId);

            await _cacheService.SetData(cacheKey, notes, DateTimeOffset.Now.AddMinutes(5));

            return notes;
        }

        public async Task<bool> MoveToTrash(string noteId, string userId)
        {
            var result = await _noteDL.MoveToTrash(noteId, userId);
            await _cacheService.RemoveData($"notes_{userId}");
            return result;
        }

        public async Task<IEnumerable<Note>> GetTrashNotes(string userId)
        {
            return await _noteDL.GetTrashNotes(userId);
        }

        public async Task<bool> RestoreNote(string noteId, string userId)
        {
            var result = await _noteDL.RestoreNote(noteId, userId);
            await _cacheService.RemoveData($"notes_{userId}");
            return result;
        }

        public async Task<bool> DeletePermanently(string noteId, string userId)
        {
            var result = await _noteDL.DeletePermanently(noteId, userId);
            await _cacheService.RemoveData($"notes_{userId}");
            return result;
        }

        public async Task<Note> GetNoteById(string noteId, string userId)
        {
            var note = await _noteDL.GetNoteById(noteId, userId);

            if (note == null)
                throw new Exception("Note not found");

            return note;
        }

        public async Task<bool> UpdateNote(string noteId, string userId, UpdateNoteDto dto)
        {
            var result = await _noteDL.UpdateNote(noteId, userId, dto);
            await _cacheService.RemoveData($"notes_{userId}");
            return result;
        }

        public async Task<bool> ArchiveNote(string noteId, string userId)
        {
            var result = await _noteDL.ArchiveNote(noteId, userId);
            await _cacheService.RemoveData($"notes_{userId}");
            return result;
        }

        public async Task<bool> UnarchiveNote(string noteId, string userId)
        {
            var result = await _noteDL.UnarchiveNote(noteId, userId);
            await _cacheService.RemoveData($"notes_{userId}");
            return result;
        }

        public async Task<IEnumerable<Note>> GetArchivedNotes(string userId)
        {
            return await _noteDL.GetArchivedNotes(userId);
        }

        public async Task<bool> PinNote(string noteId, string userId)
        {
            var result = await _noteDL.PinNote(noteId, userId);
            await _cacheService.RemoveData($"notes_{userId}");
            return result;
        }

        public async Task<bool> UnpinNote(string noteId, string userId)
        {
            var result = await _noteDL.UnpinNote(noteId, userId);
            await _cacheService.RemoveData($"notes_{userId}");
            return result;
        }

        public async Task<bool> ChangeColor(string noteId, string userId, string colour)
        {
            var result = await _noteDL.ChangeColor(noteId, userId, colour);
            await _cacheService.RemoveData($"notes_{userId}");
            return result;
        }

        // 🔥 LABELS (Mongo style)
        public async Task<bool> AddLabelToNote(string noteId, string labelName)
        {
            return await _noteDL.AddLabelToNote(noteId, labelName);
        }

        public async Task<bool> RemoveLabelFromNote(string noteId, string labelName)
        {
            return await _noteDL.RemoveLabelFromNote(noteId, labelName);
        }

        public async Task<IEnumerable<Note>> GetNotesByLabel(string labelName)
        {
            return await _noteDL.GetNotesByLabel(labelName);
        }

        public async Task<bool> SetReminder(string noteId, string userId, DateTime reminder)
        {
            return await _noteDL.SetReminder(noteId, userId, reminder);
        }

        public async Task<bool> RemoveReminder(string noteId, string userId)
        {
            return await _noteDL.RemoveReminder(noteId, userId);
        }

        public async Task<IEnumerable<Note>> GetReminderNotes(string userId)
        {
            return await _noteDL.GetReminderNotes(userId);
        }
        public async Task<bool> AddCollaborator(string noteId, string userId, string email)
        {
            return await _noteDL.AddCollaborator(noteId, userId, email);
        }

        public async Task<bool> RemoveCollaborator(string noteId, string userId, string email)
        {
            return await _noteDL.RemoveCollaborator(noteId, userId, email);
        }

        public async Task<IEnumerable<Note>> GetSharedNotes(string email)
        {
            return await _noteDL.GetSharedNotes(email);
        }
    }
}