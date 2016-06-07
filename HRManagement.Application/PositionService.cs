using HRManagement.DataAccess.Models.Models;
using HRManagement.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Application
{
   public class PositionService : IPositionService
    { 
        private IPositionRepository _positionRepository;
        public PositionService(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }

        public List<Position> GetAllPositions()
        {
            return _positionRepository.GetAll().ToList();
        }

        public List<ViewModels.Position.EmployeesAssignedToPositionListItem> GetEmployeesForPosition(int? id)
        {
            var positionEmployees = _positionRepository.GetPositionById(id).Employees;

            return positionEmployees.Select(x => new ViewModels.Position.EmployeesAssignedToPositionListItem
            {
                Id = x.Id,
                EmployeeFirstName = x.FirstName,
                EmployeeLastName = x.LastName,
            }).ToList();
        }

    }
}
