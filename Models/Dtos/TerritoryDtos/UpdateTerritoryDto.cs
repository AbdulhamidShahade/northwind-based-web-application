﻿using System.ComponentModel.DataAnnotations;

namespace NorthwindBasedWebApplication.Models.Dtos.TerritoryDtos
{
    public class UpdateTerritoryDto
    {

        [Required(ErrorMessage = "Id is required field")]
        public int Id { get; set; }


        [Required(ErrorMessage = "Territory Description is required!")]
        [Display(Name = "Territory Description")]
        public string TerritoryDescription { get; set; }


        [Display(Name = "PictureUrl")]
        public string? PictureUrl { get; set; }



        [Required(ErrorMessage = "Region is required field!")]
        [Display(Name = "Region")]

        public int RegionId { get; set; }
    }
}
