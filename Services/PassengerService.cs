using AutoMapper;
using Core.Entities;
using Core.Interfaces.Repository;
using Core.Interfaces.Services;
using Core.Request;
using Core.Response;
using Microsoft.Extensions.Logging;

namespace Services
{
    public class PassengerService : IPassengerService
    {
        private readonly IPassengerRepository _passengerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<PassengerService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="PassengerService"/> class.
        /// </summary>
        /// <param name="passengerRepository">The repository for handling passenger data.</param>
        /// <param name="mapper">The mapper for mapping between different types.</param>
        /// <param name="logger">The logger for logging messages.</param>
        public PassengerService(IPassengerRepository passengerRepository, IMapper mapper, ILogger<PassengerService> logger)
        {
            _passengerRepository = passengerRepository;
            _mapper = mapper;  
            _logger = logger;
        }

        /// <summary>
        /// Adds or Updated all provided passengers to the database.
        /// </summary>
        /// <param name="passengerRequests">The list of passenger information to add.</param>
        /// <returns>
        /// A MainResponse object containing list of details of the added and updates passengers if successful,
        /// otherwise, a MainResponse with the appropriate error message.
        /// </returns>
        public async Task<MainResponse<ICollection<PassengerResponse>>> AddOrUpadatePassengers(ICollection<PassengerRequest> passengerRequests)
        {
            var res = new MainResponse<ICollection<PassengerResponse>>();
            var message = "Passengers Added and Updated Successfully";
            try 
            { 
                foreach (PassengerRequest passengerRequest in passengerRequests)
                {
                    var dbPassenger = await _passengerRepository.FindByEmail(passengerRequest.Email);
                    if (dbPassenger==null)
                    {
                        var addedPassenger = await AddPassenger(_mapper.Map<PassengerEntity>(passengerRequest));
                        if (addedPassenger != null) res.Data?.Add(addedPassenger);
                    }
                    else
                    {
                        var updatePassenger = await UpdatePassenger(_mapper.Map(passengerRequest, dbPassenger));
                        if (updatePassenger != null) res.Data?.Add(updatePassenger);
                    }
                }
                res.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error Occured: {ErrorMessage}", ex.Message);
                message= ex.Message;
            }
            res.Message = message;
            return res;
        }

        /// <summary>
        /// Adds a new passenger to the database.
        /// </summary>
        /// <param name="passenger">The passenger entity to be added.</param>
        /// <returns>
        /// A PassengerResponse object containing information about the added passenger,
        /// or null if the passenger could not be added.
        /// </returns>
        public async Task<PassengerResponse?> AddPassenger(PassengerEntity passenger)
        {
                var createdPassenger = await _passengerRepository.Create(passenger);
                return _mapper.Map<PassengerResponse>(createdPassenger); 
        }


        /// <summary>
        /// Updates an existing passenger in the database.
        /// </summary>
        /// <param name="passenger">The passenger entity with updated information.</param>
        /// <returns>
        /// A PassengerResponse object containing information about the updated passenger,
        /// or null if the passenger could not be updated.
        /// </returns>
        public async Task<PassengerResponse?> UpdatePassenger(PassengerEntity passenger)
        {
            var updatedPassenger = await _passengerRepository.Update(passenger);
            return _mapper.Map<PassengerResponse>(updatedPassenger);
        }
    }
}
