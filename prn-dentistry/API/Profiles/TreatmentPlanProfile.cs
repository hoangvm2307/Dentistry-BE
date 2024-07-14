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
      CreateMap<TreatmentPlanDto, TreatmentPlan>().ReverseMap()
        .ForMember(dest => dest.ClinicName, opt => opt.MapFrom(src => src.Dentist.Clinic.Name))
        .ForMember(dest => dest.ClinicPhoneNumber, opt => opt.MapFrom(src => src.Dentist.Clinic.PhoneNumber))
        .ForMember(dest => dest.ClinicPhoneNumber, opt => opt.MapFrom(src => src.Dentist.Clinic.PhoneNumber))
        .ForMember(dest => dest.DentistName, opt => opt.MapFrom(src => src.Dentist.Name))
        .ForMember(dest => dest.DentistPhoneNumber, opt => opt.MapFrom(src => src.Dentist.PhoneNumber));


      CreateMap<TreatmentPlanCreateDto, TreatmentPlan>();
      CreateMap<TreatmentPlanUpdateDto, TreatmentPlan>();
      CreateMap(typeof(PagedList<>), typeof(PagedList<>)).ConvertUsing(typeof(ProfileHelpers.PagedListConverter<,>));
    }
  }
}