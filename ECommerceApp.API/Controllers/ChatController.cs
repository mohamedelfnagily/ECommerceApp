using ECommerceApp.BL.DTOs.ChatDTOs;
using ECommerceApp.BL.SignalR;
using ECommerceApp.DAL.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ECommerceApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private IHubContext<NotifyHub, ITypedHubClient> _hubContext;
        private readonly UserManager<User> _usermanager;
        public ChatController(IHubContext<NotifyHub, ITypedHubClient> hubContext,UserManager<User> manager)
        {
            _hubContext = hubContext;
            _usermanager = manager;
        }
        [HttpPost]
        public async Task<string> Get(ChatAddDto m)
        {
            string retMessage = string.Empty;
            try
            {

                _hubContext.Clients.User(m.UserId).BroadcastMessage(m.myMessage);
                retMessage = "Success";
            }
            catch (Exception e)
            {
                retMessage = e.ToString();
            }

            return retMessage;
        }
    }
}
