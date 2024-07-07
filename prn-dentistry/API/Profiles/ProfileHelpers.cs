using AutoMapper;
using DentistryRepositories.Extensions;

namespace prn_dentistry.API.Profiles
{
  public class ProfileHelpers
  {
    public class PagedListConverter<TSource, TDestination> : ITypeConverter<PagedList<TSource>, PagedList<TDestination>>
    {
      public PagedList<TDestination> Convert(PagedList<TSource> source, PagedList<TDestination> destination, ResolutionContext context)
      {

        var items = context.Mapper.Map<List<TDestination>>(source);


        return new PagedList<TDestination>(items, source.MetaData.TotalCount, source.MetaData.CurrentPage, source.MetaData.PageSize);
      }
    }
  }
}