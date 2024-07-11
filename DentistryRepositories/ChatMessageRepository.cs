using DentistryBusinessObjects;
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

    public async Task<IEnumerable<ChatMessage>> GetMessagesByUserId(string userId)
    {
      return await _context.ChatMessages
                .Where(m => m.SenderID == userId || m.ReceiverID == userId)
                .ToListAsync();
    }

    public async Task Update(ChatMessage entity)
    {
      _context.Entry(entity).State = EntityState.Modified;
      await _context.SaveChangesAsync();
    }
  }
}