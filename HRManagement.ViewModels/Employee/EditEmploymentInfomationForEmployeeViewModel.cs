using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.ViewModels.Employee
{
   public class EditEmploymentInfomationForEmployeeViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Employment date")]
        public DateTime EmploymentDate { get; set; }
        [Display(Name = "Jubilee date")]
        public DateTime JubileeDate { get; set; }
        [Display(Name = "Date for formal professional competence")]
        public DateTime DateForFormalProfessionalCompetence { get; set; }
        [Display(Name = "Date for formal teaching skills")]
        public DateTime DateForFormalTeachingSkills { get; set; }
        public int EmployeeId { get; set; }
    }
}
