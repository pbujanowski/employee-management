using EmployeeManagement.Core.Constants;
using EmployeeManagement.Core.Helpers;
using EmployeeManagement.Core.Models;
using EmployeeManagement.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Services.Implementations
{
    public class DutyService : IDutyService<Duty>
    {
        public async Task<bool> AddOneAsync(Duty item)
        {
            return await HttpHelper.DoPostRequestAsync(HttpUrls.DutyPath, item)
                .ConfigureAwait(false);
        }

        public async Task<bool> DeleteOneAsync(Duty item)
        {
            return await HttpHelper.DoDeleteRequestAsync(HttpUrls.DutyPath, item.Id)
                .ConfigureAwait(false);
        }

        public async Task<List<Duty>> GetAllAsync()
        {
            return await HttpHelper.DoGetRequestAsync<List<Duty>>(HttpUrls.DutyPath)
                .ConfigureAwait(false);
        }

        public async Task<List<Duty>> GetAllByEmployeeIdAsync(int employeeId)
        {
            return await HttpHelper.DoGetRequestAsync<List<Duty>>(HttpUrls.DutyPath + employeeId)
                .ConfigureAwait(false);
        }

        public async Task<Duty> GetOneByIdAsync(int id)
        {
            return await HttpHelper.DoGetRequestAsync<Duty>(HttpUrls.DutyPath, id)
                .ConfigureAwait(false);
        }

        public async Task<bool> UpdateOneAsync(Duty item)
        {
            return await HttpHelper.DoPutRequestAsync(HttpUrls.DutyPath, item.Id, item)
                .ConfigureAwait(false);
        }
    }
}