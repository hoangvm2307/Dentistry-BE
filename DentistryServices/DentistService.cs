using AutoMapper;
using DentistryBusinessObjects;
using DentistryRepositories;
using DentistryRepositories.Extensions;
using DTOs.DentistDtos;

namespace DentistryServices
{
  public class DentistService : IDentistService
  {
    private readonly IDentistRepository _dentistRepository;
    private readonly IClinicRepository _clinicRepository;
    private readonly IMapper _mapper;

    public DentistService(IDentistRepository dentistRepository, IMapper mapper)
    {
      _dentistRepository = dentistRepository;
      _mapper = mapper;
    }

    public async Task<DentistDto> AddDentistAsync(DentistCreateDto dentistDto)
    {
      var dentist = _mapper.Map<Dentist>(dentistDto);
      await _dentistRepository.AddDentistAsync(dentist);
      return _mapper.Map<DentistDto>(dentist);
    }

    public async Task DeleteDentistAsync(int id)
    {
      var dentist = await _dentistRepository.GetDentistByIdAsync(id);
      if (dentist == null)
      {
        throw new NullReferenceException("Dentist object is null.");
      }

      await _dentistRepository.DeleteDentistAsync(id);
    }

    public async Task<PagedList<DentistDto>> GetAllDentistsAsync(DentistQueryParams queryParams)
    {
      var dentists = await _dentistRepository.GetAllAsync(queryParams);
      if (dentists == null)
      {
        throw new NullReferenceException("Dentists object is null.");
      }
      return _mapper.Map<PagedList<DentistDto>>(dentists);
    }

    public async Task<DentistDto> GetDentistByIdAsync(int id)
    {
      var dentist = await _dentistRepository.GetDentistByIdAsync(id);
      if (dentist == null)
      {
        throw new NullReferenceException("Dentists object is null.");
      }

      return _mapper.Map<DentistDto>(dentist);
    }

    public async Task<DentistDto> UpdateDentistAsync(int id, DentistUpdateDto dentistDto)
    {
      var dentist = await _dentistRepository.GetDentistByIdAsync(id);
      if (dentist == null)
      {
        throw new NullReferenceException("Dentist object is null.");
      }

      _mapper.Map(dentistDto, dentist);
      await _dentistRepository.UpdateDentistAsync(dentist);
      return _mapper.Map<DentistDto>(dentist);
    }


  }
}