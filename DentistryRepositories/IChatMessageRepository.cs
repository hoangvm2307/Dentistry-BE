using DentistryBusinessObjects;
using DTOs.ChatMessageDtos;

namespace DentistryRepositories
{
  public interface IChatMessageRepository : IRepository<ChatMessage>
  {
    Task<IEnumerable<ChatMessage>> GetMessagesByUserId(string senderId, string receiverId);
    Task<IEnumerable<ReceiverDto>> GetReceivers(string id);
  }
}