using Core.Data;
using Core.Entities;
using Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Repository
{
    public class ReservationRepository : RepositoryBase<ReservationEntity>, IReservationRepository
    {
        public ReservationRepository(MiniProjetContext context,ILogger logger) : base(context, logger) { }

        public async Task<ReservationEntity?> FindByIdIncludePassengers(int id)
        {
            return await _context.Reservations
                        .Include(r => r.Passengers)
                        .FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
