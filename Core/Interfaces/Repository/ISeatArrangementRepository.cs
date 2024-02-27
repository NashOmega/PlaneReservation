using Core.Entities;

namespace Core.Interfaces.Repository
{
    public interface ISeatArrangementRepository : IRepositoryBase<SeatArrangementEntity>
    {
        Task<SeatArrangementEntity> FindAvailableSeat(int planeId);
    }
}
