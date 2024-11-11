using Application.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class PlaceRepositoryAsync : GenericRepositoryAsync<Place>, IPlaceRepositoryAsync
    {
        private readonly DbSet<Place> _places;
        public PlaceRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _places = dbContext.Set<Place>();
        }

    }
}
