using System.Collections.Generic;
using Models = HRManagement.DataAccess.Models.Models;

namespace HRManagement.ViewModels.Training
{
    public class TrainingIndexDataViewModel
    {
        public List<Models.Training> Trainings { get; set; }
        public List<EmployeesAssignedToTrainingViewModel> EmployeesAssignedToTrainings { get; set; }
    }
}
