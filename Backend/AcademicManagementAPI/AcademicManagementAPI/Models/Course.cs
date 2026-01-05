using System.ComponentModel.DataAnnotations;

namespace AcademicManagementAPI.Models
{
    public class Course
    {
        [Key]
        public string CourseCode { get; set; } = null!;

        public string? SubjectName { get; set; }
        public int Semester { get; set; }
        public int Credits { get; set; }
    }
}
