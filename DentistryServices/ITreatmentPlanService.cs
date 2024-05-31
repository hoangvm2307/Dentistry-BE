using DTOs.TreatmentPlanDto;

namespace DentistryServices
{
  public interface ITreatmentPlanService
  {
    Task<IEnumerable<TreatmentPlanDto>> GetAllTreatmentPlansAsync();
    Task<TreatmentPlanDto> GetTreatmentPlanByIdAsync(int id);
    Task<TreatmentPlanDto> CreateTreatmentPlanAsync(TreatmentPlanCreateDto appointmentCreateDto);
    Task<TreatmentPlanDto> UpdateTreatmentAsync(int id, TreatmentPlanUpdateDto appointmentUpdateDto);
    Task<bool> DeleteTreatmentPlanAsync(int id);
  }
}