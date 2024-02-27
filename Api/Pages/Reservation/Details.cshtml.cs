using Api.Controllers;
using Api.Controllers.Interfaces;
using Core.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Api.Pages.Reservation
{
    public class DetailsModel : PageModel
    {
        private readonly IReservationController _reservationController;

        [BindProperty]
        public ReservationResponse NewReservationResponse { get; set; } = new ReservationResponse();
        public DetailsModel(IReservationController reservationController)
        {
            _reservationController = reservationController;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            var res = await _reservationController.Details(id);
            if (res.Value != null && res.Value.Success)
            {
                NewReservationResponse = res.Value.Data;
                Console.WriteLine();
                return Page();
            }
            else
            {
                ModelState.AddModelError("", res.Value.Message);
                TempData["error"] = res.Value.Message;
                return Page();
            }
        }
    }
}
