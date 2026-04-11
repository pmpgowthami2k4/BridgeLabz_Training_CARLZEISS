using ModelLayer.Entities;

namespace BusinessLayer.Interfaces
{
    public interface ICollaboratorBL
    {
        Task<bool> AddCollaborator(int noteId, int userId, string email);
        Task<IEnumerable<Collaborator>> GetCollaborators(int noteId);
        Task<bool> RemoveCollaborator(int noteId, string email);
        Task<IEnumerable<Note>> GetSharedNotes(string email);
    }
}
