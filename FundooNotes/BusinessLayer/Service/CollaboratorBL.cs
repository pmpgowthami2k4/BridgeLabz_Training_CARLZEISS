using BusinessLayer.Interfaces;
using DataBaseLayer.Interfaces;
using ModelLayer.Entities;

namespace BusinessLayer.Service
{
    public class CollaboratorBL : ICollaboratorBL
    {
        private readonly INoteDL _noteDL;

        public CollaboratorBL(INoteDL noteDL)
        {
            _noteDL = noteDL;
        }

        public async Task<bool> AddCollaborator(string noteId, string userId, string email)
        {
            return await _noteDL.AddCollaborator(noteId, userId, email);
        }

        public async Task<List<string>> GetCollaborators(string noteId)
        {
            var note = await _noteDL.GetNoteById(noteId, null);
            return note?.Collaborators ?? new List<string>();
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