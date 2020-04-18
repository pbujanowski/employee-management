using System.Threading.Tasks;

namespace EmployeeManagement.Services.Interfaces
{
    public interface IUserService<TUserDto, TAuthDto>
    {
        Task<TUserDto> LoginAsync(TAuthDto user);

        Task<TUserDto> RegisterAsync(TUserDto user);

        Task<bool> LogoutAsync(int id);
    }
}