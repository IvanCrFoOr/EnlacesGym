using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories;
using Application.Interface;

namespace Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("Develop"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            #region Entities
            services.AddTransient<IPlaceRepositoryAsync, PlaceRepositoryAsync>();
            services.AddTransient<ICategoryRespositoryasync, CategoryRespositoryasync>();
            services.AddTransient<IPlacesPhotosRepositoryAsync, PlacesPhotosRepositoryAsync>();
            services.AddTransient<ICatCostsRepositoryAsync, CatCostsRepositoryAsync>();
            #endregion
        }
    }
}