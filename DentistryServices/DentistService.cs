using AutoMapper;
using DentistryBusinessObjects;
using DentistryRepositories;
using DTOs.DentistDtos;


namespace DentistryServices
{
    public class DentistService : IDentistService
  {
    private readonly IDentistRepository _dentistRepository;
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
      if(dentist == null)
      {
        throw new NullReferenceException("Dentist object is null.");
      }

      await _dentistRepository.DeleteDentistAsync(id);
    }

    public async Task<List<DentistDto>> GetAllDentistsAsync()
    {
      var dentists = await _dentistRepository.GetAllDentistsAsync();
      if(dentists == null)
      {
        throw new NullReferenceException("Dentists object is null.");
      }
      return _mapper.Map<List<DentistDto>>(dentists);
    }

    public async Task<DentistDto> GetDentistByIdAsync(int id)
    {
      var dentists = await _dentistRepository.GetDentistByIdAsync(id);
      if(dentists == null)
      {
        throw new NullReferenceException("Dentists object is null.");
      }
      return _mapper.Map<DentistDto>(dentists);
    }

    public async Task<List<DentistDto>> GetDentistsByClinicIdAndStatusAsync(List<int> clinicIds, List<bool> statues)
    {
      var dentists = await _dentistRepository.GetAllDentistsAsync();

      if (clinicIds != null){
        dentists = dentists.Where(dentist => clinicIds.Contains(dentist.ClinicID)).ToList();
      }

      if (statues != null){
        dentists = dentists.Where(dentist => statues.Contains(dentist.Status)).ToList();
      }

      if (clinicIds != null && statues != null)
      {
        dentists = dentists.Where(dentist => clinicIds.Contains(dentist.ClinicID) && statues.Contains(dentist.Status)).ToList();
      }
      
      return _mapper.Map<List<DentistDto>>(dentists);
    }

    public async Task UpdateDentistAsync(int id, DentistCreateDto dentistDto)
    {
      var dentist = await _dentistRepository.GetDentistByIdAsync(id);
      if(dentist == null)
      {
        throw new NullReferenceException("Dentist object is null.");
      }

      _mapper.Map(dentistDto, dentist);
      await _dentistRepository.UpdateDentistAsync(dentist);
    }
  }
}