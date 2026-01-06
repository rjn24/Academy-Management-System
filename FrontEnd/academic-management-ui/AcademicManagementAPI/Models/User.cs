using System.ComponentModel.DataAnnotations;

namespace AcademicManagementAPI.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        public string? Username { get; set; }
        public string? PasswordHash { get; set; }
        public string? Role { get; set; }
    }
}
