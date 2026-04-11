using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.DTOs
{
    public class ReminderDTO
    {
        public int NotesId { get; set; }
        public DateTime DateTime { get; set; }
        public string Status { get; set; }
    }
}
