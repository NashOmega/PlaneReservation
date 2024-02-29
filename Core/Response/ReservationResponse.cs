using Core.Entities;

namespace Core.Response
{
    public class ReservationResponse
    {
        public int Id { get; set; }
        public DateTime DepartureDate { get; set; } = DateTime.Now;

        public string DepartureCity { get; set; } = string.Empty;

        public int PlaneId { get; set; }

        public ICollection<PassengerResponse> PassengerResponses { get; set; } = new List<PassengerResponse>();
    }
}
