using AutoMapper;
using DentistryBusinessObjects;
using DentistryRepositories.Extensions;
using DTOs.ClinicDtos;


namespace prn_dentistry.API.Profiles
{
  public class ClinicProfile : Profile
  {
    public ClinicProfile()
    {
      CreateMap<Clinic, ClinicDto>();
      CreateMap<ClinicCreateDto, Clinic>();
      CreateMap<ClinicUpdateDto, Clinic>();

      CreateMap(typeof(PagedList<>), typeof(PagedList<>)).ConvertUsing(typeof(ProfileHelpers.PagedListConverter<,>));
    }
  }
}