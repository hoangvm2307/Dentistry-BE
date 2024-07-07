using AutoMapper;
using DentistryBusinessObjects;
using DentistryRepositories.Extensions;
using DTOs.CustomerDtos;


namespace prn_dentistry.API.Profiles
{
  public class CustomerProfile : Profile
  {
    public CustomerProfile()
    {
      CreateMap<Customer, CustomerDto>();
      CreateMap<CustomerCreateDto, Customer>();
      CreateMap(typeof(PagedList<>), typeof(PagedList<>)).ConvertUsing(typeof(ProfileHelpers.PagedListConverter<,>));
    }
  }
}