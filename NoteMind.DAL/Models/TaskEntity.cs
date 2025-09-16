namespace NoteMind.DAL.Models
{
    public class TaskEntity : Model
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public DateTime? Deadline { get; set; }
        public int Status { get; set; }
        public int Priority { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public int Order { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}