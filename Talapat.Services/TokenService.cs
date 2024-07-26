using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Talapat.Core.Identity;
using Talapat.Core.Services;

namespace Talapat.Services
{
    

    public class TokenService : ITokenServices
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task<string> CreateTokenAsync(AppUser user, UserManager<AppUser> userManager )
        {


            // payloadData
            //1.  PrivateClaims

            var AuthClaims = new List<Claim>()
            {
                new Claim (ClaimTypes.GivenName , user.DisplayName),
                new Claim(ClaimTypes.Email , user.Email)

            };

            var userroles = await userManager.GetRolesAsync(user);
            foreach (var Role in userroles)
            {
                AuthClaims.Add(new Claim(ClaimTypes.Role, Role)); // مش فاهم الجزا دا
            }
            // 2.Register claims

            

            var AuthKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

            var token = new JwtSecurityToken(issuer: _configuration["JWT:ValidIssure"]
                , audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(double.Parse(_configuration["JWT:DurationInDays"]))
                ,claims:AuthClaims,
                signingCredentials: new SigningCredentials(AuthKey,SecurityAlgorithms.HmacSha256)
                );  

            return new JwtSecurityTokenHandler().WriteToken(token);



        }
    }
}
