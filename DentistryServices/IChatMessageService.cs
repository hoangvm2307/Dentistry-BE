using DTOs.ChatMessageDtos;

namespace DentistryServices
{
  public interface IChatMessageService
  {
    Task<IEnumerable<ChatMessageDto>> GetMessagesByUserId(string userId);
    Task<ChatMessageDto> SendMessage(ChatMessageDto messageDTO);
  }
}
