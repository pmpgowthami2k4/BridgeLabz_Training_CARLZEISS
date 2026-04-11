using BusinessLayer.Interfaces;
using DataBaseLayer.Interfaces;
using ModelLayer.Entities;

public class CollaboratorBL : ICollaboratorBL
{
    private readonly ICollaboratorDL _collabDL;

    public CollaboratorBL(ICollaboratorDL collabDL)
    {
        _collabDL = collabDL;
    }

    public async Task<bool> AddCollaborator(int noteId, int userId, string email)
    {
        return await _collabDL.AddCollaborator(noteId, userId, email);
    }

    public async Task<IEnumerable<Collaborator>> GetCollaborators(int noteId)
    {
        return await _collabDL.GetCollaborators(noteId);
    }

    public async Task<bool> RemoveCollaborator(int noteId, string email)
    {
        return await _collabDL.RemoveCollaborator(noteId, email);
    }

    public async Task<IEnumerable<Note>> GetSharedNotes(string email)
    {
        return await _collabDL.GetSharedNotes(email);
    }
}