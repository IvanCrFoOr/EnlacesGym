using Application.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication.Models;
using RestSharp;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IPlaceRepositoryAsync _placeRepository;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IPlaceRepositoryAsync placeRepositoryAsync)
        {
            _logger = logger;
            _configuration = configuration;
            _placeRepository = placeRepositoryAsync;
        }

        public IActionResult Index()
        {
            var clientOptions = new RestClientOptions("https://api.foursquare.com/v3/places/search");
            var client = new RestClient(clientOptions);
            var request = new RestRequest("");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", "fsq3suR9gk4mJN/Pp1DqLzVKyOgHS9ekL3P274kHAMt6s9M=");
            var response = client.Get(request);

            var content = response.Content;
            var model = new Domain.Entities.Place()
            {
                DescriptionPlace = "sadsadsadasd",
                Fsq_id = "4bb56f086edc76b0e9c72f1c"
            };
            _placeRepository.AddAsync(model, "eliot369@gmail.com", 1, "Test", false);
            return View();
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