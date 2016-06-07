using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRManagement.DataAccess.Models.Models
{
  public class Position : BaseEntity
    {
        [Display(Name = "Job title")]
        public string Name { get; set; }
        [Display(Name = "Job description")]
        public string Description { get; set; }
        [Display(Name = "Technology")]
        public string Technology { get; set; }
        [Display(Name = "Level of experience")]
        public LevelOfExperience LevelOfExperience { get; set; }
        public virtual List<Employee> Employees { get; set; }

    }
}
