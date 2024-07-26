using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Talapat.Core.Identity;

namespace TalapatApis.Extensions
{
    public static class UserMangerExtensions
    {

        public static async Task<AppUser?> FindUserWithAddressAsync ( this UserManager<AppUser> usermanger,ClaimsPrincipal User)
        {
            var email= User.FindFirstValue(ClaimTypes.Email);
            var user = await usermanger.Users.Include(U => U.Address).FirstOrDefaultAsync(U => U.Email == email);
            return user;


        }


    }
}
