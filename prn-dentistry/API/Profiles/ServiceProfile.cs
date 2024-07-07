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
      CreateMap<Service, ServiceDto>();
      CreateMap<ServiceCreateDto, Service>();
      CreateMap<ServiceUpdateDto, Service>();
      CreateMap(typeof(PagedList<>), typeof(PagedList<>)).ConvertUsing(typeof(ProfileHelpers.PagedListConverter<,>));

    }
  }
}