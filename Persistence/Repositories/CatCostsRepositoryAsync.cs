using Application.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;


namespace Persistence.Repositories
{
    public class CatCostsRepositoryAsync : GenericRepositoryAsync<CatCosts>, ICatCostsRepositoryAsync
    {
        private readonly DbSet<CatCosts> _cost;
        public CatCostsRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _cost = dbContext.Set<CatCosts>();
        }

        public async Task<List<CatCosts>> GetAllActives()
        {
            return await _cost.Where(c => c.Active == true).AsNoTracking().ToListAsync();
        }
    }
}
