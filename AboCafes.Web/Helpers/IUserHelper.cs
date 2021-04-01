using AboCafes.Common.Enums;
using AboCafes.Web.Data.Entities;
using AboCafes.Web.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace AboCafes.Web.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();

        Task<SignInResult> ValidatePasswordAsync(User user, string password);

        Task<User> AddUserAsync(AddUserViewModel model, UserType userType);



    }

}
