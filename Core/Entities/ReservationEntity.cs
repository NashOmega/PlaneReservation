using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("Reservation")]
    public class ReservationEntity
    {
        public int Id { get; set; }

        public DateTime DepartureDate { get; set; }

        public string DepartureCity { get; set; } =  string.Empty;

        public int PlaneId {  get; set; }
        public PlaneEntity Plane { get; set; } = new PlaneEntity();

        public ICollection<PassengerEntity> Passengers { get; set; } = new List<PassengerEntity>();
        

    }
}
