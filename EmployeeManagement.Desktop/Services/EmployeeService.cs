using EmployeeManagement.Core.Models;
using EmployeeManagement.Core.Services;
using EmployeeManagement.Desktop.Constants;
using EmployeeManagement.Desktop.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Desktop.Services
{
    public class EmployeeService : IEmployeeService<Employee>
    {
        public async Task<bool> AddOneAsync(Employee item)
        {
            return await HttpHelper.Instance.DoPostRequestAsync(HttpUrls.EmployeePath, item)
                .ConfigureAwait(false);
        }

        public async Task<bool> DeleteOneAsync(Employee item)
        {
            return await HttpHelper.Instance.DoDeleteRequestAsync(HttpUrls.EmployeePath, item.Id);
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await HttpHelper.Instance.DoGetRequestAsync<List<Employee>>(HttpUrls.EmployeePath)
                .ConfigureAwait(false);
        }

        public async Task<Employee> GetOneByIdAsync(int id)
        {
            return await HttpHelper.Instance.DoGetRequestAsync<Employee>(HttpUrls.EmployeePath, id)
                .ConfigureAwait(false);
        }

        public async Task<bool> UpdateOneAsync(Employee item)
        {
            return await HttpHelper.Instance.DoPutRequestAsync(HttpUrls.EmployeePath, item.Id, item)
                .ConfigureAwait(false);
        }

        public async Task<List<string>> GetAllJobsAsync()
        {
            return new List<string>
            {
                "dyrektor",
                "pracownik fizyczny"
            };
        }
    }
}
