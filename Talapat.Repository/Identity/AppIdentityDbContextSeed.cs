using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talapat.Core.Identity;

namespace Talapat.Repository.Identity
{
    public class AppIdentityDbContextSeed
    {

        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {


            if (!userManager.Users.Any()) 
            {
                var User = new AppUser()
                {
                    DisplayName="Ahmed Yaser",
                    Email="ahmedyaser232003@gmail.com",
                    PhoneNumber="011254595575",
                    UserName="AhmedYaser"
                };
                await userManager.CreateAsync(User , "Pa$$w0rd");



            }
        }
    }
}
