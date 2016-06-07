using HRManagement.DataAccess.Models.Models;
using HRManagement.DataAccess.Repositories;
using HRManagement.ViewModels.Position;
using System.Collections.Generic;
using System.Linq;
using HRManagement.ViewModels.Training;
using System;

namespace HRManagement.Application
{
    public class TrainingService : ITrainingService
    {
        private ITrainingRepository _trainingRepository;
        public TrainingService(ITrainingRepository trainingRepository)
        {
            _trainingRepository = trainingRepository;
        }
        public List<Training> GetAllTrainings()
        {
           return _trainingRepository.GetAllTrainings().ToList();
        }

        List<EmployeesAssignedToTrainingViewModel> ITrainingService.GetEmployeesForTraining(int? id)
        {
            var trainingEmployees = _trainingRepository.GetTrainingById(id).Employees;

            return trainingEmployees.Select(x => new EmployeesAssignedToTrainingViewModel
            {
                Id = x.Id,
                EmployeeFirstName = x.FirstName,
                EmployeeLastName = x.LastName
            }).ToList();
        }
    }
}
