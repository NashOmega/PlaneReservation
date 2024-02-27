using Core.Data;
using Core.Entities;
using Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class PassengerRepository : RepositoryBase<PassengerEntity>, IPassengerRepository
    {
        public PassengerRepository(MiniProjetContext context) : base(context) {
       
        }
        public async Task<PassengerEntity?> FindByEmail(String Email)
        {
            return await _context.Passengers
                          .Include(p => p.Reservations)
                          .FirstOrDefaultAsync(p => p.Email == Email);
        }
    }
}
