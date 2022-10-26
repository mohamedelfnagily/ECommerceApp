
using ECommerceApp.BL.DTOs.AppUserDTOs;
using ECommerceApp.BL.Managers.AppUserManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //This controller is responsible for all the users endpoints
    public class UsersController : ControllerBase
    {
        private readonly IAppUserManager _appUserManager;
        public UsersController(IAppUserManager appUserManager)
        {
            _appUserManager = appUserManager;
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<ActionResult> GetUsers()
        {
            IEnumerable<AppUserReadDto> myUsers =await _appUserManager.GetAllUsers();
            if(myUsers==null)
            {
                return NotFound();
            }
            return Ok(myUsers);

        }
        [HttpGet]
        [Route("GetUserById")]
        public async Task<ActionResult> GetUserById(string id)
        {
            AppUserReadDto myUser =await _appUserManager.GetUserById(id);
            if (myUser == null)
            {
                return NotFound();
            }
            return Ok(myUser);
        }
        [HttpGet]
        [Route("GetUserByName")]
        public async Task<ActionResult> GetUserByName(string username)
        {
            AppUserReadDto myUser = await _appUserManager.GetUserByUsername(username);
            if (myUser == null)
            {
                return NotFound();
            }
            return Ok(myUser);
        }
        [HttpGet]
        [Route("GetUserByEmail")]
        public async Task<ActionResult> GetUserByEmail(string email)
        {
            AppUserReadDto myUser = await _appUserManager.GetUserByEmail(email);
            if (myUser == null)
            {
                return NotFound();
            }
            return Ok(myUser);
        }
    }
}
