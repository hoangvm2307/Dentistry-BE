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

    [HttpGet("sender/{senderId}/receiver/{receiverId}")]
    public async Task<IActionResult> GetMessagesByUserId(string senderId, string receiverId)
    {
      var messages = await _chatMessageService.GetMessagesByUserId(senderId, receiverId);
      return Ok(messages);
    }
    [HttpGet("receivers/{senderId}")]
    public async Task<IActionResult> GetReceivers(string senderId){
      var receivers = await _chatMessageService.GetReceivers(senderId);
      return Ok(receivers);
    }
    [HttpPost]
    public async Task<IActionResult> SendMessage([FromBody] ChatMessageDto messageDTO)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var message = await _chatMessageService.SendMessage(messageDTO);
      _chatContext.Clients.All.SendAsync("ReceiveMessage", message);
      return Ok(message);
    }
  }
}
