using AcademicManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Xml;

namespace AcademicManagementAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<TeachingAssignment> TeachingAssignments { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Marks> Marks { get; set; }
        public DbSet<Timetable> Timetables { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
