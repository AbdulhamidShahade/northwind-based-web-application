
using NorthwindBasedWebApplication.Models.Dtos.EmployeeTerritoryDtos;
using NorthwindBasedWebApplication.Models.Dtos.RegionDtos;
using System.ComponentModel.DataAnnotations;

namespace NorthwindBasedWebApplication.Models.Dtos.TerritoryDtos
{
    public class ReadTerritoryDto
    {

        [Display(Name = "Id")]
        public int Id { get; set; }



        [Display(Name = "Territory Description")]
        public string TerritoryDescription { get; set; }



        [Display(Name = "Picture")]
        public string? PictureUrl { get; set; }



        [Display(Name = "Region")]
        public int RegionId { get; set; }
        public ReadRegionDto RegionDto { get; set; }



        public ICollection<ReadEmployeeTerritoryDto> EmployeesTerritoriesDto { get; set; }
    }
}
