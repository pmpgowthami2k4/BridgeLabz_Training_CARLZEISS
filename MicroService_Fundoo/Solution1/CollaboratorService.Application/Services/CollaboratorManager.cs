using CollaboratorService.Application.Interfaces;
using CollaboratorService.Domain.Entities;

namespace CollaboratorService.Application.Services
{
    public class CollaboratorManager
    {
        private readonly ICollaboratorRepository _repo;

        public CollaboratorManager(ICollaboratorRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> AddAsync(Collaborator collaborator)
        {
            collaborator.CreatedAt = DateTime.UtcNow;
            return await _repo.AddAsync(collaborator);
        }

        public async Task<IEnumerable<Collaborator>> GetByNoteIdAsync(int noteId)
        {
            return await _repo.GetByNoteIdAsync(noteId);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }
    }
}