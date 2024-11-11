using Application.Interface;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Application.Features.Places.Commands
{
    public class ViewPhotosCommand : IRequest<Response<List<PhotosViewModel>>>
    {
        public int Id { get; set; }

        public class ViewPhotosCommandHandler : IRequestHandler<ViewPhotosCommand, Response<List<PhotosViewModel>>>
        {
            private readonly ICategoryRespositoryasync _categoryRespositoryasync;

            public ViewPhotosCommandHandler(ICategoryRespositoryasync categoryRespositoryasync)
            {
                _categoryRespositoryasync = categoryRespositoryasync;
            }

            public async Task<Response<List<PhotosViewModel>>> Handle(ViewPhotosCommand query, CancellationToken cancellationToken)
            {
                var place = await _categoryRespositoryasync.GetAllByPlaceIdAsync(query.Id);
                //string fsqid = place.FirstOrDefault().Place.Fsq_id;
                //string url = $"https://api.foursquare.com/v3/places/{fsqid}/photos";
                //var clientOptions = new RestClientOptions(url);
                //var client = new RestClient(clientOptions);
                //var request = new RestRequest("");
                //request.AddHeader("Accept", "application/json");
                //request.AddHeader("Authorization", "fsq3suR9gk4mJN/Pp1DqLzVKyOgHS9ekL3P274kHAMt6s9M=");
                //var response = client.Get(request);
                //var content = response.Content;
                //var images = JsonConvert.DeserializeObject<List<PhotosViewModel>>(content);

                //foreach (var img in images)
                //{
                //    var model = new PlacesPhotos()
                //    {
                //        CreateDate = img.created_at,
                //        Height = img.height,
                //        RowId = img.id,
                //        UrlPhoto = img.suffix + img.prefix,
                //        Width = img.width
                //    };
                //    await _placesPhotos.AddAsync(model, "eliot369@gmail.com", 1, "Test", false);
                //}

                return new Response<List<PhotosViewModel>>();
            }
        }
    }
}
