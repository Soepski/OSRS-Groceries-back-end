using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSRS_Groceries.HubConfig
{
    public class MyHub : Hub
    {
        public async Task askServer(string someTextFromClient)
        {
            string tempString;

            if (someTextFromClient == "hey")
            {
                tempString = "message was 'hey'";
            }
            else
            {
                tempString = "message is different";
            }

            await Clients.Client(this.Context.ConnectionId).SendAsync("askServerResponse", tempString);
        }

        public async Task sendMessage(string message)
        {
            string tempMessage = "The message was: " + message;

            await Clients.Clients(this.Context.ConnectionId).SendAsync("messageRespone", message);
        }
    }
}
