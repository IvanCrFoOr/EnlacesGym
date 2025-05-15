using Application.Interface;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Application.Features.Places.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<Response<List<GetAllUsersViewModel>>>
    {
        public string name { get; set; }

        public class PlacesQueryHandler : IRequestHandler<GetAllUsersQuery, Response<List<GetAllUsersViewModel>>>
        {
            private readonly IUsersRepositoryAsync _usersRepository;
            private readonly ICategoryRespositoryasync _categoryRespositoryasync;

            public PlacesQueryHandler(ICategoryRespositoryasync categoryRespositoryasync, IUsersRepositoryAsync usersRepositoryAsync)
            {
                _categoryRespositoryasync = categoryRespositoryasync;
                _usersRepository = usersRepositoryAsync;
            }

            public async Task<Response<List<GetAllUsersViewModel>>> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
            {
                var list = await _usersRepository.GetAllAsync("");
                var model = new List<GetAllUsersViewModel>();
                foreach(var i in list)
                {
                    model.Add(new GetAllUsersViewModel { UserId = i.Id, Names = i.Names });
                }

                return new Response<List<GetAllUsersViewModel>>(model) { Succeeded = true };
            }
        }
    }
}
