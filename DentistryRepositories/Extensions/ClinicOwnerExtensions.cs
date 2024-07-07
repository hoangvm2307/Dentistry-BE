using DentistryBusinessObjects;

namespace DentistryRepositories.Extensions

{
  public static class ClinicOwnerExtensions
  {
    public static IQueryable<ClinicOwner> Sort(this IQueryable<ClinicOwner> query, string orderBy)
    {
      if (string.IsNullOrWhiteSpace(orderBy)) return query.OrderBy(p => p.Name);
      query = orderBy switch
      {
        "nameAsc" => query.OrderBy(c => c.Name),
        _ => query.OrderByDescending(c => c.Name),
      };
      return query;
    }

    public static IQueryable<ClinicOwner> Search(this IQueryable<ClinicOwner> query, string searchTerm)
    {
      if (string.IsNullOrEmpty(searchTerm)) return query;

      var lowerCaseSearchTerm = searchTerm.Trim().ToLower();

      return query.Where(p => p.Name.ToLower().Contains(lowerCaseSearchTerm));
    }
    public static IQueryable<ClinicOwner> Filter(this IQueryable<ClinicOwner> query, string clinicId)
    {
      if (string.IsNullOrEmpty(clinicId)) return query;

      return query.Where(c => c.ClinicID == int.Parse(clinicId));
    }
  }
}