//using BusinessLayer.Interfaces;
//using DataBaseLayer.Interfaces;
//using ModelLayer.Entities;

//namespace BusinessLayer.Service
//{
//    public class LabelBL : ILabelBL
//    {
//        private readonly ILabelDL _labelDL;

//        public LabelBL(ILabelDL labelDL)
//        {
//            _labelDL = labelDL;
//        }

//        public async Task<int> CreateLabel(string name, int userId)
//        {
//            return await _labelDL.CreateLabel(name, userId);
//        }

//        public async Task<IEnumerable<Label>> GetLabels(int userId)
//        {
//            return await _labelDL.GetLabels(userId);
//        }

//        public async Task<bool> UpdateLabel(int labelId, int userId, string name)
//        {
//            return await _labelDL.UpdateLabel(labelId, userId, name);
//        }

//        public async Task<bool> DeleteLabel(int labelId, int userId)
//        {
//            return await _labelDL.DeleteLabel(labelId, userId);
//        }
//    }
//}


//===================================================================================================
//MONGO SETUP
using BusinessLayer.Interfaces;
using DataBaseLayer.Interfaces;
using ModelLayer.Entities;

namespace BusinessLayer.Service
{
    public class LabelBL : ILabelBL
    {
        private readonly ILabelDL _labelDL;

        public LabelBL(ILabelDL labelDL)
        {
            _labelDL = labelDL;
        }

        public async Task<int> CreateLabel(string name, string userId)
        {
            return await _labelDL.CreateLabel(name, userId);
        }

        public async Task<IEnumerable<Label>> GetLabels(string userId)
        {
            return await _labelDL.GetLabels(userId);
        }

        public async Task<bool> UpdateLabel(string labelName, string userId, string newName)
        {
            return await _labelDL.UpdateLabel(labelName, userId, newName);
        }

        public async Task<bool> DeleteLabel(string labelName, string userId)
        {
            return await _labelDL.DeleteLabel(labelName, userId);
        }
    }
}