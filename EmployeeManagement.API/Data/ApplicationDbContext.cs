using EmployeeManagement.API.Models;
using EmployeeManagement.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Duty> Duties { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<Report> Reports { get; set; }

        public DbSet<ReportTemplate> ReportTemplates { get; set; }

        public DbSet<ScheduleEntry> ScheduleEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new City
                {
                    Id = 1,
                    Name = "Gliwice"
                });

            modelBuilder.Entity<Job>().HasData(
                new Job
                {
                    Id = 1,
                    Name = "Pracownik szeregowy"
                });

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    CityId = 1,
                    JobId = 1
                },
                new Employee
                {
                    Id = 2,
                    FirstName = "Janina",
                    LastName = "Kowalska",
                    CityId = 1,
                    JobId = 1
                });

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    EmployeeId = 1,
                    Username = "jkowalski",
                    Password = "test123",
                    Role = Roles.Administrator
                },
                new User
                {
                    Id = 2,
                    EmployeeId = 2,
                    Username = "jkowalska",
                    Password = "test123",
                    Role = Roles.User
                });

            modelBuilder.Entity<Duty>().HasData(
                new Duty
                {
                    Id = 1,
                    Description = "Zadanie nr 1",
                    ExecutiveEmployeeId = 1,
                });

            modelBuilder.Entity<Duty>().HasData(
                new Duty
                {
                    Id = 2,
                    Description = "Zadanie nr 2",
                    ExecutiveEmployeeId = 1,
                });
        }
    }
}