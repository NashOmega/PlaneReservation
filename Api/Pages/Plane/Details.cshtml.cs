using Api.Controllers.Interfaces;
using Core.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Api.Pages.Plane
{
    public class DetailsModel : PageModel
    {
        private readonly IPlaneController _planeController;

        [BindProperty]
        public PlaneResponse NewPlaneResponse { get; set; } = new PlaneResponse();
        public DetailsModel(IPlaneController planeController)
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
    }
}
