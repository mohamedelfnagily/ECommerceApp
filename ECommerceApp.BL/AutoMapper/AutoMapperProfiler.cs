using AutoMapper;
using ECommerceApp.BL.DTOs.AuthDTOs;
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
            CreateMap<RegisterDto, User>();
        }
    }
}
