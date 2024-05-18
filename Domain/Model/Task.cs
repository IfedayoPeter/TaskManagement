using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Domain.Model
{
    public class Task
    {
        [Key]
        public string TaskCode { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        // Status of the task (Pending, In Progress, Completed)
        [Required]
        public string Status { get; set; }

        // Priority level of the task (Low, Medium, High)
        [Required]
        public string Priority { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        // Identifier of the user who created the task
        public Guid CreatedBy { get; set; }

        // Identifier of the user to whom the task is assigned
        [Required]
        public Guid AssignedTo { get; set; }

        public string Comments { get; set; }
    }
}