using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Api.Pages.Reservation
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public int PassengersNumber { get; set; } 
        public void OnGet()
        {
        }
        public ActionResult OnPost() {
            return RedirectToPage("/Reservation/Create", new { passengersNumber = PassengersNumber });
        }    
    }
}
