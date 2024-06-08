using AutoMapper;
using DentistryBusinessObjects;
using DTOs.ClinicDtos;


namespace prn_dentistry.API.Profiles
{
  public class ClinicProfile : Profile
  {
    public ClinicProfile()
    {
      CreateMap<Clinic, ClinicDto>();
      CreateMap<ClinicCreateDto, Clinic>();
    }
  }
}