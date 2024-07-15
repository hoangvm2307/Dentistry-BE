using DentistryServices;
using DTOs.ChatMessageDtos;
using Microsoft.AspNetCore.Authorization;
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
    /// <summary>
    /// Get Messages by Sender and Receiver
    /// Role: Customer, Dentist
    /// </summary>
    [HttpGet("sender/{senderId}/receiver/{receiverId}")]
    [Authorize(Roles = "Customer,Dentist")]
    public async Task<IActionResult> GetMessagesByUserId(string senderId, string receiverId)
    {
      var messages = await _chatMessageService.GetMessagesByUserId(senderId, receiverId);
      return Ok(messages);
    }

    /// <summary>
    /// Get receivers by sender id
    /// Role: Customer, Dentist
    /// </summary>
    [HttpGet("receivers/{senderId}")]
    [Authorize(Roles = "Customer,Dentist")]
    public async Task<IActionResult> GetReceivers(string senderId)
    {
      var receivers = await _chatMessageService.GetReceivers(senderId);
      return Ok(receivers);
    }

    /// <summary>
    /// Send a message
    /// Role: Customer, Dentist
    /// </summary>
    [HttpPost]
    [Authorize(Roles = "Customer,Dentist")]
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
