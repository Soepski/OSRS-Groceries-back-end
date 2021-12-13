using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using OSRS_Groceries.HubConfig;
using OSRS_Groceries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSRS_Groceries.Controllers
{
    [Route("Message")]
    [ApiController]
    public class MessageController : Controller
    {
        private readonly IHubContext<MyHub> hub;

        public MessageController(IHubContext<MyHub> _hub)
        {
            hub = _hub;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessageToAll(Message message)
        {
            await hub.Clients.All.SendAsync("messageRespone", message.message);
            return Ok();
        }
    }
}
