using DentistryServices;
using DTOs.ChatMessageDtos;
using Microsoft.AspNetCore.Mvc;

namespace prn_dentistry.API.Controllers
{
    public class ChatController : BaseApiController
    {
        private readonly IChatService _chatService;
        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] ChatMessageDto messageDto)
        {
            await _chatService.SendMessageAsync(messageDto);
            return Ok();
        }

        [HttpGet("listen")]
        public IActionResult ListenForMessages()
        {
            _chatService.ListenForMessages();
            return Ok("Listening for real-time updates");
        }
    }
}
