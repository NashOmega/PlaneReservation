using Core.Data;
using Core.Entities;
using Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class SeatArrangementRepository : RepositoryBase<SeatArrangementEntity>, ISeatArrangementRepository
    {
        public SeatArrangementRepository(MiniProjetContext context) : base(context) { }

        public async Task<SeatArrangementEntity> FindAvailableSeat(int planeId)
        {
            return await _context.SeatArrangements.FirstAsync(s => s.Status == true && s.PlaneId == planeId);
        }
    }
}
