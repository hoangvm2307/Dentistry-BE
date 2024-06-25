using AutoMapper;
using DentistryBusinessObjects;
using DentistryRepositories;
using DTOs.ClinicOwnerDtos;
using Microsoft.IdentityModel.Tokens;


namespace DentistryServices
{
    public class ClinicOwnerService : IClinicOwnerService
  {
    private readonly IClinicOwnerRepository _clinicOwnerRepository;
    private readonly IMapper _mapper;

    public ClinicOwnerService(IClinicOwnerRepository clinicOwnerRepository, IMapper mapper)
    {
      _clinicOwnerRepository = clinicOwnerRepository;
      _mapper = mapper;
    }

    public async Task<IEnumerable<ClinicOwnerDto>> GetAllClinicOwnersAsync()
    {
      var clinicOwners = await _clinicOwnerRepository.GetAllClinicOwnersAsync();
      return _mapper.Map<IEnumerable<ClinicOwnerDto>>(clinicOwners);
    }

    public async Task<ClinicOwnerDto> GetClinicOwnerByIdAsync(int id)
    {
      var clinicOwner = await _clinicOwnerRepository.GetClinicOwnerByIdAsync(id);
      return _mapper.Map<ClinicOwnerDto>(clinicOwner);
    }

    public async Task<IEnumerable<ClinicOwnerDto>> GetClinicOwnersByClinicIdAsync(int id)
    {
      var allClinicOwners = await _clinicOwnerRepository.GetAllClinicOwnersAsync();
      var clinicOwners = allClinicOwners.Where(e => e.ClinicID == id);
      if(clinicOwners == null)
      {
        throw new NullReferenceException("Clinic Owner object is null.");
      }
      return _mapper.Map<IEnumerable<ClinicOwnerDto>>(clinicOwners);
    }

    public async Task<IEnumerable<ClinicOwnerDto>> GetClinicOwnersByClinicIdAndStatusAsync(List<int> clinicIds, List<bool> statuses)
    {
      var clinicOwner = await _clinicOwnerRepository.GetAllClinicOwnersAsync();

      if (!clinicIds.IsNullOrEmpty()){
        clinicOwner = clinicOwner.Where(clinicOwner => clinicIds.Contains(clinicOwner.ClinicID));
      }

      if (!statuses.IsNullOrEmpty()){
        clinicOwner = clinicOwner.Where(clinicOwner => statuses.Contains(clinicOwner.Status));
      }

      if (!clinicIds.IsNullOrEmpty() && !statuses.IsNullOrEmpty())
      {
        clinicOwner = clinicOwner.Where(clinicOwner => clinicIds.Contains(clinicOwner.ClinicID) && statuses.Contains(clinicOwner.Status));
      }
      
      return _mapper.Map<IEnumerable<ClinicOwnerDto>>(clinicOwner);
    }

    public async Task<ClinicOwnerDto> CreateClinicOwnerAsync(ClinicOwnerCreateDto clinicOwnerCreateDto)
    {
      var clinicOwner = _mapper.Map<ClinicOwner>(clinicOwnerCreateDto);
      await _clinicOwnerRepository.AddClinicOwnerAsync(clinicOwner);
      return _mapper.Map<ClinicOwnerDto>(clinicOwner);
    }

    public async Task<ClinicOwnerDto> UpdateClinicOwnerAsync(int id, ClinicOwnerCreateDto clinicOwnerUpdateDto)
    {
      var clinicOwner = await _clinicOwnerRepository.GetClinicOwnerByIdAsync(id);
      if (clinicOwner == null)
      {
        throw new NullReferenceException("Clinic Owner object is null.");
      }

      _mapper.Map(clinicOwnerUpdateDto, clinicOwner);
      await _clinicOwnerRepository.UpdateClinicOwnerAsync(clinicOwner);
      return _mapper.Map<ClinicOwnerDto>(clinicOwner);
    }

    public async Task DeleteClinicOwnerAsync(int id)
    {
      var clinicOwner = await _clinicOwnerRepository.GetClinicOwnerByIdAsync(id);
      if (clinicOwner == null)
      {
        throw new NullReferenceException("Clinic Owner object is null.");
      }

      await _clinicOwnerRepository.DeleteClinicOwnerAsync(id);
    }
  }
}