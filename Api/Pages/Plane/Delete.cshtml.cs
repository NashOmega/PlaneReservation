using Api.Controllers.Interfaces;
using Core.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Api.Pages.Plane
{
    public class DeleteModel : PageModel
    {
        private readonly IPlaneController _planeController;

        [BindProperty]
        public PlaneResponse NewPlaneResponse { get; set; } = new PlaneResponse();

        public DeleteModel(IPlaneController planeController)
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

        public async Task<IActionResult> OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var res = await _planeController.Delete(id);
            if (res.Value != null && res.Value.Success)
            {
                TempData["success"] = res.Value.Message;
                return RedirectToPage("/Plane/Index");
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
