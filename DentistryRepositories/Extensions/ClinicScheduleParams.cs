using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistryRepositories.Extensions
{
  public class ClinicScheduleParams : PaginationParams
  {
    public string? OrderBy { get; set; }
    public string? SearchTerm { get; set; }
    public string? ClinicID { get; set; }
  }
}