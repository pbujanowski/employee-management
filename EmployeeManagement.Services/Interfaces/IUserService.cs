using System.Threading.Tasks;

namespace EmployeeManagement.Services.Interfaces
{
    public interface IUserService<T>
    {
        Task<T> LoginAsync(T user);

        Task<T> RegisterAsync(T user);

        Task<bool> LogoutAsync(int id);
    }
}