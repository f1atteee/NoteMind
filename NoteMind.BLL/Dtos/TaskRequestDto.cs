namespace NoteMind.BLL.Dtos
{
    public class TaskRequestDto
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public DateTime? Deadline { get; set; }

        public int Status { get; set; }
        public int Priority { get; set; }
    }
}