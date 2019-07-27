using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Core.Services
{
    public interface IEmployeeService<T> : IDataService<T>
    {
        Task<List<string>> GetAllJobsAsync();
    }
}
