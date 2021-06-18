using Ghostly.Web.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghostly.Web.Helpers
{
     public interface IUserHelper
    {
        Task<Usuario> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(Usuario usuario, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(Usuario usuario, string roleName);

        Task<bool> IsUserInRoleAsync(Usuario usuario, string roleName);
        

    }
}
