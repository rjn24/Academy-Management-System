using System.ComponentModel.DataAnnotations;

namespace AcademicManagementAPI.Models
{
    public class Attendance
    {
        [Key]
        public int AttendanceID { get; set; }

        public int StudentID { get; set; }
        public string? CourseCode { get; set; }
        public DateTime Date { get; set; }
        public string? Status { get; set; }
    }
}
