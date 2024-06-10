
using AutoMapper;
using DentistryBusinessObjects;
using DTOs.AppointmentDtos;
namespace prn_dentistry.API.Profiles

{
  public class AppointmentProfile : Profile
  {
    public AppointmentProfile()
    {
      CreateMap<AppointmentDto, Appointment>().ReverseMap();
      CreateMap<AppointmentCreateDto, Appointment>().ReverseMap();
      CreateMap<AppointmentUpdateDto, Appointment>().ReverseMap();
    }
  }
}