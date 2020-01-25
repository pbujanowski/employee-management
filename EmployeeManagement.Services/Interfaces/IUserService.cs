using EmployeeManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Services.Interfaces
{
    public interface IUserService<T>
    {
        Task<T> LoginAsync(User user);

        Task<T> RegisterAsync(User user);

        Task<bool> LogoutAsync(int id);
    }
}
