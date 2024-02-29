using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Api.Pages.Reservation
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        [Range(1, int.MaxValue, ErrorMessage = "The number of passengers must be greater than zero.")]
        public int PassengersNumber { get; set; } 
        public void OnGet()
        {
        }
        public ActionResult OnPost() {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            return RedirectToPage("/Reservation/Create", new { passengersNumber = PassengersNumber });
        }    
    }
}
