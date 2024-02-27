using Core.Response;
using Core.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Api.Controllers.Interfaces;

namespace Api.Pages.Plane
{
    public class EditModel : PageModel
    {
        private readonly IPlaneController _planeController;

        [BindProperty]
        public PlaneResponse NewPlaneResponse { get; set; } = new PlaneResponse();

        public EditModel(IPlaneController planeController)
        {
            _planeController = planeController;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            var res = await _planeController.Details(id);
            if (res.Value != null && res.Value.Success)
            {
                NewPlaneResponse = res.Value.Data;
                return Page();
            }
            else
            {
                ModelState.AddModelError("", res.Value.Message);
                TempData["error"] = res.Value.Message;
                return Page();
            }
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            PlaneRequest planeRequest = new()
            {
                Name = NewPlaneResponse.Name,
                Model = NewPlaneResponse.Model,
                Serial = NewPlaneResponse.Serial
            };

            var res = await _planeController.Edit(NewPlaneResponse.Id, planeRequest);
            if (res.Value != null && res.Value.Success)
            {
                TempData["success"] = res.Value.Message;
                return RedirectToPage("/Plane/details", new { id = res.Value.Data.Id });
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
