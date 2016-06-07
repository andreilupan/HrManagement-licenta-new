using HRManagement.DataAccess.Models.Models;
using System.Linq;

namespace HRManagement.DataAccess.Repositories
{
    public interface IProjectRepository
    {
        IQueryable<Project> GetAllProjects();
        Project GetProjectById(int? id);

    }
}
