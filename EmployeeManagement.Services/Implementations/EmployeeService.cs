using EmployeeManagement.Core.Constants;
using EmployeeManagement.Core.Helpers;
using EmployeeManagement.Core.Models;
using EmployeeManagement.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Services.Implementations
{
    public class EmployeeService : IEmployeeService<Employee>
    {
        public async Task<bool> AddOneAsync(Employee item)
        {
            return await HttpHelper.DoPostRequestAsync(HttpUrls.EmployeePath, item)
                .ConfigureAwait(false);
        }

        public async Task<bool> DeleteOneAsync(Employee item)
        {
            return await HttpHelper.DoDeleteRequestAsync(HttpUrls.EmployeePath, item.Id);
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await HttpHelper.DoGetRequestAsync<List<Employee>>(HttpUrls.EmployeePath)
                .ConfigureAwait(false);
        }

        public async Task<Employee> GetOneByIdAsync(int id)
        {
            return await HttpHelper.DoGetRequestAsync<Employee>(HttpUrls.EmployeePath, id)
                .ConfigureAwait(false);
        }

        public async Task<bool> UpdateOneAsync(Employee item)
        {
            return await HttpHelper.DoPutRequestAsync(HttpUrls.EmployeePath, item.Id, item)
                .ConfigureAwait(false);
        }
    }
}
