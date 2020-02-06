using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Services.Interfaces
{
    public interface IDutyService<T> : IDataService<T>
    {
        Task<List<T>> GetAllByEmployeeIdAsync(int employeeId);
    }
}