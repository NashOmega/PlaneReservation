using Core.Entities;

namespace Core.Response
{
    public class PassengerResponse
    {
        public int Id { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string SeatNumber { get; set; } = string.Empty;
    }
}
