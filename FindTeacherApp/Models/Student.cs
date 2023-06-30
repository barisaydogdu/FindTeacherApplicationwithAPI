using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FindTeacherApp.Models
{
    public class Student
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public EducationLevel EducationLevel { get; set; }
        public string Subject{ get; set; }
        public string SpecialRequests { get; set; }
    }

    public enum EducationLevel
    {
        PrimarySchool,
        MiddleSchool,
        HighSchool,
        University
    }
}

