using NorthwindBasedWebApplication.Models.Dtos.EmployeeTerritoryDtos;
using NorthwindBasedWebApplication.Models.Dtos.OrderDtos;
using System.ComponentModel.DataAnnotations;


namespace NorthwindBasedWebApplication.Models.Dtos.EmployeeDtos
{
    public class ReadEmployeeDto
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }



        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Display(Name = "Title")]
        public string Title { get; set; }



        [Display(Name = "Title Of Courtesy")]
        public string TitleOfCourtesy { get; set; }



        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }



        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }



        [Display(Name = "Address")]
        public string Address { get; set; }



        [Display(Name = "City")]
        public string City { get; set; }



        [Display(Name = "Region")]
        public string? Region { get; set; }




        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }



        [Display(Name = "Country")]
        public string Country { get; set; }




        [Display(Name = "Home Phone")]
        public string HomePhone { get; set; }



        
        [Display(Name = "Extension")]
        public string? Extension { get; set; }



        [Display(Name = "Photo")]
        public string? PictureUrl { get; set; }



        [Display(Name = "Notes")]
        public string? Notes { get; set; }






        //Navigations Properties
        [Display(Name = "Reports To")]
        public int? ReportsTo { get; set; }
        public ReadEmployeeDto? ReportDto { get; set; }








        //public ICollection<EmployeeTerritories> EmployeeTerritories { get; set; }


        public ICollection<ReadOrderDto> OrdersDtos { get; set; }



        public ICollection<ReadEmployeeTerritoryDto> EmployeesTerritoriesDto { get; set; }
    }
}
