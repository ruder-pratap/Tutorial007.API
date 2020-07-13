using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tutorial007.Shared;

namespace Services.UserService
{
    public interface IUserService
    {
        Task<UserManagerResponse> RegisterUserAsync(RegisterViewModel model);

        Task<UserManagerResponse> LoginUserAsync(LoginViewModel model);
    }
}
