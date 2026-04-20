using LabelService.Domain.Entities;
using LabelService.Application.DTOs;

namespace LabelService.Application.Interfaces
{
    public interface INoteLabelRepository
    {
        Task<int> AddAsync(NoteLabel model);
        Task<IEnumerable<NoteLabelResponseDto>> GetByNoteIdAsync(int noteId);
        Task<int> DeleteAsync(int id);
    }
}