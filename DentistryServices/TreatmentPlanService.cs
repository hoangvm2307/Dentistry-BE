using AutoMapper;
using DentistryRepositories;
using DTOs.TreatmentPlanDto;
using DentistryBusinessObjects;
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
  }
}