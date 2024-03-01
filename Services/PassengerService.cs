using AutoMapper;
using Core.Entities;
using Core.Interfaces.Repository;
using Core.Interfaces.Services;
using Core.Request;
using Microsoft.Extensions.Logging;

namespace Services
{
    public class PassengerService :ServiceBase<PassengerService>, IPassengerService
    {
        

        /// <summary>
        /// Initializes a new instance of the <see cref="PassengerService"/> class.
        /// </summary>
        /// <param name="passengerRepository">The repository for handling passenger data.</param>
        /// <param name="mapper">The mapper for mapping between different types.</param>
        /// <param name="logger">The logger for logging messages.</param>
        public PassengerService(IUnitOfWork unitOfWork, IMapper mapper, ILoggerFactory factory) 
            : base(unitOfWork, mapper, factory) { }

        /// <summary>
        /// Adds or Updated all provided passengers to the database.
        /// </summary>
        /// <param name="passengerRequests">The list of passenger information to add.</param>
        /// <returns>
        /// A MainResponse object containing list of details of the added and updates passengers if successful,
        /// otherwise, a MainResponse with the appropriate error message.
        /// </returns>
        public async Task<ICollection<PassengerEntity>> AddOrUpadatePassengers(ICollection<PassengerRequest> passengerRequests)
        {
            var passengersList = new List<PassengerEntity>();
            try 
            { 
                foreach (PassengerRequest passengerRequest in passengerRequests)
                {
                    var dbPassenger = await _unitOfWork.Passengers.FindByEmail(passengerRequest.Email);
                    if (dbPassenger==null)
                    {
                        var addedPassenger = await _unitOfWork.Passengers.CreateAsync(_mapper.Map<PassengerEntity>(passengerRequest));
                        if (addedPassenger != null) passengersList.Add(addedPassenger);
                    }
                    else
                    {
                        var updatePassenger = await _unitOfWork.Passengers.UpdateAsync(_mapper.Map(passengerRequest, dbPassenger));
                        if (updatePassenger != null) passengersList.Add(updatePassenger);
                    }
                }
                return passengersList;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error Occured: {ErrorMessage}", ex.Message);
                throw;
            }
            
        }
    }
}
