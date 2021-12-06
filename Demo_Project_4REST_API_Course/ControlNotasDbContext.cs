using Demo_Project_4REST_API_Course.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo_Project_4REST_API_Course
{
    public class ControlNotasDbContext : DbContext
    {
        public ControlNotasDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<CycleEntity> Cycles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseEntity>()
                .HasOne(c => c.Ciclo)
                .WithMany(c => c.Cursos);

            base.OnModelCreating(modelBuilder); 
        }
    }
}
