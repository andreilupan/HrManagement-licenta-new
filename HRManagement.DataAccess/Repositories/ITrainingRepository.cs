using HRManagement.DataAccess.Models.Models;
using System.Linq;

namespace HRManagement.DataAccess.Repositories
{

    public interface ITrainingRepository
    {
        IQueryable<Training> GetAllTrainings();
        Training GetTrainingById(int? id);
    }
}
