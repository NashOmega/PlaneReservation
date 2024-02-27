using Core.Entities;

namespace Core.Interfaces.Services
{
    public interface ISeatArrangementService
    {
        Task GeneratePlaneSeats(PlaneEntity plane);
    }
}
