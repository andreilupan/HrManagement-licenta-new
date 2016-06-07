using HRManagement.DataAccess.Models.Models;
using System.Linq;

namespace HRManagement.DataAccess.Repositories
{
    public interface IPositionRepository
    {
        IQueryable<Position> GetAll();

        Position GetPositionById(int? id);
    }

}
