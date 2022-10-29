using ECommerceApp.BL.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.BL.DTOs.ChatDTOs
{
    public class ChatAddDto
    {
        public Message myMessage { get; set; }
        public string UserId { get; set; } = "";
    }
}
