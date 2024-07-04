using DTOs.ChatMessageDtos;

namespace DentistryServices
{
    public interface IChatService
    {
        Task SendMessageAsync(ChatMessageDto messageDto);
        void ListenForMessages();
    }
}
