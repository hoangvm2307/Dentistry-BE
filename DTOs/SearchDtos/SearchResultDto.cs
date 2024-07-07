using DTOs.ClinicDtos;
using DTOs.DentistDtos;
using DTOs.ServiceDtos;

namespace DTOs.SearchDtos
{
    public class SearchResultDto
    {
        public List<ClinicDto> Clinics { get; set; }
        public List<DentistDto> Dentists { get; set;}
        public List<ServiceDto> Services { get; set;}
    }
}
