using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.BL.SignalR
{
    public interface ITypedHubClient
    {
        Task BroadcastMessage(Message message);

    }
}
