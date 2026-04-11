using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.Entities
{
    public class NotesLabels
    {
        public int Id { get; set; }
        public int NotesId { get; set; }
        public int LabelId { get; set; }
    }
}
