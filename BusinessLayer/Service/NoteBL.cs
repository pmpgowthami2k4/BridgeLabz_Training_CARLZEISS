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
        private readonly ICacheService _cacheService; // ADD

        public NoteBL(INoteDL noteDL, ICacheService cacheService) // ADD
        {
            _noteDL = noteDL;
            _cacheService = cacheService;
        }

        public async Task<int> CreateNote(CreateNoteDto dto, int userId)
        {
            var note = new Note
            {
                Title = dto.Title,
                Description = dto.Description,
                Reminder = dto.Reminder,
                UserId = userId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsArchive = false,
                IsPin = false,
                IsTrash = false
            };

            var result = await _noteDL.CreateNote(note);

            // ❌ CLEAR CACHE
            await _cacheService.RemoveData($"notes_{userId}");

            return result;
        }

        public async Task<IEnumerable<Note>> GetNotes(int userId)
        {
            string cacheKey = $"notes_{userId}";

            Console.WriteLine("Checking cache...");

            var cachedData = await _cacheService.GetData<IEnumerable<Note>>(cacheKey);

            if (cachedData != null)
            {
                Console.WriteLine("Data from CACHE !!!");
                return cachedData;
            }

            Console.WriteLine("Data from DATABASE !!");

            var notes = await _noteDL.GetAllNotes(userId);

            Console.WriteLine("Saving to cache...");

            await _cacheService.SetData(cacheKey, notes, DateTimeOffset.Now.AddMinutes(5));

            return notes;
        }

        public async Task<bool> MoveToTrash(int noteId, int userId)
        {
            var result = await _noteDL.MoveToTrash(noteId, userId);
            await _cacheService.RemoveData($"notes_{userId}");
            return result;
        }

        public async Task<IEnumerable<Note>> GetTrashNotes(int userId)
        {
            return await _noteDL.GetTrashNotes(userId);
        }

        public async Task<bool> RestoreNote(int noteId, int userId)
        {
            var result = await _noteDL.RestoreNote(noteId, userId);
            await _cacheService.RemoveData($"notes_{userId}");
            return result;
        }

        public async Task<bool> DeletePermanently(int noteId, int userId)
        {
            var result = await _noteDL.DeletePermanently(noteId, userId);
            await _cacheService.RemoveData($"notes_{userId}");
            return result;
        }

        public async Task<Note> GetNoteById(int noteId, int userId)
        {
            var note = await _noteDL.GetNoteById(noteId, userId);

            if (note == null)
                throw new Exception("Note not found");

            return note;
        }

        public async Task<bool> UpdateNote(int noteId, int userId, UpdateNoteDto dto)
        {
            var result = await _noteDL.UpdateNote(noteId, userId, dto);
            await _cacheService.RemoveData($"notes_{userId}");
            return result;
        }

        public async Task<bool> ArchiveNote(int noteId, int userId)
        {
            var result = await _noteDL.ArchiveNote(noteId, userId);
            await _cacheService.RemoveData($"notes_{userId}");
            return result;
        }

        public async Task<bool> UnarchiveNote(int noteId, int userId)
        {
            var result = await _noteDL.UnarchiveNote(noteId, userId);
            await _cacheService.RemoveData($"notes_{userId}");
            return result;
        }

        public async Task<IEnumerable<Note>> GetArchivedNotes(int userId)
        {
            return await _noteDL.GetArchivedNotes(userId);
        }

        public async Task<bool> PinNote(int noteId, int userId)
        {
            var result = await _noteDL.PinNote(noteId, userId);
            await _cacheService.RemoveData($"notes_{userId}");
            return result;
        }

        public async Task<bool> UnpinNote(int noteId, int userId)
        {
            var result = await _noteDL.UnpinNote(noteId, userId);
            await _cacheService.RemoveData($"notes_{userId}");
            return result;
        }

        public async Task<bool> ChangeColor(int noteId, int userId, string colour)
        {
            var result = await _noteDL.ChangeColor(noteId, userId, colour);
            await _cacheService.RemoveData($"notes_{userId}");
            return result;
        }

        public async Task<bool> AddLabelToNote(int noteId, int labelId)
        {
            return await _noteDL.AddLabelToNote(noteId, labelId);
        }

        public async Task<bool> RemoveLabelFromNote(int noteId, int labelId)
        {
            return await _noteDL.RemoveLabelFromNote(noteId, labelId);
        }

        public async Task<IEnumerable<Note>> GetNotesByLabel(int labelId)
        {
            return await _noteDL.GetNotesByLabel(labelId);
        }
    }
}