using AutoMapper;
using DentistryBusinessObjects;
using DTOs.TreatmentPlanDto;
 

namespace prn_dentistry.API.Profiles
{
  public class TreatmenPlanProfile : Profile
  {
    public TreatmenPlanProfile()
    {
      CreateMap<TreatmentPlan, TreatmentPlanDto>();
      CreateMap<TreatmentPlanCreateDto, TreatmentPlan>();
      CreateMap<TreatmentPlanUpdateDto, TreatmentPlan>();
    }
  }
}