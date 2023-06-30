using System.ComponentModel.DataAnnotations;

namespace FindTeacherAPI.Models
{
    public class Teacher
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public string Specializations { get; set; }

        public string Subjects { get; set; }
        public List<Experience> Experiences { get; set; }
        public decimal HourlyRate { get; set; }
    }
    public class Experience
    {

        [Key]
        public Guid Id { get; set; }
        public string Institution { get; set; }
        public string Position { get; set; }
        public int YearsOfExperience { get; set; }
    }
}
