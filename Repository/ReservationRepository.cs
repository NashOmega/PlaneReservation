

using Core.Data;
using Core.Entities;
using Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ReservationRepository : RepositoryBase<ReservationEntity>, IReservationRepository
    {
        public ReservationRepository(MiniProjetContext context) : base(context) { }

        public async Task<ReservationEntity?> FindByIdIncludePassengers(int id)
        {
            return await _context.Reservations
                          .Include(r => r.Passengers)
                          .FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
