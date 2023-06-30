using System.ComponentModel.DataAnnotations;

namespace FindTeacherApp.Models
{
    public class StudentData
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public EducationLevelMap EducationLevel { get; set; }
        public string Subject { get; set; }
        public string SpecialRequests { get; set; }
    }

    public enum EducationLevelMap
    {
        PrimarySchool,
        MiddleSchool,
        HighSchool,
        University
    }
}