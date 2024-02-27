using Core.Entities;
using Core.Request;
using Core.Response;

namespace Core.Interfaces.Services
{
    public interface IPassengerService
    {
        Task<MainResponse<ICollection<PassengerResponse>>> AddOrUpadatePassengers(ICollection<PassengerRequest> passengerRequests);

        Task<PassengerResponse?> UpdatePassenger(PassengerEntity passenger);

        Task<PassengerResponse?> AddPassenger(PassengerEntity passenger);
    }
}
