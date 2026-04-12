using ModelLayer.Entities;

namespace BusinessLayer.Interfaces
{
    public interface ICollaboratorBL
    {
        Task<bool> AddCollaborator(string noteId, string userId, string email);
        Task<List<string>> GetCollaborators(string noteId);
        Task<bool> RemoveCollaborator(string noteId, string userId, string email);
        Task<IEnumerable<Note>> GetSharedNotes(string email);
    }
}
