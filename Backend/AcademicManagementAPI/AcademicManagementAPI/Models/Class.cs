using System.ComponentModel.DataAnnotations;

namespace AcademicManagementAPI.Models
{
    public class Class
    {
        [Key]
        public string ClassID { get; set; } = null!;

        public string? Program { get; set; }
        public string? Year { get; set; }
        public string? Section { get; set; }
        public int Semester { get; set; }
    }
}
