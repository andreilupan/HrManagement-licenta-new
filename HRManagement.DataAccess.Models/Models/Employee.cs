using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRManagement.DataAccess.Models.Models
{
    public class Employee : BaseEntity
    { 
        [StringLength(50,ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [StringLength(50, ErrorMessage = "Middle name cannot be longer than 50 characters.")]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name ="Name")]
        public string FullName
        { get
                {
                    return LastName + " " + MiddleName + " " + FirstName;
                }
        }
        [DataType(DataType.Date)]
        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public string Nationality { get; set; }
        public Language Languages { get; set; }
        [Display(Name = "National identification number")]
        public string NationalIdentificationNumber { get; set; }

        public string ImageUrl { get; set; }

        public virtual Company Company { get; set; }
        public virtual Position Position { get; set; }
        public virtual List<Training> Trainings { get; set; }
        public virtual ContactInformation ContactInformation { get; set; }
        public virtual EmploymentInformation EmploymentInformation { get; set; }
        public virtual FinancialInformation FinancialInformation { get; set; }
        public virtual List<Certification> Certification { get; set; }
        public virtual List<Competency> Competencies { get; set; }
        public virtual Project Project { get; set; }
        










    }
}
