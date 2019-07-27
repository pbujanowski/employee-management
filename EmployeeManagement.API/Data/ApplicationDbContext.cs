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
        public DbSet<Duty> Duties { get; set; }

        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<EmployeeManagement.Core.Models.Employee> Employee { get; set; }
    }
}
