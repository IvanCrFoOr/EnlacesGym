using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IUsersRepositoryAsync : IGenericRepositoryAsync<Usuario>
    {
        Task<Usuario> GetUserByEmailAsync(string email);
    }
}
