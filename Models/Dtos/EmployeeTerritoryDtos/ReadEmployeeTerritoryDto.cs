
using NorthwindBasedWebApplication.Models.Dtos.EmployeeDtos;
using NorthwindBasedWebApplication.Models.Dtos.TerritoryDtos;
using System.ComponentModel.DataAnnotations;

namespace NorthwindBasedWebApplication.Models.Dtos.EmployeeTerritoryDtos
{
    public class ReadEmployeeTerritoryDto
    {

        [Display(Name = "Id")]
        public int Id { get; set; }



        [Display(Name = "Employee Id")]
        public int EmployeeId { get; set; }
        public ReadEmployeeDto EmployeeDto { get; set; }



        [Display(Name = "Territory Id")]
        public int TerritoryId { get; set; }
        public ReadTerritoryDto TerritoryDto { get; set; }
    }
}
