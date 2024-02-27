using Api.Controllers;
using Api.Controllers.Interfaces;
using Core.Data;
using Core.Interfaces.Repository;
using Core.Interfaces.SeedDatabase;
using Core.Interfaces.Services;
using Core.Profiles;
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

            services.AddScoped<IPlaneRepository, PlaneRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IPassengerRepository, PassengerRepository>();
            services.AddScoped<ISeatArrangementRepository, SeatArrangementRepository>();

            services.AddScoped<IPlaneController, PlaneController>();
            services.AddScoped<IReservationController, ReservationController>();

            services.AddScoped<IPlaneService, PlaneService>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IPassengerService, PassengerService>();
            services.AddScoped<ISeatArrangementService, SeatArrangementService>();

            services.AddScoped<IInitSeedService, InitSeedService>();

        }
    }
}
