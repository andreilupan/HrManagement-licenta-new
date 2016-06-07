using HRManagement.DataAccess.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Application
{
   public interface IPositionService
    {
        List<Position> GetAllPositions();
        List<ViewModels.Position.EmployeesAssignedToPositionListItem> GetEmployeesForPosition(int? id);
    }
}
