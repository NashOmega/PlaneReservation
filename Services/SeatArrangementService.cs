using AutoMapper;
using Core.Entities;
using Core.Interfaces.Repository;
using Core.Interfaces.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;


namespace Services
{
    public  class SeatArrangementService : ISeatArrangementService
    {
        private readonly ISeatArrangementRepository _seatArrangementRepository;
        private readonly ILogger<SeatArrangementService> _logger;


        /// <summary>
        /// Initializes a new instance of the <see cref="SeatArrangementService"/> class.
        /// </summary>
        /// <param name="seatArrangementRepository">The repository for handling reservation data.</param>
        /// <param name="logger">The logger for logging messages.</param>
        public SeatArrangementService(ISeatArrangementRepository seatArrangementRepository,  ILogger<SeatArrangementService> logger)
        {
            _seatArrangementRepository = seatArrangementRepository;
            _logger = logger;
        }
        public async Task GeneratePlaneSeats(PlaneEntity newPlane)
        {
            var positions = new List<string> { "A", "B", "C", "D", "E" };
            foreach (var position in positions)
            {
                for (int i = 1; i<=(newPlane.Capacity/positions.Count);  i++)
                {
                    string seatNumber = position.ToString() + i.ToString();
                    SeatArrangementEntity newSeat = new()
                    {
                        SeatNumber = seatNumber,
                        Plane = newPlane
                    };
                    await _seatArrangementRepository.Create(newSeat);
                }
            }
        }
    }
}
