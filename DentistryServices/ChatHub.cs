using DTOs.ChatMessageDtos;
using Microsoft.AspNetCore.SignalR;

namespace DentistryServices
{
    public class ChatHub : Hub
    {
        private readonly IChatMessageService _chatMessageService;

        public ChatHub(IChatMessageService chatMessageService)
        {
            _chatMessageService = chatMessageService;
        }

        public async Task SendMessage(ChatMessageDto messageDTO)
        {
            var message = await _chatMessageService.SendMessage(messageDTO);
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
