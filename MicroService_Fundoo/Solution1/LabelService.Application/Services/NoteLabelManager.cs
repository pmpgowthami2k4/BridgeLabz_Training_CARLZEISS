using LabelService.Application.DTOs;
using LabelService.Application.Interfaces;
using LabelService.Domain.Entities;
using LabelService.Application.DTOs;

namespace LabelService.Application.Services
{
    public class NoteLabelManager
    {
        private readonly INoteLabelRepository _repo;

        public NoteLabelManager(INoteLabelRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> AddAsync(NoteLabel model)
        {
            return await _repo.AddAsync(model);
        }

        public async Task<IEnumerable<NoteLabelResponseDto>> GetByNoteIdAsync(int noteId)
        {
            return await _repo.GetByNoteIdAsync(noteId);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }
    }
}