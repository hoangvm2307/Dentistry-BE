using System.Linq.Expressions;
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
    private readonly IFirebaseStorageService _firebaseStorageService;

    public ClinicService(IClinicRepository clinicRepository, IBaseRepository<Dentist> dentistRepository, IMapper mapper, IFirebaseStorageService firebaseStorageService)
    {
      _clinicRepository = clinicRepository;
      _dentistRepository = dentistRepository;
      _mapper = mapper;
      _firebaseStorageService = firebaseStorageService;
    }

    public async Task<ClinicDto> AddClinicAsync(ClinicCreateDto clinicDto)
    {
      // string imageURL = null;

      // if (clinicDto.Image != null)
      // {
      //   imageURL = await _firebaseStorageService.UploadFileAsync(clinicDto.Image.OpenReadStream(), clinicDto.Image.FileName);
      // }
      var clinic = _mapper.Map<Clinic>(clinicDto);
      // clinic.Image = imageURL;

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

    public async Task<PaginatedList<ClinicDto>> GetPagedClinicsAsync(QueryParams queryParams)
    {
      Expression<Func<Clinic, bool>> filterExpression = null;
      if (!string.IsNullOrEmpty(queryParams.Filter))
      {
        filterExpression = e => e.Name.Contains(queryParams.Filter);
      }
      if (!string.IsNullOrEmpty(queryParams.Search))
      {
        string searchLower = queryParams.Search.ToLower();
        Expression<Func<Clinic, bool>> searchExpression = e => e.Name.ToLower().Contains(searchLower);
        if (filterExpression != null)
        {
          filterExpression = filterExpression.AndAlso(searchExpression);
        }
        else
        {
          filterExpression = searchExpression;
        }
      }
      Func<IQueryable<Clinic>, IOrderedQueryable<Clinic>> orderBy = null;
      if (queryParams.Sort != null)
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
            orderBy = q => q.OrderBy(e => e.ClinicID); // Default sort by ClinicID
            break;
        }
      }
      else
      {
        orderBy = q => q.OrderBy(e => e.ClinicID); // Default sort by ClinicID
      }

      var pagedClinics = await _clinicRepository.GetPagedClinicsAsync(queryParams.PageIndex, queryParams.PageSize, filterExpression, orderBy);
      return new PaginatedList<ClinicDto>(
          _mapper.Map<List<ClinicDto>>(pagedClinics),
          pagedClinics.Count,
          pagedClinics.PageIndex,
          queryParams.PageSize
      );
    }
  }
}