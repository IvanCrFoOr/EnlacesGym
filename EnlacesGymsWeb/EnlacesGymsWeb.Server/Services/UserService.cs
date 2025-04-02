using Application.Interface;
using Domain.Entities;

namespace EnlacesGymsWeb.Server.Services
{
    public class UserService : IUserService
    {
        private readonly IUsersRepositoryAsync _userService;

        public UserService(IUsersRepositoryAsync UserRepository)
        {
            _userService = UserRepository;
        }
        public async Task<Usuario> GetUserByEmailAsync(string email)
        {
            return await _userService.GetUserByEmailAsync(email);
        }
    }
}
