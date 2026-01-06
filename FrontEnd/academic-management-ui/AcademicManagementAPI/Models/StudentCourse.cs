using System.ComponentModel.DataAnnotations;

namespace AcademicManagementAPI.Models
{
    public class StudentCourse
    {
        [Key]
        public int ID { get; set; }

        public int StudentID { get; set; }
        public string? CourseCode { get; set; }
        public string? AcademicYear { get; set; }
    }
}
