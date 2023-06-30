using System.ComponentModel.DataAnnotations;

namespace FindTeacherAPI.Models
{
    public class Advert
    {
        [Key]
        public Guid Id { get; set; }
        public Guid TeacherId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Subjects { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal DesiredRate { get; set; }
        public AdvertisementStatus Status { get; set; }
    }
    public enum AdvertisementStatus
    {
        Active,
        Inactive,
        Completed
    }
}
