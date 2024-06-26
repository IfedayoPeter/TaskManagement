using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskManagement.Service.Helpers;

namespace TaskManagement.Domain.Model
{
    public class TaskModel : AuditableEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long TaskId { get; set; }

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

        public DateTime CreatedOn { get; set; }

        // Identifier of the user who created the task
        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        // Identifier of the user to whom the task is assigned
        public string AssignedTo { get; set; }

        public string Comments { get; set; }
    }
}