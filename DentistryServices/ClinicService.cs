using AutoMapper;
using DentistryBusinessObjects;
using DentistryRepositories;
using DTOs.ClinicDtos;


namespace DentistryServices
{
    public class ClinicService : IClinicService
  {
    private readonly IClinicRepository _clinicRepository;
    private readonly IMapper _mapper;

    public ClinicService(IClinicRepository clinicRepository, IMapper mapper)
    {
      _clinicRepository = clinicRepository;
      _mapper = mapper;
    }

    public async Task<ClinicDto> AddClinicAsync(ClinicCreateDto clinicDto)
    {
      var clinic = _mapper.Map<Clinic>(clinicDto);
      await _clinicRepository.AddClinicAsync(clinic);
      return _mapper.Map<ClinicDto>(clinic);
    }

    public async Task DeleteClinicAsync(int id)
    {
      var clinic = await _clinicRepository.GetClinicByIdAsync(id);
      if(clinic == null)
      {
        throw new NullReferenceException("Clinic object is null.");
      }

      await _clinicRepository.DeleteClinicAsync(id);
    }

    public async Task<IEnumerable<ClinicDto>> GetAllClinicsAsync()
    {
      var clinics = await _clinicRepository.GetAllClinicsAsync();
      if(clinics == null)
      {
        throw new NullReferenceException("Clinics object is null.");
      }
      return _mapper.Map<IEnumerable<ClinicDto>>(clinics);
    }

    public async Task<ClinicDto> GetClinicByIdAsync(int id)
    {
      var clinics = await _clinicRepository.GetClinicByIdAsync(id);
      if(clinics == null)
      {
        throw new NullReferenceException("Clinics object is null.");
      }
      return _mapper.Map<ClinicDto>(clinics);
    }

    public async Task<IEnumerable<ClinicDto>> GetClinicsByStatusAsync(List<bool> statues)
    {
      var clinics = await _clinicRepository.GetAllClinicsAsync();

      if (statues != null){
        clinics = clinics.Where(clinic => statues.Contains(clinic.Status));
      }
      
      return _mapper.Map<IEnumerable<ClinicDto>>(clinics);
    }

    public async Task<ClinicDto> UpdateClinicAsync(int id, ClinicCreateDto clinicDto)
    {
      var clinic = await _clinicRepository.GetClinicByIdAsync(id);
      if(clinic == null)
      {
        throw new NullReferenceException("Clinic object is null.");
      }

      _mapper.Map(clinicDto, clinic);
      await _clinicRepository.UpdateClinicAsync(clinic);
      return _mapper.Map<ClinicDto>(clinic);
    }
  }
}