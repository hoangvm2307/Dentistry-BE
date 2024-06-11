using AutoMapper;
using DentistryBusinessObjects;
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
    }
  }
}