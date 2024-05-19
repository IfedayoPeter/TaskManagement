using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Domain.Model
{
    public class Login
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}