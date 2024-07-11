using DentistryServices;
using DTOs.ChatMessageDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace prn_dentistry.API.Controllers
{
  public class ChatMessageController : BaseApiController
  {
    private readonly IChatMessageService _chatMessageService;
    private readonly IHubContext<ChatHub> _chatContext;
    public ChatMessageController(IChatMessageService chatMessageService, IHubContext<ChatHub> chatContext)
    {
      _chatMessageService = chatMessageService;
      _chatContext = chatContext;
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetMessagesByUserId(string userId)
    {
      var messages = await _chatMessageService.GetMessagesByUserId(userId);
      return Ok(messages);
    }
    [HttpPost]
    public async Task<IActionResult> SendMessage([FromBody] ChatMessageDto messageDTO)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var message = await _chatMessageService.SendMessage(messageDTO);
      _chatContext.Clients.All.SendAsync("ReceiveMessage", message);
      return CreatedAtAction(nameof(GetMessagesByUserId), new { userId = message.SenderID }, message);
    }
  }
}
