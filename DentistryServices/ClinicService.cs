using AutoMapper;
using DentistryBusinessObjects;
using DentistryRepositories;
using DTOs.ClinicDtos;
using Firebase;
using Microsoft.IdentityModel.Tokens;


namespace DentistryServices
{
  public class ClinicService : IClinicService
  {
    private readonly IClinicRepository _clinicRepository;
    private readonly IBaseRepository<Dentist> _dentistRepository;
    private readonly IMapper _mapper;
    private readonly FirebaseStorageService _firebaseStorageService;

    public ClinicService(IClinicRepository clinicRepository, IBaseRepository<Dentist> dentistRepository, IMapper mapper, FirebaseStorageService firebaseStorageService)
    {
      _clinicRepository = clinicRepository;
      _dentistRepository = dentistRepository;
      _mapper = mapper;
      _firebaseStorageService = firebaseStorageService;
    }

    public async Task<ClinicDto> AddClinicAsync(ClinicCreateDto clinicDto)
    {
      string imageURL = await _firebaseStorageService.UploadFileAsync(clinicDto.Image.OpenReadStream(), clinicDto.Image.FileName);
      var clinic = _mapper.Map<Clinic>(clinicDto);
      clinic.Image = imageURL;

      await _clinicRepository.AddClinicAsync(clinic);

      return _mapper.Map<ClinicDto>(clinic);
    }

    public async Task DeleteClinicAsync(int id)
    {
      var clinic = await _clinicRepository.GetClinicByIdAsync(id);
      if (clinic == null)
      {
        throw new NullReferenceException("Clinic object is null.");
      }

      await _clinicRepository.DeleteClinicAsync(id);
    }

    public async Task<IEnumerable<ClinicDto>> GetAllClinicsAsync()
    {
      var clinics = await _clinicRepository.GetAllClinicsAsync();
      if (clinics == null)
      {
        throw new NullReferenceException("Clinics object is null.");
      }
      return _mapper.Map<IEnumerable<ClinicDto>>(clinics);
    }

    public async Task<ClinicDto> GetClinicByIdAsync(int id)
    {
      var clinic = await _clinicRepository.GetClinicByIdAsync(id);
      if (clinic == null)
      {
        throw new NullReferenceException("Clinics object is null.");
      }
      var list = await _dentistRepository.GetAllAsync();
      clinic.Dentists = list?.Where(e => e.ClinicID == clinic.ClinicID).ToList();

      return _mapper.Map<ClinicDto>(clinic);
    }

    public async Task<IEnumerable<ClinicDto>> GetClinicsByStatusAsync(List<bool> statues)
    {
      var clinics = await _clinicRepository.GetAllClinicsAsync();

      if (!statues.IsNullOrEmpty())
      {
        clinics = clinics.Where(clinic => statues.Contains(clinic.Status));
      }

      return _mapper.Map<IEnumerable<ClinicDto>>(clinics);
    }

    public async Task<ClinicDto> UpdateClinicAsync(int id, ClinicCreateDto clinicDto)
    {
      var clinic = await _clinicRepository.GetClinicByIdAsync(id);
      if (clinic == null)
      {
        throw new NullReferenceException("Clinic object is null.");
      }

      _mapper.Map(clinicDto, clinic);
      await _clinicRepository.UpdateClinicAsync(clinic);
      return _mapper.Map<ClinicDto>(clinic);
    }
  }
}