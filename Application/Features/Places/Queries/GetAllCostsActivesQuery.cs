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
    public class GetAllCostsActivesQuery : IRequest<Response<List<CatCosts>>>
    {
        public class GetAllCostsActivesQueryHandler : IRequestHandler<GetAllCostsActivesQuery, Response<List<CatCosts>>>
        {
            public readonly ICatCostsRepositoryAsync _catCostsRepository;

            public GetAllCostsActivesQueryHandler(ICatCostsRepositoryAsync catCostsRepository)
            {
                _catCostsRepository = catCostsRepository;
            }

            public async Task<Response<List<CatCosts>>> Handle(GetAllCostsActivesQuery query, CancellationToken cancellationToken)
            {
                var result = await _catCostsRepository.GetAllActives();

                return new Response<List<CatCosts>>(result) { Succeeded = true };
            }
        }
    }
}
