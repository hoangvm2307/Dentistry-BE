using AutoMapper;
using DentistryBusinessObjects;
using DentistryRepositories.Extensions;
using DTOs.ClinicScheduleDtos;


namespace prn_dentistry.API.Profiles
{
  public class ClinicScheduleProfile : Profile
  {
    public ClinicScheduleProfile()
    {
      CreateMap<ClinicSchedule, ClinicScheduleDto>();
      CreateMap<ClinicScheduleCreateDto, ClinicSchedule>();
      CreateMap<ClinicScheduleUpdateDto, ClinicSchedule>();

      CreateMap(typeof(PagedList<>), typeof(PagedList<>)).ConvertUsing(typeof(ProfileHelpers.PagedListConverter<,>));
    }
  }
}