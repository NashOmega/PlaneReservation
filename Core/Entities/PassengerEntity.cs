using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table ("Passenger")]
    public class PassengerEntity
    {
        public int Id { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string SeatNumber { get; set; } = string.Empty;

        public ICollection<ReservationEntity> Reservations { get; set; } = new List<ReservationEntity>(); 
    }
}