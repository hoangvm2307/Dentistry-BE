
namespace DTOs.ServiceDtos
{
  public class ServiceDto
    {   
        public int ClinicID { get; set; }
        public int ServiceID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public decimal Price { get; set; }
    }
}