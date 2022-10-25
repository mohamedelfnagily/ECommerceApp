using ECommerceApp.BL.DTOs.AuthDTOs;
using ECommerceApp.BL.Managers.AuthManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //this controller is responsible for loging in and regestring new users
        private readonly IAuthenticationManager _manager;
        public AuthController(IAuthenticationManager manager)
        {
            _manager = manager;
        }

        [HttpPost]
        [Route("Register")]
        public ActionResult Register(RegisterDto model)
        {
            var userData = _manager.RegisterNewUSer(model);
            if(userData==null)
            {
                return BadRequest();
            }
            return Ok(userData);
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult Login(LoginDto model)
        {
            var userData = _manager.LoginUser(model);
            if (userData == null)
            {
                return BadRequest();
            }
            return Ok(userData);
        }
    }
}
