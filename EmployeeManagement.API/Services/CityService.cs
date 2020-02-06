using EmployeeManagement.API.Data;
using EmployeeManagement.Core.Models;
using EmployeeManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.API.Services
{
    public class CityService : ServiceBase, ICityService<City>
    {
        public CityService(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

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
            return await Task.FromResult(dbContext.Cities.ToList());
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