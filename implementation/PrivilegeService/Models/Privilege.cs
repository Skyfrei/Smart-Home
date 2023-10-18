using System.ComponentModel.DataAnnotations;

namespace PrivilegeService.Models
{
    public class Privilege
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
        public string Username { get; set; }

        public string Password { get; set; }
    }
    
    public enum Role
    {
        User,
        Maintainer
    };
}