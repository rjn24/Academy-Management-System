using System.ComponentModel.DataAnnotations;

namespace AcademicManagementAPI.Models
{
    public class Marks
    {
        [Key]
        public int MarksID { get; set; }

        public int StudentID { get; set; }
        public string? CourseCode { get; set; }
        public int InternalMarks { get; set; }
        public int ExternalMarks { get; set; }
        public string? Grade { get; set; }
    }
}
