using System.ComponentModel.DataAnnotations;

namespace AcademicManagementAPI.Models
{
    public class Professor
    {
        [Key]
        public int ProfessorID { get; set; }

        public string? Name { get; set; }
        public string? Department { get; set; }
    }
}
