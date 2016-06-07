using HRManagement.DataAccess.Models.Models;
using System.Linq;

namespace HRManagement.DataAccess.Repositories
{
    public class TrainingRepository : ITrainingRepository
    {
        private HrContext _dbContext;

        public TrainingRepository(HrContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Training> GetAllTrainings()
        {
            return _dbContext.Trainings;
        }

        public Training GetTrainingById(int? id)
        {
            return _dbContext.Trainings.Find(id);
        }
    }
}
