namespace LabelService.Application.DTOs
{
    public class NoteLabelResponseDto
    {
        public int MappingId { get; set; }
        public int NoteId { get; set; }
        public int LabelId { get; set; }
        public string LabelName { get; set; }
    }
}