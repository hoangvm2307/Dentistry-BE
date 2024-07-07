using AutoMapper;
using DentistryBusinessObjects;
using DentistryRepositories.Extensions;
using DTOs.TreatmentPlanDtos;
 

namespace prn_dentistry.API.Profiles
{
  public class TreatmenPlanProfile : Profile
  {
    public TreatmenPlanProfile()
    {
      CreateMap<TreatmentPlan, TreatmentPlanDto>();
      CreateMap<TreatmentPlanCreateDto, TreatmentPlan>();
      CreateMap<TreatmentPlanUpdateDto, TreatmentPlan>();
      CreateMap(typeof(PagedList<>), typeof(PagedList<>)).ConvertUsing(typeof(ProfileHelpers.PagedListConverter<,>));
    }
  }
}