using EmployeeManagement.API.Data;
using EmployeeManagement.Core.Models;
using EmployeeManagement.Services.Interfaces;
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

        public async Task<bool> AddOneAsync(Duty item)
        {
            await Task.Run(() =>
            {
                dbContext.Duties.Add(item);
                dbContext.SaveChangesAsync();
            });

            return true;
        }

        public async Task<bool> DeleteOneAsync(Duty item)
        {
            await Task.Run(() =>
            {
                dbContext.Duties.Remove(item);
                dbContext.SaveChangesAsync();
            });

            return true;
        }

        public async Task<List<Duty>> GetAllAsync()
        {
            return await Task.FromResult(dbContext.Duties.ToList()).ConfigureAwait(false);
        }

        public async Task<List<Duty>> GetAllByEmployeeIdAsync(int employeeId)
        {
            return await Task.FromResult(dbContext.Duties.Where(d => d.ExecutiveEmployeeId == employeeId).Select(d => d).ToList());
        }

        public async Task<Duty> GetOneByIdAsync(int id)
        {
            return await Task.FromResult(dbContext.Duties.Where(d => d.Id == id).FirstOrDefault());
        }

        public async Task<bool> UpdateOneAsync(Duty item)
        {
            await Task.Run(() =>
            {
                dbContext.Duties.Update(item);
                dbContext.SaveChangesAsync();
            });

            return true;
        }
    }
}