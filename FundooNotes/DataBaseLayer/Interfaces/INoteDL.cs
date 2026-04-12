//using System.Collections.Generic;
//using System.Threading.Tasks;
//using ModelLayer.Entities;

//namespace DataBaseLayer.Interfaces
//{

//    public interface INoteDL
//    {
//        Task<int> CreateNote(Note note);
//        Task<IEnumerable<Note>> GetAllNotes(int userId);
//        Task<bool> MoveToTrash(int noteId, int userId);
//        Task<IEnumerable<Note>> GetTrashNotes(int userId);
//        Task<bool> RestoreNote(int noteId, int userId);
//        Task<bool> DeletePermanently(int noteId, int userId);
//        Task<Note> GetNoteById(int noteId, int userId);
//        Task<bool> UpdateNote(int noteId, int userId, UpdateNoteDto dto);
//        Task<bool> ArchiveNote(int noteId, int userId);
//        Task<bool> UnarchiveNote(int noteId, int userId);
//        Task<IEnumerable<Note>> GetArchivedNotes(int userId);
//        Task<bool> PinNote(int noteId, int userId);
//        Task<bool> UnpinNote(int noteId, int userId);
//        Task<bool> ChangeColor(int noteId, int userId, string colour);
//        Task<bool> AddLabelToNote(int noteId, int labelId);
//        Task<bool> RemoveLabelFromNote(int noteId, int labelId);
//        Task<IEnumerable<Note>> GetNotesByLabel(int labelId);

//    }
//}

//===================================================================================================
//MONGO SETUP

using System.Collections.Generic;
using System.Threading.Tasks;
using ModelLayer.Entities;
using ModelLayer.DTOs;

namespace DataBaseLayer.Interfaces
{
    public interface INoteDL
    {
        Task<int> CreateNote(Note note);

        Task<IEnumerable<Note>> GetAllNotes(string userId);
        Task<Note> GetNoteById(string noteId, string userId);

        Task<bool> MoveToTrash(string noteId, string userId);
        Task<bool> RestoreNote(string noteId, string userId);
        Task<bool> DeletePermanently(string noteId, string userId);

        Task<bool> UpdateNote(string noteId, string userId, UpdateNoteDto dto);

        Task<bool> ArchiveNote(string noteId, string userId);
        Task<bool> UnarchiveNote(string noteId, string userId);

        Task<IEnumerable<Note>> GetArchivedNotes(string userId);
        Task<IEnumerable<Note>> GetTrashNotes(string userId);

        Task<bool> PinNote(string noteId, string userId);
        Task<bool> UnpinNote(string noteId, string userId);

        Task<bool> ChangeColor(string noteId, string userId, string colour);

        // Mongo-friendly label handling 
        Task<bool> AddLabelToNote(string noteId, string labelName);
        Task<bool> RemoveLabelFromNote(string noteId, string labelName);

        Task<IEnumerable<Note>> GetNotesByLabel(string labelName);
        Task<bool> SetReminder(string noteId, string userId, DateTime reminder);
        Task<bool> RemoveReminder(string noteId, string userId);
        Task<IEnumerable<Note>> GetReminderNotes(string userId);
        Task<bool> AddCollaborator(string noteId, string userId, string email);
        Task<bool> RemoveCollaborator(string noteId, string userId, string email);
        Task<IEnumerable<Note>> GetSharedNotes(string email);
    }
}