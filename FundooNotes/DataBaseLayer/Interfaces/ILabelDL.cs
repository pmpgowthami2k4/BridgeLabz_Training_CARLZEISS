//using ModelLayer.Entities;

//namespace DataBaseLayer.Interfaces
//{
//    public interface ILabelDL
//    {
//        Task<int> CreateLabel(string name, int userId);
//        Task<IEnumerable<Label>> GetLabels(int userId);
//        Task<bool> UpdateLabel(int labelId, int userId, string name);
//        Task<bool> DeleteLabel(int labelId, int userId);
//    }
//}

//===================================================================================================
//MONGO SETUP
using ModelLayer.Entities;

namespace DataBaseLayer.Interfaces
{
    public interface ILabelDL
    {
        Task<int> CreateLabel(string name, string userId);
        Task<IEnumerable<Label>> GetLabels(string userId);
        Task<bool> UpdateLabel(string labelName, string userId, string newName);
        Task<bool> DeleteLabel(string labelName, string userId);
    }
}