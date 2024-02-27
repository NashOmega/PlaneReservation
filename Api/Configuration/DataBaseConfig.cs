using Core.Data;
using Core.Interfaces.SeedDatabase;
using Microsoft.EntityFrameworkCore;

namespace Api.Configuration
{

    public static class DatabaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<MiniProjetContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("Core"));
            });
        }

        public static void InitializeDbTestDataAsync(this IApplicationBuilder app)
        {
            using (var serviceScope = app?.ApplicationServices?.GetService<IServiceScopeFactory>()?.CreateScope())
            {
                if (serviceScope != null)
                {
                    serviceScope.ServiceProvider.GetRequiredService<MiniProjetContext>().Database.Migrate();
                    var context = serviceScope.ServiceProvider.GetRequiredService<MiniProjetContext>();
                    context.Database.EnsureCreated();
                    if (!context.Planes.Any())
                    {
                        var initSeed = serviceScope.ServiceProvider.GetRequiredService<IInitSeedService>();
                        initSeed.Seed().Wait();
                    }
                }
            }
        }
    }
}
