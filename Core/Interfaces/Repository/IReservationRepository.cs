using Core.Entities;

namespace Core.Interfaces.Repository
{
    public interface IReservationRepository : IRepositoryBase<ReservationEntity>
    {
        Task<ReservationEntity?> FindByIdIncludePassengers(int id);
    }
}
