using EmployeeManagement.API.Data;
using EmployeeManagement.Core.Models;
using EmployeeManagement.Core.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.API.Services
{
    public class DutyService : ServiceBase, IDutyService<Duty>
    {
        public DutyService(ApplicationDbContext context)
            : base(context)
        {
        }

        private List<Duty> ExampleDuties =>
           new List<Duty>
           {
                new Duty
                {
                    Id = 1, Description = "Przykładowe zadanie nr 1", OrderDate = DateTime.Now, ExecutiveEmployeeId = 1,
                    ExecutiveEmployee = new Employee
                    {
                        Id = 1, FirstName = "Jan", LastName = "Kowalski", Job = "dyrektor", ExperienceYears = 20, Salary = 10000
                    }
                }
           };

        public Task<bool> AddOneAsync(Duty item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOneAsync(Duty item)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Duty>> GetAllAsync()
        {
            return await Task.FromResult(ExampleDuties).ConfigureAwait(false);
        }

        public Task<List<Duty>> GetAllByEmployeeIdAsync(int employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<Duty> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateOneAsync(Duty item)
        {
            throw new NotImplementedException();
        }
    }
}
