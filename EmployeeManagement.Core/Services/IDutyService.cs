using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Core.Services
{
    public interface IDutyService<T> : IDataService<T>
    {
        Task<List<T>> GetAllByEmployeeIdAsync(int employeeId);
    }
}
