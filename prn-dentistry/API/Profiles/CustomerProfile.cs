using AutoMapper;
using DentistryBusinessObjects;
using DentistryRepositories.Extensions;
using DTOs.CustomerDtos;
using DTOs.TreatmentPlanDtos;


namespace prn_dentistry.API.Profiles
{
  public class CustomerProfile : Profile
  {
    public CustomerProfile()
    {
      CreateMap<Customer, CustomerDto>()
        .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName));
      CreateMap<CustomerCreateDto, Customer>();
      CreateMap(typeof(PagedList<>), typeof(PagedList<>)).ConvertUsing(typeof(ProfileHelpers.PagedListConverter<,>));
      CreateMap<CustomerTreatmentDto, Customer>().ReverseMap();
      CreateMap<CustomerUpdateDto, Customer>().ReverseMap();

    }
  }
}