using EmployeeManagement.Core.Models;
using EmployeeManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Services.Implementations
{
    public class ScheduleService : IScheduleService<ScheduleEntry>
    {
        public Task<bool> AddOneAsync(ScheduleEntry item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOneAsync(ScheduleEntry item)
        {
            throw new NotImplementedException();
        }

        public Task<List<ScheduleEntry>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ScheduleEntry> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateOneAsync(ScheduleEntry item)
        {
            throw new NotImplementedException();
        }
    }
}
