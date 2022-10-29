using ECommerceApp.DAL.Data.Models;
using ECommerceApp.DAL.Repository.NonGeneric.ChatMapper_NonGeneric;
using ECommerceApp.DAL.Repository.NonGeneric.User_NonGeneric;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.BL.SignalR
{
    public class NotifyHub:Hub<ITypedHubClient>
    {
        private readonly IChatMapperRepository _chatMapperRepository;
        private readonly UserManager<User> _usermanager;
        public NotifyHub(IChatMapperRepository chatMapperRepository,UserManager<User> userRepo)
        {
            _chatMapperRepository = chatMapperRepository;
            _usermanager = userRepo;
        }
        public override async Task OnConnectedAsync()
        {
            var user =await _usermanager.FindByNameAsync(Context.User.Identity.Name);
            _chatMapperRepository.SaveConnection(user.Id,Context.ConnectionId);
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var user = await _usermanager.FindByNameAsync(Context.User.Identity.Name);
            _chatMapperRepository.RemoveConnection(user.Id, Context.ConnectionId);
        }
    }
}
