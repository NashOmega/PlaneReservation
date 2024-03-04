using Core.Entities;

namespace Core.Interfaces.Repository
{
    public interface IPlaneRepository : IRepositoryBase<PlaneEntity>
    {
        Task<IEnumerable<PlaneEntity>> FindAllPlanesByPageAsync(int page, int size);

        Task<IEnumerable<PlaneEntity>> FindAvailablePlanesAsync();
    }
}
