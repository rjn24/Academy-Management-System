using System.ComponentModel.DataAnnotations;

namespace AcademicManagementAPI.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }

        public string? Name { get; set; }
        public string? Program { get; set; }
        public string? Year { get; set; }
        public string? ClassID { get; set; }
    }
}
