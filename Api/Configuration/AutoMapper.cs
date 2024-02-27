using Core.Data;
using Core.Interfaces.Repository;
using Core.Interfaces.SeedDatabase;
using Core.Interfaces.Services;
using Core.Profiles;
using Repository;
using Services;

namespace Api.Configuration
{
    public static class AutoMapper
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(Program));
            services.AddAutoMapper(typeof(EntityToResponseProfile));
            services.AddAutoMapper(typeof(RequestToEntityProfile));

        }
    }
}
