using Models = HRManagement.DataAccess.Models.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.ViewModels.Employee
{
  public class GetTrainingsForEmployeeToAssignViewModel
    {
        public List<Models.Employee> Employees{ get; set; }
        public List<GetTrainingListForEmployeeToAssignViewModel> TrainingList { get; set; } 
    }
}
