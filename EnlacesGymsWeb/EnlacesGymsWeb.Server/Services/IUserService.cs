using Application.Helpers;
using Domain.Entities;

namespace EnlacesGymsWeb.Server.Services
{
    public interface IUserService
    {
        Task<Usuario> GetUserByEmailAsync(string email);
    }
}
