using AutoMapper;
using ECommerceApp.BL.DTOs.AppUserDTOs;
using ECommerceApp.DAL.Data.Models;
using ECommerceApp.DAL.Repository.NonGeneric.User_NonGeneric;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}
