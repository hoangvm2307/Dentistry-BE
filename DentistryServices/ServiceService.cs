using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using DentistryBusinessObjects;
using DentistryRepositories;
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

    public async Task<IEnumerable<ServiceDto>> GetAllServicesAsync()
    {
      var services = await _serviceRepository.GetAllServicesAsync();
      return _mapper.Map<IEnumerable<ServiceDto>>(services);
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

    public async Task<PaginatedList<ServiceDto>> GetPagedServicesAsync(QueryParams queryParams)
    {
      Expression<Func<Service, bool>> filterExpression = null;
      if (!string.IsNullOrEmpty(queryParams.Filter))
      {
        filterExpression = e => e.Name.Contains(queryParams.Filter);
      }
      if (!string.IsNullOrEmpty(queryParams.Search))
      {
        string searchLower = queryParams.Search.ToLower();
        Expression<Func<Service, bool>> searchExpression = e => e.Name.ToLower().Contains(searchLower);
        if (filterExpression != null)
        {
          filterExpression = filterExpression.AndAlso(searchExpression);
        }
        else
        {
          filterExpression = searchExpression;
        }
      }
      Func<IQueryable<Service>, IOrderedQueryable<Service>> orderBy = null;
      if (queryParams.Sort != null)
      {
        switch (queryParams.Sort.Key)
        {
          case "name":
            orderBy = q => queryParams.Sort.Value == 1 ? q.OrderByDescending(e => e.Name) : q.OrderBy(e => e.Name);
            break;
          default:
            orderBy = q => q.OrderBy(e => e.ServiceID); // Default sort by ServiceID
            break;
        }
      }
      else
      {
        orderBy = q => q.OrderBy(e => e.ServiceID); // Default sort by ServiceID
      }

      var pagedServices = await _serviceRepository.GetPagedServicesAsync(queryParams.PageIndex, queryParams.PageSize, filterExpression, orderBy);
      return new PaginatedList<ServiceDto>(
          _mapper.Map<List<ServiceDto>>(pagedServices),
          pagedServices.Count,
          pagedServices.PageIndex,
          queryParams.PageSize
      );
    }
  }
}