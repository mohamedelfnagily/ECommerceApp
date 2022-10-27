using AutoMapper;
using ECommerceApp.BL.DTOs.AppUserDTOs;
using ECommerceApp.DAL.Data.Models;
using ECommerceApp.DAL.Repository.NonGeneric.User_NonGeneric;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.BL.Managers.AppUserManager
{
    public class AppUserManager:IAppUserManager
    {
        private readonly UserManager<User> _usermanager;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userrepository;
        public AppUserManager(UserManager<User> usermanager,IMapper mapper,IUserRepository userRepository)
        {
            _usermanager = usermanager;
            _mapper = mapper;
            _userrepository = userRepository;
        }


        //Getting section implementation
        public async Task<AppUserReadDto> GetUserByEmail(string email)
        {
            User user = await _usermanager.FindByEmailAsync(email);
            if(user==null)
            {
                return null;
            }
            AppUserReadDto neededUser = _mapper.Map<AppUserReadDto>(user);
            await GetRole(user, neededUser);
            return neededUser;
        }

        public async Task<AppUserReadDto> GetUserById(string id)
        {
            User user = await _usermanager.FindByIdAsync(id);
            if (user == null)
            {
                return null;
            }
            AppUserReadDto neededUser = _mapper.Map<AppUserReadDto>(user);
            await GetRole(user, neededUser);
            return neededUser;
        }

        public async Task<AppUserReadDto> GetUserByUsername(string username)
        {
            User user = await _usermanager.FindByNameAsync(username);
            if (user == null)
            {
                return null;
            }
            AppUserReadDto neededUser = _mapper.Map<AppUserReadDto>(user);
            await GetRole(user, neededUser);
            return neededUser;
        }

        public async Task<IEnumerable<AppUserReadDto>> GetAllUsers()
        {
            IEnumerable<User> myUsers = await _userrepository.GetAllAsync();
            if(myUsers==null)
            {
                return null;
            }
            IEnumerable<AppUserReadDto> users = _mapper.Map<IEnumerable<AppUserReadDto>>(myUsers);
            
            return users;
        }
        //Adding Section:
        public async Task<AppUserReadDto> AddNewUser(AppUserAddDto model)
        {
            User myUser = _mapper.Map<User>(model);
            if(myUser==null)
            {
                return null;
            }
            var AddedUser =await _usermanager.CreateAsync(myUser, model.Password);
            if(!AddedUser.Succeeded)
            {
                return null;
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,myUser.Id),
                new Claim(ClaimTypes.Role,"Customer")
            };
            var result = await _usermanager.AddClaimsAsync(myUser, claims);
            AppUserReadDto AddedUSer = _mapper.Map<AppUserReadDto>(myUser);
            await GetRole(myUser, AddedUSer);
            return AddedUSer;
        }
        //Deleting Section
        public async Task<AppUserReadDto> DeleteUser(string id)
        {
            User user =await _usermanager.FindByIdAsync(id);
            if(user==null)
            {
                return null;
            }
            var result = await _usermanager.DeleteAsync(user);
            if(!result.Succeeded)
            {
                return null;
            }
            AppUserReadDto deletedUser = _mapper.Map<AppUserReadDto>(user);
            await GetRole(user, deletedUser);

            return deletedUser;
        }
        //Updating section:
        public async Task<AppUserReadDto> UpdateUser(AppUserUpdateDto model,string id)
        {
            User user = await _usermanager.FindByIdAsync(id);
            if (user == null)
            {
                return null;
            }
            _mapper.Map(model, user);
            var result = await _usermanager.UpdateAsync(user);
            if(!result.Succeeded)
            {
                return null;
            }
            var userClaims = await _usermanager.GetClaimsAsync(user);
            await UpdateRole(user, userClaims[1], model.Role);
            AppUserReadDto updatedUser = _mapper.Map<AppUserReadDto>(user);
            await GetRole(user, updatedUser);
            return updatedUser;
        }
        //Getting user role from his claims
        public async Task GetRole(User user,AppUserReadDto model)
        {
            var claims = await _usermanager.GetClaimsAsync(user);
            var role = claims.Select(e => e.Value).ToList();
            model.Role = role[1].ToString();
        }
        //Updating user claim
        public async Task UpdateRole(User user, Claim OldClaim, string NewRole)
        {
            if(NewRole=="Customer"||NewRole=="Admin")
            {
                Claim myClaim = new Claim(ClaimTypes.Role, NewRole);
                await _usermanager.ReplaceClaimAsync(user, OldClaim, myClaim);
            }
        }
    }
}
