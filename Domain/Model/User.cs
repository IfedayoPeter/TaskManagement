using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagement.Domain.Model
{
    public class User 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserId {get; set;}
        
        public string UserCode {get; set;}

        [Required]
        public string FullName {get; set;}

        [Required]
        public string Email {get; set;}

        [Required]
        public string Password {get; set;}
    }
}