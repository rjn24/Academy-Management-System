using System.ComponentModel.DataAnnotations;

namespace AcademicManagementAPI.Models
{
    public class TeachingAssignment
    {
        [Key]
        public int AssignmentID { get; set; }

        public int ProfessorID { get; set; }
        public string? CourseCode { get; set; }
        public string? ClassID { get; set; }
        public string? AcademicYear { get; set; }
    }
}
