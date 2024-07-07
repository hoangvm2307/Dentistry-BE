using DentistryBusinessObjects;

namespace DentistryRepositories.Extensions
{
  public static class DentistExtensions
  {
    public static IQueryable<Dentist> Sort(this IQueryable<Dentist> query, string orderBy)
    {
      if (string.IsNullOrWhiteSpace(orderBy)) return query.OrderBy(p => p.Name);
      query = orderBy switch
      {
        "nameAsc" => query.OrderBy(c => c.Name),
        _ => query.OrderByDescending(c => c.Name),
      };
      return query;
    }

    public static IQueryable<Dentist> Search(this IQueryable<Dentist> query, string searchTerm)
    {
      if (string.IsNullOrEmpty(searchTerm)) return query;

      var lowerCaseSearchTerm = searchTerm.Trim().ToLower();

      return query.Where(p => p.Name.ToLower().Contains(lowerCaseSearchTerm));
    }
    public static IQueryable<Dentist> Filter(this IQueryable<Dentist> query, string clinicId)
    {
      if (string.IsNullOrEmpty(clinicId)) return query;

      return query.Where(c => c.ClinicID == int.Parse(clinicId));
    }
  }
}