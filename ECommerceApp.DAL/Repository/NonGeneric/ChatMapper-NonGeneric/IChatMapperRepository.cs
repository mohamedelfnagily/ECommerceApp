using ECommerceApp.DAL.Data.Models;
using ECommerceApp.DAL.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.DAL.Repository.NonGeneric.ChatMapper_NonGeneric
{
    public interface IChatMapperRepository:IBaseRepository<ChatMapper>
    {
        void SaveConnection(string userId, string ConnectionId);
        void RemoveConnection(string userId, string ConnectionId);
    }
}
