using AutoMapper;
using DentistryBusinessObjects;
using DentistryRepositories.Extensions;
using DTOs.DentistDtos;
using DTOs.TreatmentPlanDtos;


namespace prn_dentistry.API.Profiles
{
  public class DentistProfile : Profile
  {
    public DentistProfile()
    {
      CreateMap<Dentist, DentistDto>()
        .ForMember(dest => dest.ClinicID, opt => opt.MapFrom(src => src.Clinic.ClinicID))
        .ForMember(dest => dest.Clinic, opt => opt.MapFrom(src => src.Clinic));
      CreateMap<DentistCreateDto, Dentist>();
      CreateMap<DentistUpdateDto, Dentist>();
      CreateMap<DentistTreatmentDto, Dentist>().ReverseMap();
      CreateMap(typeof(PagedList<>), typeof(PagedList<>)).ConvertUsing(typeof(ProfileHelpers.PagedListConverter<,>));
    }
  }
}