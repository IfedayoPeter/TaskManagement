using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagement.Domain.Model
{
    public class Notification
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string UserCode { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
    }
}