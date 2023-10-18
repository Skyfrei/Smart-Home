using System.ComponentModel.DataAnnotations;

namespace ApiGateway.Dto
{
    public class UserReadDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public Role UserRole { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }

    public class Login
    {
        public Login(string username, string password)
        {
            Username = username;
            Password = password;
        }
        public string Username { get; set; }

        public string Password { get; set; }
    }

    public class ChangeIds
    {
        public int Id { get; set; }

        public int SmartDeviceId { get; set; }
        
        public string Name { get; set; }
    }

    public enum Role
    {
        User,
        Maintainer
    };
}