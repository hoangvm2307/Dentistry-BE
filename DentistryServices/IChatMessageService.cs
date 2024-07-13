using DTOs.ChatMessageDtos;

namespace DentistryServices
{
  public interface IChatMessageService
  {
    Task<IEnumerable<ChatMessageDto>> GetMessagesByUserId(string senderId, string receiverId);
    Task<IEnumerable<ReceiverDto>> GetReceivers(string id);
    Task<ChatMessageDto> SendMessage(ChatMessageDto messageDTO);
  }
}
