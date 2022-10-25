using ECommerceApp.DAL.Data.Context;
using ECommerceApp.DAL.Data.Models;
using ECommerceApp.DAL.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.DAL.Repository.NonGeneric.User_NonGeneric
{
    public class UserRepository:BaseRepository<User>,IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context):base(context)
        {
        }

    }
}
