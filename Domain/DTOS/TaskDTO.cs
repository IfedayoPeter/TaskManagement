namespace TaskManagement.Domain.DTOS
{
    public class TaskDTO
    {      
        public string TaskCode { get; set; }
       
        public string Title { get; set; }
        
        public string Description { get; set; }

        // Status of the task (Pending, In Progress, Completed)        
        public string Status { get; set; }

        // Priority level of the task (Low, Medium, High)       
        public string Priority { get; set; }

        public DateTime CreatedDate { get; set; }
       
        public DateTime DueDate { get; set; }

        // Identifier of the user who created the task
        public Guid CreatedBy { get; set; }

        // Identifier of the user to whom the task is assigned
        
        public Guid AssignedTo { get; set; }

        public string Comments { get; set; }
    }
}