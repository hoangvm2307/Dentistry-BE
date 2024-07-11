using AutoMapper;
using DentistryBusinessObjects;
using DentistryRepositories;
using DTOs.ChatMessageDtos;

namespace DentistryServices
{
  public class ChatMessageService : IChatMessageService
  {
    private readonly IChatMessageRepository _chatMessageRepository;
    private readonly IMapper _mapper;

    public ChatMessageService(IChatMessageRepository chatMessageRepository, IMapper mapper)
    {
      _chatMessageRepository = chatMessageRepository;
      _mapper = mapper;
    }

    public async Task<IEnumerable<ChatMessageDto>> GetMessagesByUserId(string userId)
    {
      var messages = await _chatMessageRepository.GetMessagesByUserId(userId);
      return _mapper.Map<IEnumerable<ChatMessageDto>>(messages);
    }

    public async Task<ChatMessageDto> SendMessage(ChatMessageDto messageDTO)
    {
      var chatMessage = _mapper.Map<ChatMessage>(messageDTO);
      chatMessage.Timestamp = DateTime.Now;
      _chatMessageRepository.Create(chatMessage);

      return _mapper.Map<ChatMessageDto>(chatMessage);
    }
  }
}
