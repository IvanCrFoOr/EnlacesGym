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
        public static void AddPersistenceInfraestructure(this IServiceCollection services, string connetionString)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                connetionString,
                b => {
                    b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                    b.UseNetTopologySuite();
                    }), ServiceLifetime.Transient);

            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            #region Entities
            services.AddTransient<ICategoryRespositoryasync, CategoryRespositoryasync>();
            services.AddTransient<ICatCostsRepositoryAsync, CatCostsRepositoryAsync>();
            services.AddTransient<IUsersRepositoryAsync, UsersRepositoryAsync>();
            #endregion
        }
    }
}