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
        "clinicAsc" => query.OrderBy(c => c.ClinicID),
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
    public static IQueryable<ClinicSchedule> ViewType(this IQueryable<ClinicSchedule> query, string viewType)
    {
      if (string.IsNullOrEmpty(viewType)) return query;

      switch (viewType)
      {
        case "available":
          return query.Where(cs => cs.Appointments.Count() < cs.MaxPatientsPerSlot);

        case "unavailable":
          return query.Where(cs => cs.Appointments.Count() >= cs.MaxPatientsPerSlot);

        default: return query;
      }
    }

    public static IQueryable<ClinicSchedule> FilterByDate(this IQueryable<ClinicSchedule> query, DateTime date)
    {
      if (date == null) return query;

      return query.Where(c => c.Appointments
                              .Count(a => a.AppointmentDate.Date == date.Date) < c.MaxPatientsPerSlot);
    }
  }
}