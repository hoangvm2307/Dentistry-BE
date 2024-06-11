using AutoMapper;
using DentistryBusinessObjects;
using DTOs.ClinicOwnerDtos;


namespace prn_dentistry.API.Profiles
{
  public class ClinicOwnerProfile : Profile
  {
    public ClinicOwnerProfile()
    {
      CreateMap<ClinicOwner, ClinicOwnerDto>();
      CreateMap<ClinicOwnerCreateDto, ClinicOwner>();
    }
  }
}