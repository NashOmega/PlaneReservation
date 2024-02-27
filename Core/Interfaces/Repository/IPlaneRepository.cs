using Core.Entities;
using System.Threading.Tasks;

namespace Core.Interfaces.Repository
{
    public interface IPlaneRepository : IRepositoryBase<PlaneEntity>
    {
        Task<IEnumerable<PlaneEntity>> FindAllPlanesByPage(int page, int size);

        Task<IEnumerable<PlaneEntity>> FindAllAvailablePlanesByPage(int page, int size);
    }
}
