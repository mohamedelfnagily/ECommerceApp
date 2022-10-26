using ECommerceApp.BL.DTOs.AppUserDTOs;
using ECommerceApp.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.BL.Managers.AppUserManager
{
    public interface IAppUserManager
    {
        //This interface is responsible for all the user operations like getting , adding, removing user
        //Getting section:
        Task<AppUserReadDto> GetUserById(string id);
        Task<AppUserReadDto> GetUserByEmail(string email);
        Task<AppUserReadDto> GetUserByUsername(string username);
        Task<IEnumerable<AppUserReadDto>> GetAllUsers();
        //Adding new user
        Task<AppUserReadDto> AddNewUser(AppUserAddDto model);
        //Deleting user
        Task<AppUserReadDto> DeleteUser(string id);
        //update existing user
        Task<AppUserReadDto> UpdateUser(AppUserUpdateDto model,string id);
    }
}
