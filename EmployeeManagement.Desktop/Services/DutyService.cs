using EmployeeManagement.Core.Models;
using EmployeeManagement.Core.Services;
using EmployeeManagement.Desktop.Constants;
using EmployeeManagement.Desktop.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Desktop.Services
{
    public class DutyService : IDutyService<Duty>
    {
        public async Task<bool> AddOneAsync(Duty item)
        {
            return await HttpHelper.Instance.DoPostRequestAsync(HttpUrls.DutyPath, item)
                .ConfigureAwait(false);
        }

        public async Task<bool> DeleteOneAsync(Duty item)
        {
            return await HttpHelper.Instance.DoDeleteRequestAsync(HttpUrls.DutyPath, item.Id)
                .ConfigureAwait(false);
        }

        public async Task<List<Duty>> GetAllAsync()
        {
            return await HttpHelper.Instance.DoGetRequestAsync<List<Duty>>(HttpUrls.DutyPath)
                .ConfigureAwait(false);
        }

        public async Task<List<Duty>> GetAllByEmployeeIdAsync(int employeeId)
        {
            throw new NotImplementedException();
        }

        public async Task<Duty> GetOneByIdAsync(int id)
        {
            return await HttpHelper.Instance.DoGetRequestAsync<Duty>(HttpUrls.DutyPath, id)
                .ConfigureAwait(false);
        }

        public async Task<bool> UpdateOneAsync(Duty item)
        {
            return await HttpHelper.Instance.DoPutRequestAsync(HttpUrls.DutyPath, item.Id, item)
                .ConfigureAwait(false);
        }
    }
}
