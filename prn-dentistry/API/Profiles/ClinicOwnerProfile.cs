using AutoMapper;
using DentistryBusinessObjects;
using DTOs.ClinicOwnerDtos;


namespace prn_dentistry.API.Profiles
{
  public class ClinicOwnerProfile : Profile
  {
    public ClinicOwnerProfile()
    {
      CreateMap<ClinicOwner, ClinicOwnerDto>()
        .ForMember(dest => dest.ClinicID, opt => opt.MapFrom(src => src.Clinic.ClinicID))
        .ForMember(dest => dest.ClinicName, opt => opt.MapFrom(src => src.Clinic.Name));
      CreateMap<ClinicOwnerCreateDto, ClinicOwner>();
    }
  }
}