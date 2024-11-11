using Application.Interface;
using Microsoft.AspNetCore.Mvc;
using PlaceWeb.Models;
using System.Diagnostics;
using RestSharp;
using Application.Features;
using MediatR;
using Application.Features.Places;
using Application.Features.Places.Queries;
using Application.Features.Places.Commands;

namespace PlaceWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IPlaceRepositoryAsync _placeRepositoryAsync;
        private IMediator _mediator;
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IPlaceRepositoryAsync placeRepositoryAsync, IMediator mediator)
        {
            _logger = logger;
            _configuration = configuration;
            _placeRepositoryAsync = placeRepositoryAsync;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {

            var result = await _mediator.Send(new SearchPlaceQuery() { place = "" });
            //var places = new List<PalcesViewModel>();

            //places = (from s in result.Data select new PalcesViewModel() { Id = s.Id, Name = s.DescriptionPlace }).ToList();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Search([FromBody] string searchPlace)
        {
            var result = await _mediator.Send(new PlacesQuery() { LikePlace = searchPlace });

            return View(result);
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _mediator.Send(new DetailsPlaceQuery() { Id = id });

            var details = new List<CategoryViewModel>();
            details = (from d in result.Data
                       select new CategoryViewModel()
                       {
                           Identificator = d.Identificator,
                           Name = d.Name,
                           PluralName = d.PluralName,
                           ShortName = d.ShortName,
                           Icono = d.Icon + d.IconSufix,
                           Id = d.Id
                       }).ToList();
            return View(details);
        }

        public async Task<IActionResult> Photos(int id)
        {
            var resutl = await _mediator.Send(new ViewPhotosCommand() { Id = id });
            var images = new List<PHotosPlaceViewModel>();
            images = (from i in resutl.Data
                      select new PHotosPlaceViewModel()
                      {
                          created_at = i.created_at,
                          height = i.height,
                          prefix = i.prefix,
                          suffix = i.suffix,
                          width = i.width,
                          id = i.id
                      }).ToList();
            return View(images);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}