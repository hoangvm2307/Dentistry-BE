using DentistryBusinessObjects;

namespace DentistryRepositories.Extensions
{
  public static class AppointmentExtensions
  {
    public static IQueryable<Appointment> Sort(this IQueryable<Appointment> query, string orderBy)
    {
      if (string.IsNullOrWhiteSpace(orderBy)) return query.OrderBy(p => p.AppointmentDate);
      query = orderBy switch
      {
        "dateAsc" => query.OrderBy(c => c.AppointmentDate),
        _ => query.OrderByDescending(c => c.AppointmentDate),
      };
      return query;
    }

    public static IQueryable<Appointment> Search(this IQueryable<Appointment> query, string searchTerm)
    {
      if (string.IsNullOrEmpty(searchTerm)) return query;

      var lowerCaseSearchTerm = searchTerm.Trim().ToLower();

      return query.Where(p => p.Customer.Name.ToLower().Contains(lowerCaseSearchTerm));
    }
    public static IQueryable<Appointment> Filter(this IQueryable<Appointment> query, string clinicId)
    {
      if (string.IsNullOrEmpty(clinicId)) return query;

      return query.Where(c => c.Dentist.Clinic.ClinicID == int.Parse(clinicId));
    }
  }
}