﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talapat.Core.Identity;

namespace Talapat.Core.Services
{
    public interface ITokenServices
    {

        public Task<string> CreateTokenAsync(AppUser user, UserManager<AppUser> userManager);


    }
}
