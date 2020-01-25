using EmployeeManagement.Core.Constants;
using EmployeeManagement.Core.Helpers;
using EmployeeManagement.Core.Models;
using EmployeeManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Services.Implementations
{
    public class ReportService : IReportService<Report>
    {
        public Task<bool> AddOneAsync(Report item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOneAsync(Report item)
        {
            throw new NotImplementedException();
        }

        public Task<List<Report>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Report> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateOneAsync(Report item)
        {
            throw new NotImplementedException();
        }
    }
}
