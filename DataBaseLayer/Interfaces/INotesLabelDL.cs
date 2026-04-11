using System.Collections.Generic;
using System.Threading.Tasks;
using ModelLayer.Entities;
namespace DataBaseLayer.Interfaces
{
    public interface INotesLabelDL
    {
        bool AddLabelToNote(int notesId, int labelId);
        bool RemoveLabelFromNote(int notesId, int labelId);
        List<Label> GetLabelsByNote(int notesId);
    }
}
