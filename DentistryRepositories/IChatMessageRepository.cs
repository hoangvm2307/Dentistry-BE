using DentistryBusinessObjects;

namespace DentistryRepositories
{
  public interface IChatMessageRepository : IRepository<ChatMessage>
  {
    Task<IEnumerable<ChatMessage>> GetMessagesByUserId(string userId);
  }
}