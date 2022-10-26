using AutoMapper;
using ECommerceApp.BL.DTOs.AppUserDTOs;
using ECommerceApp.BL.DTOs.AuthDTOs;
using ECommerceApp.BL.DTOs.CategoryDTOs;
using ECommerceApp.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.BL.AutoMapper
{
    public class AutoMapperProfiler:Profile
    {
        public AutoMapperProfiler()
        {
            //Converting from registerDto to user
            CreateMap<RegisterDto, User>();
            //converting from category to category read dto
            CreateMap<Category, CategoryReadDto>();
            //Converting from category add dto to category
            CreateMap<CategoryAddDto, Category>();
            //Converting from category update dto to category
            CreateMap<CategoryUpdateDto, Category>();
            //Converting a user to urser read dto
            CreateMap<User, AppUserReadDto>();
        }
    }
}
