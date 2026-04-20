using NotesService.Domain.Entities;

namespace NotesService.Application.Interfaces
{
    public interface INoteRepository
    {
        Task<string> AddAsync(Note note);

        Task<List<Note>> GetByUserIdAsync(string userId);

        Task<bool> UpdateAsync(
            string id,
            string userId,
            string title,
            string content
        );

        Task<bool> DeleteAsync(
            string id,
            string userId
        );
    }
}
