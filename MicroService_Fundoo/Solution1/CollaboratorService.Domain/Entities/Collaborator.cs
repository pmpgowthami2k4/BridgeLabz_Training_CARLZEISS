namespace CollaboratorService.Domain.Entities
{
    public class Collaborator
    {
        public int Id { get; set; }
        public int NoteId { get; set; }
        public string OwnerUserId { get; set; }
        public string CollaboratorEmail { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}