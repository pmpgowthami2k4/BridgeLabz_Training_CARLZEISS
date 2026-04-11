using ModelLayer.DTOs;
using ModelLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface INoteBL
    {
        Task<int> CreateNote(CreateNoteDto dto, int userId);
        Task<IEnumerable<Note>> GetNotes(int userId);
        Task<bool> MoveToTrash(int noteId, int userId);
        Task<IEnumerable<Note>> GetTrashNotes(int userId);
        Task<bool> RestoreNote(int noteId, int userId);
        Task<bool> DeletePermanently(int noteId, int userId);
        Task<Note> GetNoteById(int noteId, int userId);
        Task<bool> UpdateNote(int noteId, int userId, UpdateNoteDto dto);
        Task<bool> ArchiveNote(int noteId, int userId);
        Task<bool> UnarchiveNote(int noteId, int userId);
        Task<IEnumerable<Note>> GetArchivedNotes(int userId);
        Task<bool> PinNote(int noteId, int userId);
        Task<bool> UnpinNote(int noteId, int userId);
        Task<bool> ChangeColor(int noteId, int userId, string colour);

        Task<bool> AddLabelToNote(int noteId, int labelId);
        Task<bool> RemoveLabelFromNote(int noteId, int labelId);
        Task<IEnumerable<Note>> GetNotesByLabel(int labelId);

    }
}