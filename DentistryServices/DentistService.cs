using System.Linq.Expressions;
using AutoMapper;
using DentistryBusinessObjects;
using DentistryRepositories;
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

    public async Task<IEnumerable<DentistDto>> GetAllDentistsAsync()
    {
      var dentists = await _dentistRepository.GetAllDentistsAsync();
      if (dentists == null)
      {
        throw new NullReferenceException("Dentists object is null.");
      }

      // foreach (Dentist dentist in dentists)
      // {
      //   dentist.Clinic = await _clinicRepository.GetClinicByIdAsync(dentist.ClinicID);
      // }
      return _mapper.Map<IEnumerable<DentistDto>>(dentists);
    }

    public async Task<IEnumerable<DentistDto>> GetDentistsByClinicIdAsync(int id)
    {
      var allDentists = await _dentistRepository.GetAllDentistsAsync();
      var dentists = allDentists.Where(e => e.ClinicID == id);
      if (dentists == null)
      {
        throw new NullReferenceException("Dentists object is null.");
      }
      return _mapper.Map<IEnumerable<DentistDto>>(dentists);
    }

    public async Task<DentistDto> GetDentistByIdAsync(int id)
    {
      var dentist = await _dentistRepository.GetDentistByIdAsync(id);
      if (dentist == null)
      {
        throw new NullReferenceException("Dentists object is null.");
      }
      dentist.Clinic = await _clinicRepository.GetClinicByIdAsync(dentist.ClinicID);

      return _mapper.Map<DentistDto>(dentist);
    }

    public async Task<IEnumerable<DentistDto>> GetDentistsByClinicIdAndStatusAsync(List<int> clinicIds, List<bool> statues)
    {
      var dentists = await _dentistRepository.GetAllDentistsAsync();

      if (clinicIds != null)
      {
        dentists = dentists.Where(dentist => clinicIds.Contains(dentist.ClinicID));
      }

      if (statues != null)
      {
        dentists = dentists.Where(dentist => statues.Contains(dentist.Status));
      }

      if (clinicIds != null && statues != null)
      {
        dentists = dentists.Where(dentist => clinicIds.Contains(dentist.ClinicID) && statues.Contains(dentist.Status));
      }

      foreach (Dentist dentist in dentists)
      {
        dentist.Clinic = await _clinicRepository.GetClinicByIdAsync(dentist.ClinicID);
      }

      return _mapper.Map<IEnumerable<DentistDto>>(dentists);
    }

    public async Task<DentistDto> UpdateDentistAsync(int id, DentistCreateDto dentistDto)
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

    public async Task<PaginatedList<DentistDto>> GetPagedDentistsAsync(DentistRequestQueryParams queryParams)
    {
      Expression<Func<Dentist, bool>> filterExpression = null;
      if (!string.IsNullOrEmpty(queryParams.Filter))
      {
        filterExpression = e => e.Name.Contains(queryParams.Filter);
      }

      Func<IQueryable<Dentist>, IOrderedQueryable<Dentist>> orderBy = null;
      if (queryParams.Sort.Key != null)
      {
        switch (queryParams.Sort.Key)
        {
          case "name":
            orderBy = q => queryParams.Sort.Value == 1 ? q.OrderByDescending(e => e.Name) : q.OrderBy(e => e.Name);
            break;
          case "status":
            orderBy = q => queryParams.Sort.Value == 1 ? q.OrderByDescending(e => e.Status) : q.OrderBy(e => e.Status);
            break;
          default:
            orderBy = q => q.OrderBy(e => e.DentistID); // Default sort by DentistID
            break;
        }
      }
      else
      {
        orderBy = q => q.OrderBy(e => e.DentistID); // Default sort by DentistID
      }

      var pagedDentists = await _dentistRepository.GetPagedDentistsAsync(queryParams.PageIndex, queryParams.PageSize, filterExpression, orderBy);
      return new PaginatedList<DentistDto>(
          _mapper.Map<List<DentistDto>>(pagedDentists),
          pagedDentists.Count,
          pagedDentists.PageIndex,
          queryParams.PageSize
      );
    }
  }
}