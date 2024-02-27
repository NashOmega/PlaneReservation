using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("Plane")]
    public class PlaneEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Serial { get; set; } = string.Empty;
        public int Capacity { get; set; } = 200;
        public int AvailableSeats { get; set; } = 200;

        public ICollection<ReservationEntity> Reservations { get; set; } = new List<ReservationEntity>();

        public PlaneEntity()
        {
        }
    }
}
