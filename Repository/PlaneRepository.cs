using Core.Data;
using Core.Entities;
using Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class PlaneRepository : RepositoryBase<PlaneEntity>, IPlaneRepository
    {
        public PlaneRepository(MiniProjetContext context) : base(context) {   

        }
        public async Task<IEnumerable<PlaneEntity>> FindAllPlanesByPage(int page, int size)
        {
            int skip = (page - 1) * size;

            return await _context.Planes.Skip(skip).Take(size).ToListAsync();
        } 
        
        public async Task<IEnumerable<PlaneEntity>> FindAllAvailablePlanesByPage(int page, int size)
        {
            int skip = (page - 1) * size;

            return await _context.Planes.Where(p=> p.AvailableSeats !=0).Skip(skip).Take(size).ToListAsync();
        }
    }
}
