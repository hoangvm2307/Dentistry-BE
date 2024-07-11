using AutoMapper;
using DentistryBusinessObjects;
using DTOs.ChatMessageDtos;

namespace prn_dentistry.API.Profiles
{
  public class ChatMessageProfile : Profile
  {
    public ChatMessageProfile()
    {
      CreateMap<ChatMessage, ChatMessageDto>().ReverseMap();
    }
  }
}