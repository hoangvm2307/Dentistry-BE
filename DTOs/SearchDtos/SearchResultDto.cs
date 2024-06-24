using DTOs.ClinicDtos;
using DTOs.DentistDtos;
using DTOs.ServiceDtos;

namespace DTOs.SearchDtos
{
    public class SearchResultDto
    {
        public IEnumerable<ClinicDto> Clinics { get; set; }
        public IEnumerable<DentistDto> Dentists { get; set;}
        public IEnumerable<ServiceDto> Services { get; set;}
    }
}
