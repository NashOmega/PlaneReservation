using System.ComponentModel.DataAnnotations;
namespace Core.Request
{
    public class PlaneRequest
    {
        [Required(ErrorMessage = "The plane name is required.")]
        [StringLength(45, MinimumLength = 3, ErrorMessage = "The plane name must be between {2} and {1} characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "The plane model is required.")]
        [StringLength(45, MinimumLength = 3, ErrorMessage = "The plane model must be between {2} and {1} characters.")]
        public string Model { get; set; } = string.Empty;

        [Required(ErrorMessage = "The plane serial number is required.")]
        [StringLength(45, MinimumLength = 3, ErrorMessage = "The plane serial must be between {2} and {1} characters.")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "The plane serial number must be alphanumeric.")]
        public string Serial { get; set; } = string.Empty;
    }
}
