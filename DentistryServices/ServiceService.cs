using System.Linq.Expressions;
using AutoMapper;
using DentistryBusinessObjects;
using DentistryRepositories;
using DentistryRepositories.Extensions;
using DTOs.ServiceDtos;


namespace DentistryServices
{
  public class ServiceService : IServiceService
  {
    private readonly IServiceRepository _serviceRepository;
    private readonly IMapper _mapper;

    public ServiceService(IServiceRepository serviceRepository, IMapper mapper)
    {
      _serviceRepository = serviceRepository;
      _mapper = mapper;
    }

    public async Task<PagedList<ServiceDto>> GetAllServicesAsync(QueryableParam queryParams)
    {
      var services = await _serviceRepository.GetAllServicesAsync(queryParams);
      return _mapper.Map<PagedList<ServiceDto>>(services);
    }

    public async Task<ServiceDto> GetServiceByIdAsync(int id)
    {
      var service = await _serviceRepository.GetServiceByIdAsync(id);
      return _mapper.Map<ServiceDto>(service);
    }

    public async Task<ServiceDto> CreateServiceAsync(ServiceCreateDto serviceCreateDto)
    {
      var service = _mapper.Map<Service>(serviceCreateDto);
      await _serviceRepository.AddServiceAsync(service);
      return _mapper.Map<ServiceDto>(service);
    }

    public async Task<ServiceDto> UpdateServiceAsync(int id, ServiceUpdateDto serviceUpdateDto)
    {
      var service = await _serviceRepository.GetServiceByIdAsync(id);
      if (service == null)
      {
        return null;
      }

      _mapper.Map(serviceUpdateDto, service);
      await _serviceRepository.UpdateServiceAsync(service);

      return _mapper.Map<ServiceDto>(service);
    }

    public async Task<bool> DeleteServiceAsync(int id)
    {
      var service = await _serviceRepository.GetServiceByIdAsync(id);
      if (service == null)
      {
        return false;
      }

      await _serviceRepository.DeleteServiceAsync(id);
      return true;
    }


  }
}