using HRManagement.DataAccess.Models.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Models = HRManagement.DataAccess.Models.Models;

namespace HRManagement.ViewModels.Employee
{
    public class EditEmployeeViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50,ErrorMessage ="First Name cannot exceed 50 characters")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Last Name cannot exceed 50 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [StringLength(50, ErrorMessage = "Middle Name cannot exceed 50 characters")]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        public int PositionId { get; set; }
        public int ProjectId { get; set; }

        public string ImageUrl { get; set; }

        public HttpPostedFileBase ImageUpload { get; set; }

        public List<Models.Position> Positions { get; set; }
        public List<Models.Project> Projects { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of birth")]
        [Required]
        public System.DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        [Required]
        public string Nationality { get; set; }
        [Required]
        public Language Languages { get; set; }
        [Display(Name = "National identification number")]
        [Required]
        public string NationalIdentificationNumber { get; set; }
    }
}
