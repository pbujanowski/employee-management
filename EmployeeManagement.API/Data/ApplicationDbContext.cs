using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Core.Models;

namespace EmployeeManagement.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

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
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Duty> Duties { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<Report> Reports { get; set; }

        public DbSet<ReportTemplate> ReportTemplates { get; set; }

        public DbSet<ScheduleEntry> ScheduleEntries { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
