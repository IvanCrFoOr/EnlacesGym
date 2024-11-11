using Application.Interface;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestSharp;

namespace EjercicioNet.Pages
{
    //fsq3suR9gk4mJN/Pp1DqLzVKyOgHS9ekL3P274kHAMt6s9M=
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private IMediator _mediator;
        private readonly IPlaceRepositoryAsync _placeRepositoryAsync;
        public IndexModel(ILogger<IndexModel> logger, IMediator mediator, IPlaceRepositoryAsync placeRepositoryAsync)
        {
            _logger = logger;
            _mediator = mediator;
            _placeRepositoryAsync = placeRepositoryAsync;

            //var clientOptions = new RestClientOptions("https://api.foursquare.com/v3/places/search");
            //var client = new RestClient(clientOptions);
            //var request = new RestRequest("");
            //request.AddHeader("Accept", "application/json");
            //request.AddHeader("Authorization", "fsq3suR9gk4mJN/Pp1DqLzVKyOgHS9ekL3P274kHAMt6s9M=");
            //var response = client.Get(request);

            //var content = response.Content;
            //var model = new Domain.Entities.Place() 
            //{
            //    DescriptionPlace = "sadsadsadasd", Fsq_id = "4bb56f086edc76b0e9c72f1c"
            //};
            //_placeRepositoryAsync.AddAsync(model, "eliot369@gmail.com", 1, "Test", false);
        }

        public void OnGet()
        {

        }
    }
}