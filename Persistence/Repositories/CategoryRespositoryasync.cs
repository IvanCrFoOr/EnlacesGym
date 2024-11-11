using Application.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;


namespace Persistence.Repositories
{
    public class CategoryRespositoryasync : GenericRepositoryAsync<Categories>, ICategoryRespositoryasync
    {
        private readonly DbSet<Categories> _categories;

        public CategoryRespositoryasync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _categories = dbContext.Set<Categories>();
        }

        public async Task<List<Categories>> GetAllByPlaceIdAsync(int placeId)
        {
            return await _categories.Include(x => x.Place)
                .Where(c => c.PlaceId == placeId).AsNoTracking().ToListAsync();
        }
    }
}
