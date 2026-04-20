namespace LabelService.Domain.Entities
{
    public class Label
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
