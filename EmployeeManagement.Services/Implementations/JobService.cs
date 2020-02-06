using EmployeeManagement.Core.Constants;
using EmployeeManagement.Core.Helpers;
using EmployeeManagement.Core.Models;
using EmployeeManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Services.Implementations
{
    public class JobService : IJobService<Job>
    {
        public Task<bool> AddOneAsync(Job item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOneAsync(Job item)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Job>> GetAllAsync()
        {
            return await HttpHelper.DoGetRequestAsync<List<Job>>(HttpUrls.JobPath)
                .ConfigureAwait(false);
        }

        public Task<Job> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateOneAsync(Job item)
        {
            throw new NotImplementedException();
        }
    }
}