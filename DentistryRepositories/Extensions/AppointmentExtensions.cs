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
    public static IQueryable<Appointment> FilterByClinic(this IQueryable<Appointment> query, string clinicId)
    {
      if (string.IsNullOrEmpty(clinicId)) return query;

      return query.Where(c => c.Dentist.Clinic.ClinicID == int.Parse(clinicId));
    }
    public static IQueryable<Appointment> FilterByDentist(this IQueryable<Appointment> query, string dentistId)
    {
      if (string.IsNullOrEmpty(dentistId)) return query;

      return query.Where(c => c.DentistID == int.Parse(dentistId));
    }
    public static IQueryable<Appointment> FilterByCustomer(this IQueryable<Appointment> query, string customerId)
    {
      if (string.IsNullOrEmpty(customerId)) return query;

      return query.Where(c => c.CustomerID == int.Parse(customerId));
    }
    public static IQueryable<Appointment> FilterByStatus(this IQueryable<Appointment> query, string status)
    {
      if (string.IsNullOrEmpty(status)) return query;

      return query.Where(c => c.Status.Equals(status.ToLower().Trim()));
    }
  }
}