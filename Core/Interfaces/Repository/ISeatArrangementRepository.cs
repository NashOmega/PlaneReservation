using Core.Entities;

namespace Core.Interfaces.Repository
{
    public interface ISeatArrangementRepository : IRepositoryBase<SeatArrangementEntity>
    {
        Task<List<SeatArrangementEntity>> FindSuitableAvailableSeats(int quantity, int planeId);

        Task GeneratePlaneSeats(PlaneEntity newPlane);
    }
}
