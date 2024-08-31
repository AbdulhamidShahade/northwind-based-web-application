
using NorthwindBasedWebApplication.Models.Dtos.CustomerDemographicDtos;
using NorthwindBasedWebApplication.Models.Dtos.CustomerDtos;
using System.ComponentModel.DataAnnotations;

namespace NorthwindBasedWebApplication.Models.Dtos.CustomerCustomerDemographicDtos
{
    public class ReadCustomerCustomerDemographicDto
    {

        [Display(Name = "Id")]
        public int Id { get; set; }


        [Display(Name = "Customer Id")]
        public int CustomerId { get; set; }
        public ReadCustomerDto CustomerDto { get; set; }



        [Display(Name = "Customer Demographic")]
        public int CustomerDemographicId { get; set; }
        public ReadCustomerDemographicDto CustomerDemographicDto { get; set; }
    }
}
