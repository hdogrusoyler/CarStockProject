using CarStock.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace CarStock.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5109/api/cars")
            {
                Headers = {
                    { HeaderNames.Accept, "application/json" }
                }
            };

            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
            IEnumerable<Car> carList = new List<Car>();

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var contentStream = await httpResponseMessage.Content.ReadAsStringAsync();
                carList = JsonConvert.DeserializeObject<List<Car>>(contentStream);
            }

            return View(carList);
        }

        public async Task<IActionResult> AddCar(int id = 0)
        {
            if (id > 0)
            {
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5109/api/cars/getbyid?id=" + id)
                {
                    Headers = {
                    { HeaderNames.Accept, "application/json" }
                }
                };

                var httpClient = _httpClientFactory.CreateClient();
                var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
                Car car = new Car();

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var contentStream = await httpResponseMessage.Content.ReadAsStringAsync();
                    car = JsonConvert.DeserializeObject<Car>(contentStream);
                }
                return View(car);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCar(Car car)
        {
            if (car.Id == 0)
            {
                ModelState["id"].ValidationState = Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid;
            }

            if (ModelState.IsValid)
            {
                var httpClient = _httpClientFactory.CreateClient();
                StringContent content = new StringContent(JsonConvert.SerializeObject(car), Encoding.UTF8, "application/json");
                using var httpResponseMessage = await httpClient.PostAsync("http://localhost:5109/api/cars/addupdate", content);

                httpResponseMessage.EnsureSuccessStatusCode();

                return RedirectToAction("Index");
            }
            return View(car);
        }

        public async Task<IActionResult> DeleteCar(int id)
		{

            if (id > 0)
			{
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5109/api/cars/delete?id=" + id)
                {
                    Headers = {
                    { HeaderNames.Accept, "application/json" }
                }
                };

                var httpClient = _httpClientFactory.CreateClient();
                var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
            }

            return RedirectToAction("Index");
		}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}