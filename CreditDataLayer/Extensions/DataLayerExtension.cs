using CreditDataLayer.Context;
using CreditDataLayer.Repositories.Abstractions;
using CreditDataLayer.Repositories.Concretes;
using CreditDataLayer.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CreditDataLayer.Extensions
{
	public static class DataLayerExtension
    {
        public static IServiceCollection LoadDataLayerExtension(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddDbContext<AppDbContext>(option => option.UseSqlServer(config.GetConnectionString("Default")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
