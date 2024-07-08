using DentistryRepositories.Extensions;
using DTOs.TreatmentPlanDtos;

namespace DentistryServices
{
  public interface ITreatmentPlanService
  {
    Task<PagedList<TreatmentPlanDto>> GetAllTreatmentPlansAsync(TreatmentQueryParams queryParams);
    Task<TreatmentPlanDto> GetTreatmentPlanByIdAsync(int id);
    Task<TreatmentPlanDto> CreateTreatmentPlanAsync(TreatmentPlanCreateDto appointmentCreateDto);
    Task<TreatmentPlanDto> UpdateTreatmentAsync(int id, TreatmentPlanUpdateDto appointmentUpdateDto);
    Task<bool> DeleteTreatmentPlanAsync(int id);
  }
}