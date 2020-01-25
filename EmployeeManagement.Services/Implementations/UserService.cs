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
    public class UserService : IUserService<User>
    {
        public async Task<User> LoginAsync(User user)
        {
            return await HttpHelper.DoPostRequestAsync<User>(HttpUrls.UsersLoginPath, user)
                .ConfigureAwait(false);
        }

        public async Task<User> RegisterAsync(User user)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public async Task<bool> LogoutAsync(int id)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }
    }
}
