using DentistryBusinessObjects;
using DTOs.ChatMessageDtos;
using Microsoft.AspNetCore.SignalR;

namespace DentistryServices
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(ChatMessageDto message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
