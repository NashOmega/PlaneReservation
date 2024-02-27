using Api.Controllers.Interfaces;
using Azure;
using Core.Request;
using Core.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Drawing;

namespace Api.Pages.Reservation
{
    public class CreateModel : PageModel
    {
        private readonly IPlaneController _planeController;
        private readonly IReservationController _reservationController;

        public IEnumerable<PlaneResponse> PlaneList { get; set; } = new List<PlaneResponse>();

        [BindProperty]
        public ReservationRequest ReservationRequest { get; set; } = new ReservationRequest();
        public CreateModel(IPlaneController planeController, IReservationController reservationController)
        {
            _planeController = planeController;
            _reservationController = reservationController;
        }

        public async Task<IActionResult> OnGet(int passengersNumber)
        {
            var res = await _planeController.GetAll(1, 10000);
            if (res.Value != null && res.Value.Success)
            {
                PlaneList = res.Value.Data;
                for (int i = 0; i< passengersNumber; i++)
                {
                    var PassengerRequest = new PassengerRequest();
                    ReservationRequest.PassengerRequests.Add(PassengerRequest);
                }
                return Page();
            }
            else
            {
                ModelState.AddModelError("", res.Value.Message);
                TempData["error"] = "Try later. The plane list is unavailable";
                return Page();
            }
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var res = await _reservationController.Create(ReservationRequest);
            if (res.Value != null && res.Value.Success)
            {
                TempData["success"] = res.Value.Message;
                return RedirectToPage("/Reservation/details", new { id = res.Value.Data.Id });
            }
            else
            {
                ModelState.AddModelError("", res.Value.Message);
                TempData["error"] = res.Value.Message;
                return RedirectToPage("/Reservation/Create", new { passengersNumber = ReservationRequest.PassengerRequests.Count });
            }
        }
    }
}
