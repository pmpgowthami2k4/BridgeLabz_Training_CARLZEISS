using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.DTOs
{
    public class AddLabelToNoteDTO
    {
        public int NotesId { get; set; }
        public int LabelId { get; set; }
    }
    
}
