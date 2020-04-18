using EmployeeManagement.Core.Constants;
using EmployeeManagement.Core.Dtos;
using EmployeeManagement.Core.Helpers;
using EmployeeManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Services.Implementations
{
    public class UserService : IUserService<UserDto, AuthenticationDto>
    {
        public async Task<UserDto> LoginAsync(AuthenticationDto user)
        {
            return await HttpHelper.DoPostRequestAsync<UserDto>(HttpUrls.AuthenticationAuthenticate, user)
               .ConfigureAwait(false);
        }

        public Task<bool> LogoutAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> RegisterAsync(UserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
