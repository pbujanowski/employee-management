using EmployeeManagement.Core.Constants;
using EmployeeManagement.Core.Helpers;
using EmployeeManagement.Core.Models;
using EmployeeManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Services.Implementations
{
    public class CityService : ICityService<City>
    {
        public Task<bool> AddOneAsync(City item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOneAsync(City item)
        {
            throw new NotImplementedException();
        }

        public async Task<List<City>> GetAllAsync()
        {
            return await HttpHelper.DoGetRequestAsync<List<City>>(HttpUrls.CityPath)
                .ConfigureAwait(false);
        }

        public Task<City> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateOneAsync(City item)
        {
            throw new NotImplementedException();
        }
    }
}