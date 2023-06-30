using FindTeacherAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FindTeacherAPI.Data
{
    public class FindTeacherAPIDbContext:DbContext
    {
        public FindTeacherAPIDbContext(DbContextOptions options):base(options)
        {

        }
       
        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teacher{ get; set; }
        public DbSet<Advert> Advert{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Model konfigürasyonları ve diğer ayarlamalar burada yapılır
            // Örneğin, Experience sınıfının birincil anahtarını tanımlama:
            modelBuilder.Entity<Experience>()
                .HasKey(e => e.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
