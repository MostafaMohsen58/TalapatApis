using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Talapat.Core.Identity;
using Talapat.Core.Services;
using TalapatApis.DTOS;
using TalapatApis.Errors;
using TalapatApis.Extensions;

namespace TalapatApis.Controllers
{

    public class AccountsController : ApiBaseController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenServices _tokenservices;
        private readonly IMapper _mapper;

        public AccountsController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ITokenServices tokenservices,
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenservices = tokenservices;
            _mapper = mapper;
        }
        // Register
        [HttpPost("Register")]

        public async Task<ActionResult<UserDto>> Register(RegisterDto model)
        {

            // if (checkemailexist(model.Email).Result.Value)
            //    return BadRequest(new ApiResponse(400,"this email is already exist"));
            //    return BadRequest(new ApiResponse(400,"this email is already exist"));


            var user = new AppUser()
            {

                DisplayName = model.DisplayName,
                Email = model.Email,
                UserName = model.Email.Split(' ')[0],
                PhoneNumber = model.PhoneNumber,

            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return BadRequest(new ApiResponse(400));
            }
            var returneduser = new UserDto()
            {

                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = await _tokenservices.CreateTokenAsync(user,_userManager)
            };
            return Ok(returneduser);






        }



        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login (LoginDto model)
        {

            var user =  await _userManager.FindByEmailAsync(model.Email);
            if (user is null) return Unauthorized( new ApiResponse(401));
           var result= await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (!result.Succeeded)
            {
                return Unauthorized(new ApiResponse(401));
            }
            return Ok(new UserDto() { DisplayName = user.DisplayName, 
                Email = user.Email,
                Token =await _tokenservices.CreateTokenAsync(user,_userManager) });

        }

       // [Authorize]

        [HttpGet("GetCurrentUser")]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var email= User.FindFirstValue(ClaimTypes.Email);// الايميل بيرجع null
            var user = await _userManager.FindByEmailAsync(email);
            var ReturnedUser= new UserDto()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token= await _tokenservices.CreateTokenAsync(user,_userManager)
            };

            return Ok(ReturnedUser);
        }

            [Authorize]
        [HttpGet("Address")]
        public async Task<ActionResult<AddressDTO>>  GetCurrentUserAddress()
        {
         //   var Email= User.FindFirstValue(ClaimTypes.Email); the extension ,method solve the problem
             var user= await _userManager.FindUserWithAddressAsync (User);
            var mappedaddress= _mapper.Map<Address,AddressDTO>(user.Address);
            return Ok(mappedaddress);


        }



        //[Authorize]
        [HttpPut("Address")]
        public async Task<ActionResult<AddressDTO>> UpdateAddress(AddressDTO Updatedaddress)
        {
            var address = _mapper.Map<AddressDTO, Address>(Updatedaddress);

           // var email= User.FindFirstValue (ClaimTypes.Email);
            var user= await _userManager.FindUserWithAddressAsync (User);
            if (user is null) return Unauthorized(new ApiResponse(401));
            address.ID = user.Address.ID;
            user.Address= address;
           var result=await _userManager.UpdateAsync(user);
            if (result.Succeeded) return BadRequest(new ApiResponse(400));
            return Ok(Updatedaddress);


        }



        [HttpGet("emailexists")]
        public async Task<ActionResult<bool>> checkemailexist(string email)
        {
            // var user = _userManager.FindByEmailAsync(email);
            return _userManager.FindByEmailAsync(email) is not null;
        }



    }
}
