using System;
namespace ModelLayer.DTOs { 
public class CreateNoteDto
{
    public string Title { get; set; }

    public string Description { get; set; }

    public DateTime? Reminder { get; set; }
}
}