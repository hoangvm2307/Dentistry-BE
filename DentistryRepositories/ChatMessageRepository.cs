using DentistryBusinessObjects;
using DTOs.ChatMessageDtos;
using Microsoft.EntityFrameworkCore;

namespace DentistryRepositories
{
  public class ChatMessageRepository : IChatMessageRepository
  {
    private readonly DBContext _context;
    public ChatMessageRepository(DBContext context)
    {
      _context = context;
    }
    public async Task Create(ChatMessage entity)
    {
      await _context.ChatMessages.AddAsync(entity);
      await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
      var chatToDelete = await _context.ChatMessages.FindAsync(id);
      if (chatToDelete != null)
      {
        _context.ChatMessages.Remove(chatToDelete);
        await _context.SaveChangesAsync();
      }
    }

    public async Task<ChatMessage> Get(int id)
    {
      return await _context.ChatMessages.FindAsync(id);
    }

    public async Task<List<ChatMessage>> GetList()
    {
      return await _context.ChatMessages.ToListAsync();
    }

    public async Task<IEnumerable<ChatMessage>> GetMessagesByUserId(string senderId, string receiverId)
    {
      return await _context.ChatMessages
              .Where(m => m.SenderID == senderId && m.ReceiverID == receiverId || m.SenderID == receiverId && m.ReceiverID == senderId)
              .ToListAsync();
    }

    public async Task<IEnumerable<ReceiverDto>> GetReceivers(string id)
    {
      var messages = await _context.ChatMessages
        .Include(c => c.Sender)
        .ThenInclude(sender => sender.Dentist)
        .Include(c => c.Receiver)
        .ThenInclude(receiver => receiver.Dentist)
        .Where(c => c.SenderID == id || c.ReceiverID == id)
        .ToListAsync();

      var receivers = messages
          .SelectMany(m => new[]
          {
            m.SenderID == id ? m.Receiver : null,
            m.ReceiverID == id ? m.Sender : null
          })
          .Where(user => user != null)
          .Distinct();

      var receiverDtos = receivers
          .Select(r => new ReceiverDto { Id = r.Id, Name = r.Dentist != null ? r.Dentist.Name : r.Customer != null ? r.Customer.Name : r.UserName })
          .ToList();

      return receiverDtos;
    }
    public async Task Update(ChatMessage entity)
    {
      _context.Entry(entity).State = EntityState.Modified;
      await _context.SaveChangesAsync();
    }
  }
}