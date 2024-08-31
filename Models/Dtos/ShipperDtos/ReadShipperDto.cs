
using NorthwindBasedWebApplication.Models.Dtos.OrderDtos;
using System.ComponentModel.DataAnnotations;

namespace NorthwindBasedWebApplication.Models.Dtos.ShipperDtos
{
    public class ReadShipperDto
    {

        [Display(Name = "Id")]
        public int Id { get; set; }



        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }




        [Display(Name = "Phone")]
        public string Phone { get; set; }



        [Display(Name = "Picture")]
        public string? PictureUrl { get; set; }



        //Navigation Properties
        public ICollection<ReadOrderDto> OrdersDto { get; set; }
    }
}
