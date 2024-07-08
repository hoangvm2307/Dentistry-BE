using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistryRepositories.Extensions
{
  public class ServiceQueryParams : PaginationParams
  {
    public string? OrderBy { get; set; }
    public string? SearchTerm { get; set; }
    public bool Status { get; set; } = true;
    public string? ClinicID { get; set; }
  }
}