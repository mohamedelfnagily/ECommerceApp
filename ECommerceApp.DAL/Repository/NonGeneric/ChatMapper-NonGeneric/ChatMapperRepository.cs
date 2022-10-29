using ECommerceApp.DAL.Data.Context;
using ECommerceApp.DAL.Data.Models;
using ECommerceApp.DAL.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.DAL.Repository.NonGeneric.ChatMapper_NonGeneric
{
    public class ChatMapperRepository:BaseRepository<ChatMapper>,IChatMapperRepository
    {
        private readonly ApplicationDbContext _context;
        public ChatMapperRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }
        public void SaveConnection(string userId, string ConnectionId)
        {
            ChatMapper mapper = new ChatMapper { UserId=userId,ConnectionId=ConnectionId};
            _context.chatMapper.Add(mapper);
            _context.SaveChanges();
        }

        public void RemoveConnection(string userId, string ConnectionId)
        {
            var mapper = _context.chatMapper.Where(e => e.UserId == userId && e.ConnectionId == ConnectionId).FirstOrDefault();
            if(mapper!=null)
            {
                _context.chatMapper.Remove(mapper);
                _context.SaveChanges();
            }

        }
    }
}
