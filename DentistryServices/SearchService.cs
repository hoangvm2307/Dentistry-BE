using AutoMapper;
using DentistryRepositories;
using DentistryRepositories.Extensions;
using DTOs.ClinicDtos;
using DTOs.DentistDtos;
using DTOs.SearchDtos;
using DTOs.ServiceDtos;

namespace DentistryServices
{
  public class SearchService : ISearchService
  {
    private readonly IClinicRepository _clinicRepository;
    private readonly IDentistRepository _dentistRepository;
    private readonly IServiceRepository _serviceRepository;
    private readonly IMapper _mapper;

    public SearchService(IClinicRepository clinicRepository, IDentistRepository dentistRepository,
        IServiceRepository serviceRepository, IMapper mapper)
    {
      _mapper = mapper;
      _serviceRepository = serviceRepository;
      _dentistRepository = dentistRepository;
      _clinicRepository = clinicRepository;

    }
    public async Task<SearchResultDto> SearchAsync(SearchParams searchParams)
    {
      var clinics = await _clinicRepository.GetAllClinicsAsync(searchParams);
      var dentists = await _dentistRepository.GetAllAsync(searchParams);
      var services = await _serviceRepository.GetAllServicesAsync(searchParams);

      var clinicDtos = _mapper.Map<List<ClinicDto>>(clinics);
      var dentistDtos = _mapper.Map<List<DentistDto>>(dentists);
      var serviceDtos = _mapper.Map<List<ServiceDto>>(services);

      var result = new SearchResultDto
      {
        Clinics = clinicDtos,
        Dentists = dentistDtos,
        Services = serviceDtos
      };

      return result;
    }
  }
}