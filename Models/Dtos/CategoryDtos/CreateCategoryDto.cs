﻿using System.ComponentModel.DataAnnotations;

namespace NorthwindBasedWebApplication.Models.Dtos.CategoryDtos
{
    public class CreateCategoryDto
    {
        [Display(Name = "Category Name")]
        [Required(ErrorMessage = "Category name is required!")]
        public string CategoryName { get; set; }



        [Display(Name = "Description")]
        public string? Description { get; set; }



        [Display(Name = "Picture")]

        public string? PictureUrl { get; set; }
    }
}
