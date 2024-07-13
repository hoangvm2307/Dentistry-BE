using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTOs.TreatmentPlanDtos
{
  public class DentistTreatmentDto
  {
    public int DentistId { get; set; }
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Specialization { get; set; }
    public string? Image { get; set; }
    public int ClinicID { get; set; }
    public bool Status { get; set; }
  }
}