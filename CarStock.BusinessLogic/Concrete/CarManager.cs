using BaseSolution.Project.BusinessLogic.Abstract;
using BaseSolution.Project.DataAccess;
using CarStock.Entity;
using Microsoft.EntityFrameworkCore;

namespace BaseSolution.Project.BusinessLogic.Concrete
{
    public class CarManager : ICarService
    {
        private ICarRepository carRepository;

        public CarManager(ICarRepository _carRepository)
        {
            carRepository = _carRepository;
        }

        public Car GetById(int Id)
        {
            Car res = new Car();
            res = carRepository.Get(c => c.Id == Id);
            return res;
        }

        public List<Car> GetAll(int page = 1, int pageSize = 0)
        {
            List<Car> res = new List<Car>();
            res = carRepository.GetList(null, (qry) => qry.OrderByDescending(x => x.Id), page, pageSize, null);//i => i.Photos
            return res;
        }

        public void Add(Car entity)
        {
            carRepository.Add(entity);
        }
        public void Update(Car entity)
        {
            carRepository.Update(entity);
        }

        public void Delete(Car entity)
        {
            carRepository.Delete(entity);
        }
    }
}