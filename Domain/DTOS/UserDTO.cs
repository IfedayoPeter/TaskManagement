namespace TaskManagement.Domain.DTOS
{
    public class UserDTO
    {
        public long UserId {get; set;}

        public string UserCode {get; set;}

        public string FullName {get; set;}

        public string Email {get; set;}

        public string Password {get; set;}
    }
}