using Application.Interface;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features
{
    public class SearchPlaceQuery : IRequest<Response<List<Place>>>
    {
        public string place { get; set; }

        public class SearchPlaceQueryHandler : IRequestHandler<SearchPlaceQuery, Response<List<Place>>>
        {
            private readonly IPlaceRepositoryAsync _placeRepository;
            private readonly ICatCostsRepositoryAsync _catCostsRepositoryAsync;

            public SearchPlaceQueryHandler(IPlaceRepositoryAsync placeRepository, ICatCostsRepositoryAsync catCostsRepositoryAsync)
            {
                _placeRepository = placeRepository;
                _catCostsRepositoryAsync = catCostsRepositoryAsync;
            }

            public async Task<Response<List<Place>>> Handle(SearchPlaceQuery request, CancellationToken cancellationToken)
            {
                var costs = await _catCostsRepositoryAsync.GetAllActives();
                var listModel = new List<Place>();
                if (placeItem == null)
                {
                    return null;
                }
                else
                {
                    foreach(var item in placeItem)
                    {
                        listModel.Add(new Place { Id = item.Id, DescriptionPlace = item.Fsq_id });
                    }
                    return new Response<List<Place>>(listModel);
                }
            }
        }
    }
}
