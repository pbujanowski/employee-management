using EmployeeManagement.API.Data;
using EmployeeManagement.Core.Models;
using EmployeeManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public async Task<bool> AddOneAsync(Employee item)
        {
            await Task.Run(() =>
            {
                context.Employees.Add(item);
                context.SaveChangesAsync();
            });
            
            return true;
        }

        public async Task<bool> DeleteOneAsync(Employee item)
        {
            await Task.Run(() =>
            {
                context.Employees.Remove(item);
                context.SaveChangesAsync();
            });

            return true;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await Task.FromResult(context.Employees.ToList()).ConfigureAwait(false);
        }

        public async Task<Employee> GetOneByIdAsync(int id)
        {
            return await Task.FromResult(context.Employees.Where(e => e.Id == id).FirstOrDefault());
        }

        public async Task<bool> UpdateOneAsync(Employee item)
        {
            await Task.Run(() =>
            {
                context.Employees.Update(item);
                context.SaveChanges();
            });

            return true;
        }
    }
}
