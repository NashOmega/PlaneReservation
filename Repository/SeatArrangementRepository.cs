using Core.Data;
using Core.Entities;
using Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Repository
{
    public class SeatArrangementRepository : RepositoryBase<SeatArrangementEntity>, ISeatArrangementRepository
    {
        public SeatArrangementRepository(MiniProjetContext context, ILogger logger) : base(context, logger) { }

        public async Task<SeatArrangementEntity> FindAvailableSeat(int planeId)
        {
            return await _context.SeatArrangements.FirstAsync(s => s.Status == true && s.PlaneId == planeId);
        }

        public async Task GeneratePlaneSeats(PlaneEntity newPlane)
        {
            var positions = new List<string> { "A", "B", "C", "D", "E" };
            foreach (var position in positions)
            {
                for (int i = 1; i <= (newPlane.Capacity / positions.Count); i++)
                {
                    string seatNumber = position.ToString() + i.ToString();
                    SeatArrangementEntity newSeat = new()
                    {
                        SeatNumber = seatNumber,
                        Plane = newPlane
                    };
                    await _context.SeatArrangements.AddAsync(newSeat); 
                }
            }
        }
    }
}
