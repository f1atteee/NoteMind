using NoteMind.BLL.Enums;
using TaskStatus = NoteMind.BLL.Enums.TaskStatus;

namespace NoteMind.BLL.Dtos
{
    public class TaskDto : BaseDto
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public DateTime? Deadline { get; set; }

        public TaskStatus Status { get; set; }
        public TaskPriority Priority { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
