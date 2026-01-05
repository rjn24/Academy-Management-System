using System.ComponentModel.DataAnnotations;

namespace AcademicManagementAPI.Models
{
    public class Timetable
    {
        [Key]
        public int TimetableID { get; set; }

        public string? ClassID { get; set; }
        public string? CourseCode { get; set; }
        public string? DayOfWeek { get; set; }
        public string? TimeSlot { get; set; }
    }
}
