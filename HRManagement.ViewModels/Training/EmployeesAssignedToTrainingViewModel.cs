
using HRManagement.DataAccess.Models.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace HRManagement.ViewModels.Training
{
    public class EmployeesAssignedToTrainingViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }
        public TrainingStatus Status { get; set; }
        public string StatusDescription { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeMiddleName { get; set; }
        public string EmployeeLastName { get; set; }

    }
}
