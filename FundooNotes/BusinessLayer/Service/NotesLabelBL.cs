using BusinessLayer.Interfaces;
using DataBaseLayer.Interfaces;
using ModelLayer.DTOs;
using ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class NotesLabelBL : INotesLabelBL
    {
        private readonly INotesLabelDL dl;

        public NotesLabelBL(INotesLabelDL dl)
        {
            this.dl = dl;
        }

        public bool AddLabel(AddLabelToNoteDTO dto)
            => dl.AddLabelToNote(dto.NotesId, dto.LabelId);

        public bool RemoveLabel(AddLabelToNoteDTO dto)
            => dl.RemoveLabelFromNote(dto.NotesId, dto.LabelId);

        public List<Label> GetLabels(int notesId)
            => dl.GetLabelsByNote(notesId);
    }
}
