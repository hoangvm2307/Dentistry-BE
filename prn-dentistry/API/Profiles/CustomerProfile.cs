using AutoMapper;
using DentistryBusinessObjects;
using DTOs.CustomerDtos;


namespace prn_dentistry.API.Profiles
{
  public class CustomerProfile : Profile
  {
    public CustomerProfile()
    {
      CreateMap<Customer, CustomerDto>();
      CreateMap<CustomerCreateDto, Customer>();
    }
  }
}