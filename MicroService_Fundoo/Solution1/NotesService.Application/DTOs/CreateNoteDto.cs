namespace NotesService.Application.DTOs;

public record CreateNoteDto(
    string Title,
    string Content
);
