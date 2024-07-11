using DentistryBusinessObjects;

namespace DentistryRepositories.Extensions
{
  public static class TreatmentPlanExtensions
  {
    public static IQueryable<TreatmentPlan> Sort(this IQueryable<TreatmentPlan> query, string orderBy)
    {
      if (string.IsNullOrWhiteSpace(orderBy)) return query.OrderBy(p => p.StartDate);
      query = orderBy switch
      {
        "startDateAsc" => query.OrderBy(c => c.StartDate),
        _ => query.OrderByDescending(c => c.StartDate),
      };
      return query;
    }

    public static IQueryable<TreatmentPlan> Search(this IQueryable<TreatmentPlan> query, string searchTerm)
    {
      if (string.IsNullOrEmpty(searchTerm)) return query;

      var lowerCaseSearchTerm = searchTerm.Trim().ToLower();

      return query.Where(p => p.Customer.Name.ToLower().Contains(lowerCaseSearchTerm));
    }
    public static IQueryable<TreatmentPlan> FilterByClinic(this IQueryable<TreatmentPlan> query, string clinicId)
    {
      if (string.IsNullOrEmpty(clinicId)) return query;

      return query.Where(c => c.Dentist.Clinic.ClinicID == int.Parse(clinicId));
    }
    public static IQueryable<TreatmentPlan> FilterByCustomer(this IQueryable<TreatmentPlan> query, string customerId)
    {
      if (string.IsNullOrEmpty(customerId)) return query;

      return query.Where(c => c.CustomerID == int.Parse(customerId));
    }
     public static IQueryable<TreatmentPlan> FilterByDentist(this IQueryable<TreatmentPlan> query, string dentistId)
    {
      if (string.IsNullOrEmpty(dentistId)) return query;

      return query.Where(c => c.DentistID == int.Parse(dentistId));
    }
  }
}