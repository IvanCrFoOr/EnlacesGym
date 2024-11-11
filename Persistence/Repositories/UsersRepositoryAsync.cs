using Application.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class UsersRepositoryAsync : GenericRepositoryAsync<Usuario>, IUsersRepositoryAsync
    {
        private readonly DbSet<Usuario> _usuarios;

        public UsersRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _usuarios = dbContext.Set<Usuario>();
        }
    }
}
