

using NorthwindBasedWebApplication.Models.Dtos.TerritoryDtos;
using System.ComponentModel.DataAnnotations;

namespace NorthwindBasedWebApplication.Models.Dtos.RegionDtos
{
    public class ReadRegionDto
    {

        [Display(Name = "Id")]
        public int Id { get; set; }



        [Display(Name = "Region Description")]
        public string RegionDescription { get; set; }


        [Display(Name = "Picture")]
        public string? PictureUrl { get; set; }



        //Navigation Properties
        public ICollection<ReadTerritoryDto> TerritoriesDto { get; set; }

    }
}
