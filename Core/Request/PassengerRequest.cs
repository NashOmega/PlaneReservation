
using System.ComponentModel.DataAnnotations;

namespace Core.Request
{
    public class PassengerRequest
    {
        [Required(ErrorMessage = "The Passenger LastName is required.")]
        [StringLength(45, MinimumLength = 3, ErrorMessage = "The Passenger FistName must be between {2} and {1} characters.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "The Passenger FirstName is required.")]
        [StringLength(45, MinimumLength = 3, ErrorMessage = "The Passenger FirstName must be between {2} and {1} characters.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "The Passenger Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = string.Empty;

    }
}
