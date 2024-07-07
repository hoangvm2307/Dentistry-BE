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
    public static IQueryable<TreatmentPlan> Filter(this IQueryable<TreatmentPlan> query, string clinicId)
    {
      if (string.IsNullOrEmpty(clinicId)) return query;

      return query.Where(c => c.Dentist.Clinic.ClinicID == int.Parse(clinicId));
    }
  }
}