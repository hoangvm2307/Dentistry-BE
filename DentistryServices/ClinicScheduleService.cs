using AutoMapper;
using DentistryBusinessObjects;
using DentistryRepositories;
using DentistryRepositories.Extensions;
using DTOs.ClinicScheduleDtos;


namespace DentistryServices
{
  public class ClinicScheduleService : IClinicScheduleService
  {
    private readonly IClinicScheduleRepository _clinicScheduleRepository;
    private readonly IMapper _mapper;

    public ClinicScheduleService(IClinicScheduleRepository clinicScheduleRepository, IMapper mapper)
    {
      _clinicScheduleRepository = clinicScheduleRepository;
      _mapper = mapper;
    }

    public async Task<PagedList<ClinicScheduleDto>> GetAllClinicSchedulesAsync(ClinicScheduleParams queryParams)
    {
      var clinicSchedules = await _clinicScheduleRepository.GetAllClinicSchedulesAsync(queryParams);
      return _mapper.Map<PagedList<ClinicScheduleDto>>(clinicSchedules);
    }

    public async Task<ClinicScheduleDto> GetClinicScheduleByIdAsync(int id)
    {
      var clinicSchedule = await _clinicScheduleRepository.GetClinicScheduleByIdAsync(id);
      return _mapper.Map<ClinicScheduleDto>(clinicSchedule);
    }

    public async Task<ClinicScheduleDto> CreateClinicScheduleAsync(ClinicScheduleCreateDto clinicScheduleCreateDto)
    {
      var clinicSchedule = _mapper.Map<ClinicSchedule>(clinicScheduleCreateDto);
      await _clinicScheduleRepository.AddClinicScheduleAsync(clinicSchedule);
      return _mapper.Map<ClinicScheduleDto>(clinicSchedule);
    }

    public async Task<ClinicScheduleDto> UpdateClinicScheduleAsync(int id, ClinicScheduleUpdateDto clinicScheduleUpdateDto)
    {
      var clinicSchedule = await _clinicScheduleRepository.GetClinicScheduleByIdAsync(id);
      if (clinicSchedule == null)
      {
        return null;
      }

      _mapper.Map(clinicScheduleUpdateDto, clinicSchedule);
      await _clinicScheduleRepository.UpdateClinicScheduleAsync(clinicSchedule);

      return _mapper.Map<ClinicScheduleDto>(clinicSchedule);
    }
    public async Task<bool> DeleteClinicScheduleAsync(int id)
    {
      var clinicSchedule = await _clinicScheduleRepository.GetClinicScheduleByIdAsync(id);
      if (clinicSchedule == null)
      {
        return false;
      }

      await _clinicScheduleRepository.DeleteClinicScheduleAsync(id);
      return true;
    }
  }
}