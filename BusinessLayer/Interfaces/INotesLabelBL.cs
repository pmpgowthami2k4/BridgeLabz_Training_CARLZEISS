using System.Collections.Generic;
using System.Threading.Tasks;
using ModelLayer.DTOs;
using ModelLayer.Entities;


namespace BusinessLayer.Interfaces
{
    public interface INotesLabelBL
    {
        bool AddLabel(AddLabelToNoteDTO dto);
        bool RemoveLabel(AddLabelToNoteDTO dto);
        List<Label> GetLabels(int notesId);
    }
}
