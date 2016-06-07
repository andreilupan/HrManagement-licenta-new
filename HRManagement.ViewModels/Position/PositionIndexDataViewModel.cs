using System.Collections.Generic;
using Models = HRManagement.DataAccess.Models.Models;

namespace HRManagement.ViewModels.Position
{
    public class PositionIndexDataViewModel
    {
        public List<Models.Position> Positions { get; set; }
        public List<EmployeesAssignedToPositionListItem> EmployeesAssignedToPosition { get; set; }

    }
}
