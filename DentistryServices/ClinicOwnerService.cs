using System.Linq.Expressions;
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

    public async Task<PaginatedList<ClinicOwnerDto>> GetPagedClinicOwnersAsync(QueryParams queryParams)
    {
      Expression<Func<ClinicOwner, bool>> filterExpression = null;
      if (!string.IsNullOrEmpty(queryParams.Filter))
      {
        filterExpression = e => e.Name.Contains(queryParams.Filter);
      }
      if (!string.IsNullOrEmpty(queryParams.Search))
      {
        string searchLower = queryParams.Search.ToLower();
        Expression<Func<ClinicOwner, bool>> searchExpression = e => e.Name.ToLower().Contains(searchLower);
        if (filterExpression != null)
        {
          filterExpression = filterExpression.AndAlso(searchExpression);
        }
        else
        {
          filterExpression = searchExpression;
        }
      }
      Func<IQueryable<ClinicOwner>, IOrderedQueryable<ClinicOwner>> orderBy = null;
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
            orderBy = q => q.OrderBy(e => e.OwnerID); // Default sort by ClinicID
            break;
        }
      }
      else
      {
        orderBy = q => q.OrderBy(e => e.OwnerID); // Default sort by ClinicID
      }

      var pagedClinics = await _clinicOwnerRepository.GetPagedClinicOwnersAsync(queryParams.PageIndex, queryParams.PageSize, filterExpression, orderBy);
      return new PaginatedList<ClinicOwnerDto>(
          _mapper.Map<List<ClinicOwnerDto>>(pagedClinics),
          pagedClinics.Count,
          pagedClinics.PageIndex,
          queryParams.PageSize
      );
    }
  }
}