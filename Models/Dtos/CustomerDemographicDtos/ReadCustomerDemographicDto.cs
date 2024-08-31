
using NorthwindBasedWebApplication.Models.Dtos.CustomerCustomerDemographicDtos;
using System.ComponentModel.DataAnnotations;

namespace NorthwindBasedWebApplication.Models.Dtos.CustomerDemographicDtos
{
    public class ReadCustomerDemographicDto
    {

        [Display(Name = "Id")]
        public int Id { get; set; }



        [Display(Name = "Customer Description")]
        public string? CustomerDescription { get; set; }


        [Display(Name = "Picture")]
        public string? PictureUrl { get; set; }


        public ICollection<ReadCustomerCustomerDemographicDto> CustomersCustomerDemosDto { get; set; }
    }
}
