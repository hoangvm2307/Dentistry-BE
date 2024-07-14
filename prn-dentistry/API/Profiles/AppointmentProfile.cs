using AutoMapper;
using DentistryBusinessObjects;
using DentistryRepositories.Extensions;
using DTOs.AppointmentDtos;
namespace prn_dentistry.API.Profiles

{
  public class AppointmentProfile : Profile
  {
    public AppointmentProfile()
    {
      CreateMap<AppointmentDto, Appointment>().ReverseMap()
        .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Dentist.Clinic.Address))
        .ForMember(dest => dest.ClinicPhoneNumber, opt => opt.MapFrom(src => src.Dentist.Clinic.PhoneNumber))
        .ForMember(dest => dest.DentistPhoneNumber, opt => opt.MapFrom(src => src.Dentist.PhoneNumber))
        .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Service.Price))
        .ForMember(dest => dest.ClinicName, opt => opt.MapFrom(src => src.Dentist.Clinic.Name))
        .ForMember(dest => dest.ClinicID, opt => opt.MapFrom(src => src.Dentist.Clinic.ClinicID));


      CreateMap<AppointmentCreateDto, Appointment>().ReverseMap();
      CreateMap<AppointmentUpdateDto, Appointment>().ReverseMap();
      CreateMap(typeof(PagedList<>), typeof(PagedList<>)).ConvertUsing(typeof(ProfileHelpers.PagedListConverter<,>));
    }
  }
}