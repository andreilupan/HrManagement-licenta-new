using HRManagement.DataAccess.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models = HRManagement.DataAccess.Models.Models;

namespace HRManagement.ViewModels.Employee
{
   public class CreateEmployeeViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First Name cannot exceed 50 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Last Name cannot exceed 50 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [StringLength(50, ErrorMessage = "Middle Name cannot exceed 50 characters")]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date of birth")]
        [Required]
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        [Required]
        public string Nationality { get; set; }
        [Required]
        public Language Languages { get; set; }
        [Display(Name = "National identification number")]
        [Required]
        public string NationalIdentificationNumber { get; set; }
        [Display(Name = "Salary (EUR)")]
        public Decimal Salary { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Next salary discussion")]
        public DateTime NextSalaryIncrease { get; set; }
        [Display(Name = "Account number")]
        public string AccountNumber { get; set; }
        [Display(Name = "Bank")]
        public string Bank { get; set; }
        public int PositionId { get; set; }
        public int ProjectId { get; set; }
        [Required]
        public List<Models.Position> Positions { get; set; }
        [Required]
        public List<Models.Project> Projects { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [Display(Name = "Postal code")]
        public string PostalCode { get; set; }
        [Required]
        public string State { get; set; }
        [Display(Name = "Work phone")]
        public string WorkPhone { get; set; }
        [Display(Name = "Private phone")]
        [Required]
        [Phone]
        public string PrivatePhone { get; set; }
        [Required]
        [Display(Name = "Work e-mail")]
        [EmailAddress]
        public string WorkEmail { get; set; }
        [Required]
        [Display(Name = "Private e-mail")]
        [EmailAddress]
        public string PrivateEmail { get; set; }
        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "Employment date")]
        public DateTime EmploymentDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Jubilee date")]
        public DateTime JubileeDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date for formal professional competence")]
        public DateTime DateForFormalProfessionalCompetence { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date for formal teaching skills")]
        public DateTime DateForFormalTeachingSkills { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Personal photo")]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}
