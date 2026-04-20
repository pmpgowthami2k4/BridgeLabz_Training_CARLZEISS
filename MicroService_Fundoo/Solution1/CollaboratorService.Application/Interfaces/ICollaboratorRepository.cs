using CollaboratorService.Domain.Entities;

namespace CollaboratorService.Application.Interfaces
{
    public interface ICollaboratorRepository
    {
        Task<int> AddAsync(Collaborator collaborator);
        Task<IEnumerable<Collaborator>> GetByNoteIdAsync(int noteId);
        Task<int> DeleteAsync(int id);
    }
}
