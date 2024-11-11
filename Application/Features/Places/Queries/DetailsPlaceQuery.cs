using Application.Interface;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Places.Queries
{
    public class DetailsPlaceQuery : IRequest<Response<List<Categories>>>
    {
        public int Id { get; set; }

        public class DetailsPlaceQueryHandler : IRequestHandler<DetailsPlaceQuery, Response<List<Categories>>>
        {
            private readonly ICategoryRespositoryasync _categoryRespository;

            public DetailsPlaceQueryHandler(ICategoryRespositoryasync categoryRespository)
            {
                _categoryRespository = categoryRespository;
            }

            public async Task<Response<List<Categories>>> Handle(DetailsPlaceQuery command, CancellationToken cancellationToken)
            {
                var query = await _categoryRespository.GetAllByPlaceIdAsync(command.Id);

                return new Response<List<Categories>>(query) {  Succeeded = true };
            }
        }
    }
}
