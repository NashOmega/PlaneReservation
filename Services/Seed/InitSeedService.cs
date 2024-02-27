using Bogus;
using Core.Interfaces.SeedDatabase;
using Core.Interfaces.Services;
using Core.Request;

namespace Services.Seed
{
    public class InitSeedService : IInitSeedService
    {
        private readonly IPlaneService _planeService;

        public InitSeedService(IPlaneService planeService)
        {
            _planeService = planeService;
            
        }

        public async Task Seed()
        {
            var faker = new Faker();
            var planes = new Faker<PlaneRequest>()
                .RuleFor(p => p.Name, f => f.Company.CompanyName())
                .RuleFor(p => p.Model, f => f.Vehicle.Model())
                .RuleFor(p => p.Serial, f => f.Random.AlphaNumeric(6))
                .Generate(30);
           foreach (var plane in planes)
            {
                await _planeService.AddPlane(plane);
            }
        }
    }
}
