using EmployeeManagement.API.Data;
using EmployeeManagement.Core.Models;
using EmployeeManagement.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.API.Services
{
    public class EmployeeService : ServiceBase, IEmployeeService<Employee>
    {
        public EmployeeService(ApplicationDbContext context)
            : base(context)
        {
        }

        private List<Employee> ExampleEmployees =>
            new List<Employee>
            {
                new Employee{ Id = 1, FirstName = "Jan", LastName = "Kowalski", Job = "dyrektor", Salary = 10000, ExperienceYears = 20 },
                new Employee{ Id = 2, FirstName = "Zbigniew", LastName = "Malinowski", Job = "kierownik", Salary = 3000, ExperienceYears = 10 }
            };

        public Task<bool> AddOneAsync(Employee item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOneAsync(Employee item)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await Task.FromResult(ExampleEmployees).ConfigureAwait(false);
        }

        public Task<List<string>> GetAllJobsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateOneAsync(Employee item)
        {
            throw new NotImplementedException();
        }
    }
}
