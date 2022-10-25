using ECommerceApp.BL.DTOs.AuthDTOs;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.BL.Managers.AuthManager
{
    public interface IAuthenticationManager
    {
        //This interface is responsible for regestiration of new user and for the login of user
        Task<UserReadDto> RegisterNewUSer(RegisterDto model);
        Task<UserReadDto> LoginUser(LoginDto model);
        string GenerateToken(IEnumerable<Claim> myClaims , SigningCredentials credentials);

    }
}
