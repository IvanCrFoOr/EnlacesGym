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
using Application.Features.Places.Queries.GetAllUsers;

namespace PlaceWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        
        private IMediator _mediator;
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IMediator mediator)
        {
            _logger = logger;
            _configuration = configuration;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _mediator.Send(new GetAllCostsActivesQuery());
            var costsmodel = new List<CostsViewModel>();
            costsmodel = (from c in list.Data
                          select new CostsViewModel() 
                          { 
                          Id = c.Id,
                          Cost = c.AmountCost,
                          Name = c.CostName
                          }).ToList();

                
            return View(costsmodel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Search(string search)
        {
            var result = await _mediator.Send(new GetAllUsersQuery() { name = search });

            return Json(new { success=true, result });
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
            //var resutl = await _mediator.Send(new ViewPhotosCommand() { Id = id });
            //var images = new List<PHotosPlaceViewModel>();
            //images = (from i in resutl.Data
            //          select new PHotosPlaceViewModel()
            //          {
            //              created_at = i.created_at,
            //              height = i.height,
            //              prefix = i.prefix,
            //              suffix = i.suffix,
            //              width = i.width,
            //              id = i.id
            //          }).ToList();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}