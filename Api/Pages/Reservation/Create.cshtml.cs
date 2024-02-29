using Core.Interfaces.Services;
using Core.Request;
using Core.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Api.Pages.Reservation
{
    public class CreateModel : PageModel
    {
        private readonly IPlaneService _planeService;
        private readonly IReservationService _reservationService;

        public IEnumerable<PlaneResponse> PlaneList { get; set; } = new List<PlaneResponse>();

        [BindProperty]
        public ReservationRequest ReservationRequest { get; set; } = new ReservationRequest();
        public CreateModel(IPlaneService planeService, IReservationService reservationService)
        {
            _planeService = planeService;
            _reservationService = reservationService;
        }

        public async Task<IActionResult> OnGet(int passengersNumber)
        {
            var res = await _planeService.GetAvailablePlanes(); ;
            if (res.Success)
            {
                if(res.Data != null) PlaneList = res.Data;
                for (int i = 0; i< passengersNumber; i++)
                {
                    var PassengerRequest = new PassengerRequest();
                    ReservationRequest.PassengerRequests.Add(PassengerRequest);
                }
                return Page();
            }
            else
            {
                ModelState.AddModelError("", res.Message);
                TempData["error"] = "Try later. The plane list is unavailable";
                return Page();
            }
        }
        public async Task<IActionResult> OnPost()
        {
            var planesRes = await _planeService.GetAvailablePlanes();
            if (planesRes.Success && planesRes.Data != null) PlaneList = planesRes.Data;
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var res = await _reservationService.CreateReservation(ReservationRequest);
            if (res.Success)
            {
                TempData["success"] = res.Message;
                return RedirectToPage("/Reservation/details", new { id = res.Data?.Id });
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
