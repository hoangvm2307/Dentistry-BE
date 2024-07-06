public class QueryParams
{
  public int PageIndex { get; set; } = 1;
  public int PageSize { get; set; } = 10;
  public string? Filter { get; set; }
  public SortField? Sort { get; set; }
  public string? Search { get; set; }
}

public class SortField
{
  public string Key { get; set; }
  public int Value { get; set; }
}