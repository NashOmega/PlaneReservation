using Core.Interfaces.Services;
using Core.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Api.Pages.Plane
{
    public class DeleteModel : PageModel
    {
        private readonly IPlaneService _planeService;

        [BindProperty]
        public PlaneResponse NewPlaneResponse { get; set; } = new PlaneResponse();

        public DeleteModel(IPlaneService planeService)
        {
            _planeService = planeService;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            var res = await _planeService.GetPlaneById(id);
            if (res.Success)
            {
                if(res.Data != null ) NewPlaneResponse = res.Data;
                return Page();
            }
            else
            {
                ModelState.AddModelError("", res.Message);
                TempData["error"] = res.Message;
                return Page();
            }
        }

        public async Task<IActionResult> OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var res = await _planeService.DeletePlane(id);
            if (res.Success)
            {
                TempData["success"] = res.Message;
                return RedirectToPage("/Plane/Index");
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
