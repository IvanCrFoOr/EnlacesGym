using Application.Interface;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace Application.Features.Places
{
    public class PlacesQuery : IRequest<Response<string>>
    {
        public string LikePlace { get; set; }

        public class PlacesQueryHandler : IRequestHandler<PlacesQuery, Response<string>>
        {
            private readonly IPlaceRepositoryAsync _placeRepository;
            private readonly ICategoryRespositoryasync _categoryRespositoryasync;

            public PlacesQueryHandler(IPlaceRepositoryAsync placeRepository, ICategoryRespositoryasync categoryRespositoryasync)
            {
                _placeRepository = placeRepository;
                _categoryRespositoryasync = categoryRespositoryasync;
            }

            public async Task<Response<string>> Handle(PlacesQuery query, CancellationToken cancellationToken)
            {

                var clientOptions = new RestClientOptions("https://api.foursquare.com/v3/places/search?" + query.LikePlace);
                var client = new RestClient(clientOptions);
                var request = new RestRequest("");
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Authorization", "fsq3suR9gk4mJN/Pp1DqLzVKyOgHS9ekL3P274kHAMt6s9M=");
                var response = client.Get(request);
                var content = response.Content;
                var serie = JsonConvert.DeserializeObject<ResultPlacesModel.Root>(content);
                foreach (var item in serie.results)
                {
                    var model = new Domain.Entities.Place()
                    {
                        DescriptionPlace = item.name,
                        Fsq_id = item.fsq_id
                    };
                    var add = await _placeRepository.AddAsync(model, "eliot369@gmail.com", 1, "Test", false);
                    foreach(var itm in item.categories)
                    {
                        var modelcategory = new Domain.Entities.Categories()
                        {
                            Icon = itm.icon.prefix.ToString(),
                            IconSufix = itm.icon.suffix,
                            Name = itm.name,
                            Identificator = itm.id,
                            PluralName = itm.plural_name,
                            ShortName = itm.short_name,
                            PlaceId = model.Id
                        };
                        await _categoryRespositoryasync.AddAsync(modelcategory, "eliot369@gmail.com", 1, "Test", false);
                    }
                }
                return new Response<string>(query.LikePlace);
            }
        }
    }
}
