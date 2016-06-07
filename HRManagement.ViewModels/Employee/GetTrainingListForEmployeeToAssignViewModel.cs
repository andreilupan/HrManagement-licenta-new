using HRManagement.DataAccess.Models.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace HRManagement.ViewModels.Employee
{
    public class GetTrainingListForEmployeeToAssignViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string FullName { get; set; }
        [Display(Name = "Position")]
        public string Position { get; set; }
        [Display(Name = "Project")]
        public string Project { get; set; }
        public string Name { get; set; }
        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }
        public TrainingStatus Status { get; set; }
        public string StatusDescription { get; set; }
        public bool Selected { get; set; }
    }
}
