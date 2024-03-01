using Core.Entities;
using Core.Request;

namespace Core.Interfaces.Services
{
    public interface IPassengerService
    {
        Task<ICollection<PassengerEntity>> AddOrUpadatePassengers(ICollection<PassengerRequest> passengerRequests);
    }
}
