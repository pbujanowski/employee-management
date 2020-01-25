using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Services.Interfaces
{
    public interface IDataService<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetOneByIdAsync(int id);
        Task<bool> AddOneAsync(T item);
        Task<bool> UpdateOneAsync(T item);
        Task<bool> DeleteOneAsync(T item);
    }
}
