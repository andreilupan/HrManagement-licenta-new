using HRManagement.DataAccess.Models.Models;
using System.Linq;

namespace HRManagement.DataAccess.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private HrContext _dbContext;
        public ProjectRepository(HrContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<Project> GetAllProjects()
        {
            return _dbContext.Projects;
        }
        public Project GetProjectById(int? id)
        {
            return _dbContext.Projects.Find(id);
        }
    }
}
