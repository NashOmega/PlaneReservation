using Api.Controllers;
using Api.Controllers.Interfaces;
using Core.Interfaces.Repository;
using Core.Interfaces.SeedDatabase;
using Core.Interfaces.Services;
using Repository;
using Services;
using Services.Seed;

namespace Api.Configuration
{
    public static class DependenciesInjection
    {
        public static void AddDependenciesInjection(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IPlaneController, PlaneController>();
            services.AddScoped<IReservationController, ReservationController>();

            services.AddScoped<IPlaneService, PlaneService>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IPassengerService, PassengerService>();

            services.AddScoped<IInitSeedService, InitSeedService>();

        }
    }
}
