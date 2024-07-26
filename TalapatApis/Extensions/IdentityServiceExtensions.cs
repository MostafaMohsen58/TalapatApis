using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Talapat.Core.Identity;
using Talapat.Core.Services;
using Talapat.Repository.Identity;
using Talapat.Services;

namespace TalapatApis.Extensions
{
    public static class IdentityServiceExtensions
    {

        public static IServiceCollection AppIdentityServices(this IServiceCollection Services, IConfiguration configuration)
        {

            Services.AddIdentity<AppUser, IdentityRole>()
                            .AddEntityFrameworkStores<AppIdentityDbContext>();


            Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(Options=>
                {
                    Options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = configuration["JWT:ValidIssure"],
                        ValidateAudience = true,
                        ValidAudience = configuration["JWT:ValidAudience"],
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]))


                    };
                });
            Services.AddScoped<ITokenServices, TokenService>();
            return Services;

        }

    }
}
 