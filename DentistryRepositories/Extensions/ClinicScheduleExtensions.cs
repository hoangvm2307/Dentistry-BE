using DentistryBusinessObjects;

namespace DentistryRepositories.Extensions
{
  public static class ClinicScheduleExtensions
  {
    public static IQueryable<ClinicSchedule> Sort(this IQueryable<ClinicSchedule> query, string orderBy)
    {
      if (string.IsNullOrWhiteSpace(orderBy)) return query.OrderBy(p => p.ClinicID);
      query = orderBy switch
      {
        "nameAsc" => query.OrderBy(c => c.ClinicID),
        _ => query.OrderByDescending(c => c.ClinicID),
      };
      return query;
    }

    public static IQueryable<ClinicSchedule> Search(this IQueryable<ClinicSchedule> query, string searchTerm)
    {
      if (string.IsNullOrEmpty(searchTerm)) return query;

      var lowerCaseSearchTerm = searchTerm.Trim().ToLower();

      return query.Where(p => p.DayOfWeek.ToLower().Contains(lowerCaseSearchTerm));
    }
    public static IQueryable<ClinicSchedule> FilterByClinicId(this IQueryable<ClinicSchedule> query, string clinicId)
    {
      if (string.IsNullOrEmpty(clinicId)) return query;

      return query.Where(c => c.ClinicID == int.Parse(clinicId));
    }
  }
}