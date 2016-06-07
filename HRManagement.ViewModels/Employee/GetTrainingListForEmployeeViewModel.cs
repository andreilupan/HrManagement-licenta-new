using HRManagement.DataAccess.Models.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace HRManagement.ViewModels.Employee
{
 public class GetTrainingListForEmployeeViewModel
    {   public int Id { get; set; }

        public string Name { get; set; }
        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }
        public TrainingStatus Status { get; set; }
        public string StatusDescription { get; set; }
    }
}
