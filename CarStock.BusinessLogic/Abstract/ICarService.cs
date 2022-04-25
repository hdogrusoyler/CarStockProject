using CarStock.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Project.BusinessLogic.Abstract
{
    public interface ICarService
    {
        Car GetById(int Id);
        List<Car> GetAll(int page = 1, int pageSize = 0);
        void Add(Car entity);
        void Update(Car entity);
        void Delete(Car entity);
    }
}