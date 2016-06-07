using HRManagement.DataAccess.Models.Models;
using HRManagement.ViewModels.Position;
using System.Collections.Generic;

namespace HRManagement.Application
{
    public interface ITrainingService
    {
        List<Training> GetAllTrainings();
        List<ViewModels.Training.EmployeesAssignedToTrainingViewModel> GetEmployeesForTraining(int? id);
    }
}
