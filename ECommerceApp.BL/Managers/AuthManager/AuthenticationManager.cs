using AutoMapper;
using ECommerceApp.BL.DTOs.AuthDTOs;
using ECommerceApp.BL.Helpers;
using ECommerceApp.DAL.Data.Models;
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

namespace ECommerceApp.BL.Managers.AuthManager
{
    public class AuthenticationManager:IAuthenticationManager
    {
        //Implementing user login and user regesteration
        private UserManager<User> _usermanager;
        private IConfiguration _config;
        private readonly IMapper _mapper;
        public AuthenticationManager(UserManager<User> usermanager,IConfiguration config,IMapper mapper)
        {
            _usermanager = usermanager;
            _config = config;
            _mapper = mapper;
        }

        public string GenerateToken(IEnumerable<Claim> myClaims, SigningCredentials credentials)
        {
            var jwt = new JwtSecurityToken(
                    claims:myClaims,
                    signingCredentials:credentials,
                    expires:DateTime.Now.AddMinutes(15),
                    notBefore:DateTime.Now
                );
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.WriteToken(jwt);
            return token;
        }

        public async Task<UserReadDto> LoginUser(LoginDto model)
        {
            UserReadDto? myUserData = new UserReadDto();
            var user = await _usermanager.FindByNameAsync(model.UserName);
            var claims = await _usermanager.GetClaimsAsync(user);
            if (!await _usermanager.CheckPasswordAsync(user, model.Password))
            {
                myUserData = null;
                return myUserData;
            }
            myUserData.Token = GenerateToken(claims, JWT.getCredentials(_config));
            myUserData.ExpiryDuration = JWT.GetExpiryDuration(_config);
            return myUserData;
        }

        public async Task<UserReadDto> RegisterNewUSer(RegisterDto model)
        {
            UserReadDto? myUserData = new UserReadDto();
            User user = _mapper.Map<User>(model);
            var createdUser = await _usermanager.CreateAsync(user,model.Password);
            if(!createdUser.Succeeded)
            {
                myUserData = null;
                return myUserData;
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Role,"Customer")
            };
            var result = await _usermanager.AddClaimsAsync(user, claims);
            if(!result.Succeeded)
            {
                myUserData = null;
                return myUserData;
            }
            myUserData.Token = GenerateToken(claims, JWT.getCredentials(_config));
            myUserData.ExpiryDuration = JWT.GetExpiryDuration(_config);
            return myUserData;
        }
    }
}
