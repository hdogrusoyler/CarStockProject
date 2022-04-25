using BaseSolution.Project.BusinessLogic.Abstract;
using CarStock.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseSolution.Project.Presentation.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private ICarService carService;

        public CarsController(ICarService _carService)
        {
            carService = _carService;
        }

        [HttpGet]
        public List<Car> GetList()
        {
            return carService.GetAll();
        }

        [HttpGet("GetById")]
        public Car Get(int Id)
        {
            return carService.GetById(Id);
        }

        [HttpPost]
        [Route("addupdate")]
        public void AddUpdate([FromBody] Car car)
        {
            if (car.Id > 0)
            {
                carService.Update(car);
            }
            else
            {
                carService.Add(car);
            }
        }

        [HttpGet("delete")]
        public void Delete(int Id)
        {
            carService.Delete(new Car { Id = Id });
        }
    }
}