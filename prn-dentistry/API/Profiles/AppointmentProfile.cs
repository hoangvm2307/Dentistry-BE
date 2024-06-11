
using AutoMapper;
using DentistryBusinessObjects;
using DTOs.AppointmentDto;
namespace prn_dentistry.API.Profiles

{
  public class AppointmentProfile : Profile
  {
    public AppointmentProfile()
    {
      CreateMap<AppointmentDto, Appointment>().ReverseMap()
        .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Customer.Address))
        .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Customer.PhoneNumber));
      CreateMap<AppointmentCreateDto, Appointment>().ReverseMap();
      CreateMap<AppointmentUpdateDto, Appointment>().ReverseMap();
    }
  }
} 