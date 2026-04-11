using ModelLayer.Entities;

namespace BusinessLayer.Interfaces
{
    public interface ILabelBL
    {
        Task<int> CreateLabel(string name, int userId);
        Task<IEnumerable<Label>> GetLabels(int userId);
        Task<bool> UpdateLabel(int labelId, int userId, string name);
        Task<bool> DeleteLabel(int labelId, int userId);
    }
}
