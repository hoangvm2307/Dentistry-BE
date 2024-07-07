using AutoMapper;
using DentistryBusinessObjects;
using DentistryRepositories.Extensions;
using DTOs.ServiceDtos;


namespace prn_dentistry.API.Profiles
{
  public class ServiceProfile : Profile
  {
    public ServiceProfile()
    {
      CreateMap<Service, ServiceDto>()
        .ForMember(dest => dest.ClinicID, opt => opt.MapFrom(src => src.Clinic.ClinicID))
        .ForMember(dest => dest.ClinicDto, opt => opt.MapFrom(src => src.Clinic));
      CreateMap<ServiceCreateDto, Service>();
      CreateMap<ServiceUpdateDto, Service>();
      CreateMap(typeof(PagedList<>), typeof(PagedList<>)).ConvertUsing(typeof(ProfileHelpers.PagedListConverter<,>));

    }
  }
}