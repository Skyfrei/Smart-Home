using System.ComponentModel.DataAnnotations;
using PrivilegeService.Models;

namespace PrivilegeService.Dto
{
    public class PrivilegeCreateDto
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public Role UserRole = Role.User; 
    }
}