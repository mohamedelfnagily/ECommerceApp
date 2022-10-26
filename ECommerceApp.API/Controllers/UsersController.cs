
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

        //Adding new user by the admin
        [HttpPost]
        [Route("AddUser")]
        public async Task<ActionResult> AddUser(AppUserAddDto model)
        {
            AppUserReadDto myUser =await  _appUserManager.AddNewUser(model);
            if(myUser == null)
            {
                return BadRequest();
            }
            return Ok(myUser);
        }
        //Deleting Existing user
        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<ActionResult> DeleteUser(string id)
        {
            AppUserReadDto user = await _appUserManager.DeleteUser(id);
            if(user==null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        //Updating Existing user
        [HttpPut]
        [Route("UpdateUser")]
        public async Task<ActionResult> UpdateUser(AppUserUpdateDto model,string id)
        {
            AppUserReadDto user = await _appUserManager.UpdateUser(model,id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
