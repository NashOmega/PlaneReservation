using Core.Data;
using Core.Interfaces.Repository;
using Microsoft.Extensions.Logging;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly MiniProjetContext _context;

        public IPlaneRepository Planes {  get;}
        public IReservationRepository Reservations { get;}
        public ISeatArrangementRepository Seats { get;}

        public IPassengerRepository Passengers { get;}

        public UnitOfWork(MiniProjetContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            var logger = loggerFactory.CreateLogger("logs");

            Planes = new PlaneRepository(_context, logger);
            Reservations = new ReservationRepository(_context, logger);
            Seats = new SeatArrangementRepository(_context,logger);
            Passengers = new PassengerRepository(_context, logger); 
        }

        public async Task<bool> CompleteAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0 ;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
