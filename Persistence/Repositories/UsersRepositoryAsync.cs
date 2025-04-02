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

        public Task<Usuario> GetUserByEmailAsync(string email)
        {
            return _usuarios.Include(u => u.Rol)
                //.ThenInclude(t => t.Modulo)
                //.Include(u => u.UserManagementDisables).ThenInclude(t => t.DisableReason).Include(r => r.CatArea).Include(u => u.CatCountry)
                .FirstOrDefaultAsync(u => u.Names == email);
        }
    }
}
