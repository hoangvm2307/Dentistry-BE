using AutoMapper;
using DentistryBusinessObjects;
using DentistryRepositories.Extensions;
using DTOs.ClinicOwnerDtos;


namespace prn_dentistry.API.Profiles
{
  public class ClinicOwnerProfile : Profile
  {
    public ClinicOwnerProfile()
    {
      CreateMap<ClinicOwner, ClinicOwnerDto>()
        .ForMember(dest => dest.ClinicName, opt => opt.MapFrom(src => src.Clinic.Name));
      CreateMap<ClinicOwnerCreateDto, ClinicOwner>();
      CreateMap<ClinicOwnerUpdateDto, ClinicOwner>();

      CreateMap(typeof(PagedList<>), typeof(PagedList<>)).ConvertUsing(typeof(ProfileHelpers.PagedListConverter<,>));
    }
  }

}