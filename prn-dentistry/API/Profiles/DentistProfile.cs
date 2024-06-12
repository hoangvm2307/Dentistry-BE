using AutoMapper;
using DentistryBusinessObjects;
using DTOs.DentistDtos;


namespace prn_dentistry.API.Profiles
{
  public class DentistProfile : Profile
  {
    public DentistProfile()
    {
      CreateMap<Dentist, DentistDto>()
        .ForMember(dest => dest.ClinicID, opt => opt.MapFrom(src => src.Clinic.ClinicID))
        .ForMember(dest => dest.ClinicName, opt => opt.MapFrom(src => src.Clinic.Name));
      CreateMap<DentistCreateDto, Dentist>();
    }
  }
}