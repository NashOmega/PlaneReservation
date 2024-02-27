namespace Core.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        IPassengerRepository Passengers { get; }
        IPlaneRepository Planes { get; }
        IReservationRepository Reservations { get; }
        ISeatArrangementRepository Seats { get; }

        Task<bool> CompleteAsync();
    }
}
