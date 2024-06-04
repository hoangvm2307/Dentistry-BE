using AutoMapper;
using DentistryBusinessObjects;
using DTOs.DentistDtos;


namespace prn_dentistry.API.Profiles
{
  public class DentistProfile : Profile
  {
    public DentistProfile()
    {
      CreateMap<Dentist, DentistDto>();
      CreateMap<DentistCreateDto, Dentist>();
    }
  }
}