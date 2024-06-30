using AutoMapper;
using DentistryRepositories;
using DTOs.TreatmentPlanDtos;
using DentistryBusinessObjects;
using System.Linq.Expressions;
namespace DentistryServices
{
  public class TreatmentPlanService : ITreatmentPlanService
  {
    private readonly ITreatmentPlanRepository _treatmentPlanRepository;
    private readonly IMapper _mapper;

    public TreatmentPlanService(ITreatmentPlanRepository treatmentPlanRepository, IMapper mapper)
    {
      _treatmentPlanRepository = treatmentPlanRepository;
      _mapper = mapper;
    }

    public async Task<TreatmentPlanDto> CreateTreatmentPlanAsync(TreatmentPlanCreateDto treatmentPlanCreateDto)
    {
      var treatmentPlan = _mapper.Map<TreatmentPlan>(treatmentPlanCreateDto);
      await _treatmentPlanRepository.AddTreatmentPlanAsync(treatmentPlan);
      return _mapper.Map<TreatmentPlanDto>(treatmentPlan);
    }

    public async Task<bool> DeleteTreatmentPlanAsync(int id)
    {
      var treatmentPlan = await _treatmentPlanRepository.GetTreatmentPlanByIdAsync(id);
      if (treatmentPlan == null)
        return false;

      await _treatmentPlanRepository.DeleteTreatmentPlanAsync(id);
      return true;
    }

    public async Task<IEnumerable<TreatmentPlanDto>> GetAllTreatmentPlansAsync()
    {
      var treatmentPlans = await _treatmentPlanRepository.GetAllTreatmentPlansAsync();
      return _mapper.Map<IEnumerable<TreatmentPlanDto>>(treatmentPlans);
    }

    public async Task<TreatmentPlanDto> GetTreatmentPlanByIdAsync(int id)
    {
      var treatmentPlan = await _treatmentPlanRepository.GetTreatmentPlanByIdAsync(id);
      return _mapper.Map<TreatmentPlanDto>(treatmentPlan);
    }

    public async Task<TreatmentPlanDto> UpdateTreatmentAsync(int id, TreatmentPlanUpdateDto treatmentPlanUpdateDto)
    {
      var existingTreatmentPlan = await _treatmentPlanRepository.GetTreatmentPlanByIdAsync(id);
      if (existingTreatmentPlan == null)
        return null;

      _mapper.Map(treatmentPlanUpdateDto, existingTreatmentPlan);
      await _treatmentPlanRepository.UpdateTreatmentPlanAsync(existingTreatmentPlan);

      return _mapper.Map<TreatmentPlanDto>(existingTreatmentPlan);
    }

    // public async Task<PaginatedList<TreatmentPlanDto>> GetPagedTreatmentPlansAsync(QueryParams queryParams)
    // {
    //   Expression<Func<TreatmentPlan, bool>> filterExpression = null;
    //   if (!string.IsNullOrEmpty(queryParams.Filter))
    //   {
    //     filterExpression = e => e.Name.Contains(queryParams.Filter);
    //   }
    //   if (!string.IsNullOrEmpty(queryParams.Search))
    //   {
    //     string searchLower = queryParams.Search.ToLower();
    //     Expression<Func<TreatmentPlan, bool>> searchExpression = e => e.Name.ToLower().Contains(searchLower);
    //     if (filterExpression != null)
    //     {
    //       filterExpression = filterExpression.AndAlso(searchExpression);
    //     }
    //     else
    //     {
    //       filterExpression = searchExpression;
    //     }
    //   }
    //   Func<IQueryable<TreatmentPlan>, IOrderedQueryable<TreatmentPlan>> orderBy = null;
    //   if (queryParams.Sort != null)
    //   {
    //     switch (queryParams.Sort.Key)
    //     {
    //       case "name":
    //         orderBy = q => queryParams.Sort.Value == 1 ? q.OrderByDescending(e => e.Name) : q.OrderBy(e => e.Name);
    //         break;
    //       case "status":
    //         orderBy = q => queryParams.Sort.Value == 1 ? q.OrderByDescending(e => e.Status) : q.OrderBy(e => e.Status);
    //         break;
    //       default:
    //         orderBy = q => q.OrderBy(e => e.TreatmentPlanID); // Default sort by TreatmentPlanID
    //         break;
    //     }
    //   }
    //   else
    //   {
    //     orderBy = q => q.OrderBy(e => e.TreatmentPlanID); // Default sort by TreatmentPlanID
    //   }

    //   var pagedTreatmentPlans = await _TreatmentPlanRepository.GetPagedTreatmentPlansAsync(queryParams.PageIndex, queryParams.PageSize, filterExpression, orderBy);
    //   return new PaginatedList<TreatmentPlanDto>(
    //       _mapper.Map<List<TreatmentPlanDto>>(pagedTreatmentPlans),
    //       pagedTreatmentPlans.Count,
    //       pagedTreatmentPlans.PageIndex,
    //       queryParams.PageSize
    //   );
    // }
  }
}