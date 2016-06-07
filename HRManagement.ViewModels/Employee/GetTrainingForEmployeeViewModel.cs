using System.Collections.Generic;

namespace HRManagement.ViewModels.Employee
{
    public class GetTrainingForEmployeeViewModel
    {
        public int EmployeeId { get; set; }
        public List<GetTrainingListForEmployeeViewModel> Trainings { get; set; }
    }
}
