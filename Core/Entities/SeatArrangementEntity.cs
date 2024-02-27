
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("SeatArrangement")]
    public class SeatArrangementEntity
    {
       
        public int Id { get; set; } 
        public string SeatNumber { get; set; } = string.Empty;
        public bool Status { get; set; } = true;

        public int PlaneId { get; set; }
        public PlaneEntity Plane { get; set; } = new PlaneEntity();

    }
}
