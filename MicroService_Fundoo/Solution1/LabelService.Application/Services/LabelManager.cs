using LabelService.Application.Interfaces;
using LabelService.Domain.Entities;

namespace LabelService.Application.Services
{
    public class LabelManager
    {
        private readonly ILabelRepository _repo;

        public LabelManager(ILabelRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> AddAsync(Label label)
        {
            label.CreatedAt = DateTime.UtcNow;
            return await _repo.AddAsync(label);
        }

        public async Task<IEnumerable<Label>> GetByUserIdAsync(string userId)
        {
            return await _repo.GetByUserIdAsync(userId);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }
    }
}
