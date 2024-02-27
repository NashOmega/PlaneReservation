using Core.Entities;
using System.Threading.Tasks;

namespace Core.Interfaces.Repository
{
    public interface IPlaneRepository : IRepositoryBase<PlaneEntity>
    {
        Task<IEnumerable<PlaneEntity>> FindAllPlanesByPageAsync(int page, int size);

        Task<IEnumerable<PlaneEntity>> FindAllAvailablePlanesByPageAsync(int page, int size);
    }
}
