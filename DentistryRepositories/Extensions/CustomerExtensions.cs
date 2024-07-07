using DentistryBusinessObjects;

namespace DentistryRepositories.Extensions
{
  public static class CustomerExtensions
  {
    public static IQueryable<Customer> Sort(this IQueryable<Customer> query, string orderBy)
    {
      if (string.IsNullOrWhiteSpace(orderBy)) return query.OrderBy(p => p.Name);
      query = orderBy switch
      {
        "nameAsc" => query.OrderBy(c => c.Name),
        _ => query.OrderByDescending(c => c.Name),
      };
      return query;
    }

    public static IQueryable<Customer> Search(this IQueryable<Customer> query, string searchTerm)
    {
      if (string.IsNullOrEmpty(searchTerm)) return query;

      var lowerCaseSearchTerm = searchTerm.Trim().ToLower();

      return query.Where(p => p.Name.ToLower().Contains(lowerCaseSearchTerm));
    }
    public static IQueryable<Customer> Filter(this IQueryable<Customer> query, string clinicId)
    {
      if (string.IsNullOrEmpty(clinicId)) return query;

      return query.Where(c => c.Appointments.Any(c => c.Dentist.ClinicID == int.Parse(clinicId)));
    }
  }
}