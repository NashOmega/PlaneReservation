using Api.Controllers.Interfaces;
using Core.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Api.Pages.Plane
{
    public class CreateModel : PageModel
    {
        private readonly IPlaneController _planeController;

        [BindProperty]
        public PlaneRequest NewPlaneRequest { get; set; } = new PlaneRequest();
        public CreateModel(IPlaneController planeController)
        {
           _planeController = planeController;
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

            var res = await _planeController.Create(NewPlaneRequest);
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
