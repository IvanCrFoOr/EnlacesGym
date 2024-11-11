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
    public class PlacesPhotosRepositoryAsync : GenericRepositoryAsync<PlacesPhotos>, IPlacesPhotosRepositoryAsync
    {
        private readonly DbSet<PlacesPhotos> _photo;

        public PlacesPhotosRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _photo = dbContext.Set<PlacesPhotos>();
        }
    }
}
