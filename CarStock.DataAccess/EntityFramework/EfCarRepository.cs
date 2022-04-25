using BaseSolution.Core.DataAccess.EntityFramework;
using CarStock.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Project.DataAccess.EntityFramework
{
    public class EfCarRepository : EfBaseRepository<Car, DataContext>, ICarRepository
    {
        public EfCarRepository(DataContext dbContext) : base(dbContext)
        {

        }
    }
}