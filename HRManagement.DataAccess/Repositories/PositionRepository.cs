using System;
using System.Linq;
using HRManagement.DataAccess.Models.Models;

namespace HRManagement.DataAccess.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        private HrContext _dbContext;

        public PositionRepository(HrContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<Position> GetAll()
        {
            return _dbContext.Positions;
        }

        public Position GetPositionById(int? id)
        {
            return _dbContext.Positions.Find(id);
        }
    }
}
