using Core.Entities;

namespace Core.Response
{
    public class PlaneResponse
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Serial { get; set; } = string.Empty;
        public int AvailableSeats { get; set; }
    }
}
