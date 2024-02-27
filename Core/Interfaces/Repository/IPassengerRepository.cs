using Core.Entities;
using System.Linq.Expressions;

namespace Core.Interfaces.Repository
{
    public interface IPassengerRepository : IRepositoryBase<PassengerEntity>
    {
        Task<PassengerEntity?> FindByEmail(String Email);
    }
}
