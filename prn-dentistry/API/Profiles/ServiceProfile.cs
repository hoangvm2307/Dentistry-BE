using AutoMapper;
using DentistryBusinessObjects;
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
    }
  }
}