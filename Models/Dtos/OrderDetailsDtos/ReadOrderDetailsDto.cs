using NorthwindBasedWebApplication.Models.Dtos.OrderDtos;
using NorthwindBasedWebApplication.Models.Dtos.ProductDtos;
using System.ComponentModel.DataAnnotations;


namespace NorthwindBasedWebApplication.Models.Dtos.OrderDetailsDto
{
    public class ReadOrderDetailsDto
    {

        [Display(Name = "Id")]
        public int Id { get; set; }


        [Display(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }


        [Display(Name = "Quantity")]
        public short Quantity { get; set; }



        [Display(Name = "Discount")]
        public float Discount { get; set; }


        //Navigation Properties 
        [Display(Name = "Order Id")]
        public int OrderId { get; set; }
        public ReadOrderDto OrderDto { get; set; }


        [Display(Name = "Product Id")]
        public int ProductId { get; set; }
        public ReadProductDto ProductDto { get; set; }
    }
}
