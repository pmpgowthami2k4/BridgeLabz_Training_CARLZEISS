using System;
using System.Collections.Generic;
using System.Text;

namespace CollaboratorService.Application.DTOs
{
    public class AddCollaboratorDto
    {
        public int NoteId { get; set; }
        public string CollaboratorEmail { get; set; }
    }
}
