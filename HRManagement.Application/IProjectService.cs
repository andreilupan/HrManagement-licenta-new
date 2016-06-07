using HRManagement.DataAccess.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Application
{
    public interface IProjectService
    {
        List<Project> GetAllProjects();
        List<ViewModels.Project.EmployeesAssignedToProjectViewModel> GetEmployeesForProject(int? id);
    }
}
