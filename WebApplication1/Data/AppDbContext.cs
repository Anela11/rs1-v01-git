using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Student> Studenti => Set<Student>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().HasData(

                new Student()
                {
                    Id = 1,
                    Ime = "Anela",
                    Prezime = "Hafizovic",
                    BrojIndeksa = "IB220302",
                    DatumRodjenja = new DateOnly(1998, 3, 15),
                    DatumKreiranja = new DateTime(2026, 11, 18)
                },
                 new Student()
                 {
                     Id = 2,
                     Ime = "Amar",
                     Prezime = "Eminovic",
                     BrojIndeksa = "IB220306",
                     DatumRodjenja = null,
                     DatumKreiranja = new DateTime(2026, 11, 18)
                 }

                );
        }
    }
}