using Core.Data;
using Core.Entities;
using Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Repository
{
    public class PlaneRepository : RepositoryBase<PlaneEntity>, IPlaneRepository
    {
        public PlaneRepository(MiniProjetContext context,ILogger logger ) : base(context, logger) {   

        }
        public async Task<IEnumerable<PlaneEntity>> FindAllPlanesByPageAsync(int page, int size)
        {
            int skip = (page - 1) * size;

            return await _context.Planes.Skip(skip).Take(size).ToListAsync();
        } 
        
        public async Task<IEnumerable<PlaneEntity>> FindAvailablePlanesAsync()
        {
            return await _context.Planes.Where(p=> p.AvailableSeats !=0).ToListAsync();
        }
    }
}
