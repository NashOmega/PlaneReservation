using Core.Request.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Core.Request
{
    public class ReservationRequest
    {
        [Required(ErrorMessage = "The Reservation DepartureDate is required.")]
        [FutureDate(ErrorMessage = "The Reservation DepartureDate must be in the future.")]
        public DateTime DepartureDate { get; set; }

        [Required(ErrorMessage = "The Reservation DepartureCity is required.")]
        [StringLength(45, MinimumLength = 3, ErrorMessage = "The Reservation DepartureCity must be between {2} and {1} characters.")]
        public string DepartureCity { get; set; } = string.Empty;

        [Required(ErrorMessage = "The Reservation planeId is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The planeId must be greater than 0.")]
        public int PlaneId { get; set; }

        [Required(ErrorMessage = "At least one passenger is required.")]
        [MinLength(1, ErrorMessage = "At least one passenger is required.")]
        public ICollection<PassengerRequest> PassengerRequests { get; set; } = new List<PassengerRequest>();


    }
}
