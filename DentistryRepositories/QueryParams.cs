public class QueryParams
{
  public int PageIndex { get; set; } = 1;
  public int PageSize { get; set; } = 10;
  public SortField? Sort { get; set; }
  public List<FilterCriterion>? Filters { get; set; } = new List<FilterCriterion>();
  public string? Search { get; set; }
}

public class FilterCriterion
{
  public string Field { get; set; }
  public int Value { get; set; }
}
public class SortField
{
  public string Key { get; set; }
  public int Value { get; set; }
}