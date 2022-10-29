using ECommerceApp.BL.DTOs.ChatDTOs;
using ECommerceApp.BL.SignalR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ECommerceApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private IHubContext<NotifyHub, ITypedHubClient> _hubContext;
        public ChatController(IHubContext<NotifyHub, ITypedHubClient> hubContext)
        {
            _hubContext = hubContext;
        }
        [HttpPost]
        public string Get(ChatAddDto model)
        {
            string retMessage = string.Empty;
            try
            {
                _hubContext.Clients.User(model.UserId).BroadcastMessage(model.myMessage);
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
