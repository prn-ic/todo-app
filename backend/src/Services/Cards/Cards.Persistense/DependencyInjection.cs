using Cards.Persistense.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static partial class DependencyInjection
    {
        public static IServiceCollection AddPersistenseLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(o =>
            {
                o.UseSnakeCaseNamingConvention();
                o.UseNpgsql(connectionString: configuration.GetConnectionString("Cards"),
                    b => b.MigrationsAssembly("Cards.WebApi")).UseSnakeCaseNamingConvention();
            });


            return services;
        }
    }
}