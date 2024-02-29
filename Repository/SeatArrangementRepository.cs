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

        public async Task<List<SeatArrangementEntity>> FindSuitableAvailableSeats(int quantity, int planeId)
        {
            return await _context.SeatArrangements
                .Where(s => s.Status == true && s.PlaneId == planeId)
                .Take(quantity)
                .ToListAsync();
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
