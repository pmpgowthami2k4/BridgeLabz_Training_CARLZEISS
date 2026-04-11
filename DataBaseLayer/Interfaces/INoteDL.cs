using System.Collections.Generic;
using System.Threading.Tasks;
using ModelLayer.Entities;

namespace DataBaseLayer.Interfaces
{

    public interface INoteDL
    {
        Task<int> CreateNote(Note note);
        Task<IEnumerable<Note>> GetAllNotes(int userId);

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
