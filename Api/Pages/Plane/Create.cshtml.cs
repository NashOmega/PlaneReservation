using Core.Interfaces.Services;
using Core.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Api.Pages.Plane
{
    public class CreateModel : PageModel
    {
        private readonly IPlaneService _planeService;

        [BindProperty]
        public PlaneRequest NewPlaneRequest { get; set; } = new PlaneRequest();
        public CreateModel(IPlaneService planeService)
        {
           _planeService = planeService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var res = await _planeService.AddPlane(NewPlaneRequest);
            if (res.Success)
            {
                TempData["success"] = res.Message;
                return RedirectToPage("/Plane/details", new { id = res.Data?.Id });
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
