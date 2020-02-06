using System.Collections.Generic;

namespace EmployeeManagement.API.Services
{
    public interface IAuthenticationService<T>
    {
        T Authenticate(string username, string password);

        IEnumerable<T> GetAll();

        T GetById(int id);
    }
}