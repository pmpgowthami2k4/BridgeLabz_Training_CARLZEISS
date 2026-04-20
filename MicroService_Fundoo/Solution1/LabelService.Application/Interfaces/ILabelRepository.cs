using LabelService.Domain.Entities;

namespace LabelService.Application.Interfaces
{
    public interface ILabelRepository
    {
        Task<int> AddAsync(Label label);
        Task<IEnumerable<Label>> GetByUserIdAsync(string userId);
        Task<int> DeleteAsync(int id);
    }
}