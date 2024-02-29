using Core.Interfaces.Services;
using Core.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Api.Pages.Reservation
{
    public class DetailsModel : PageModel
    {
        private readonly IReservationService _reservationService;

        [BindProperty]
        public ReservationResponse NewReservationResponse { get; set; } = new ReservationResponse();
        public DetailsModel(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            var res = await _reservationService.GetReservationById(id);
            if (res.Success)
            {
                if(res.Data != null) NewReservationResponse = res.Data;
                return Page();
            }
            else
            {
                ModelState.AddModelError("", res.Message);
                TempData["error"] = res.Message;
                return Page();
            }
        }
    }
}
