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

    public async Task<IEnumerable<ChatMessageDto>> GetMessagesByUserId(string senderId, string receiverId)
    {
      var messages = await _chatMessageRepository.GetMessagesByUserId(senderId, receiverId);
      return _mapper.Map<IEnumerable<ChatMessageDto>>(messages);
    }

    public Task<IEnumerable<ReceiverDto>> GetReceivers(string id, string role)
    {
      return _chatMessageRepository.GetReceivers(id, role);
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
