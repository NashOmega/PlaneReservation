using Core.Interfaces.Services;
using Core.Request;
using Core.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Api.Pages.Plane
{
    public class EditModel : PageModel
    {
        private readonly IPlaneService _planeService;

        [BindProperty]
        public PlaneResponse NewPlaneResponse { get; set; } = new PlaneResponse();

        public EditModel(IPlaneService planeService)
        {
            _planeService = planeService;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            var res = await _planeService.GetPlaneById(id);
            if (res.Success)
            {
                if(res.Data !=null) NewPlaneResponse = res.Data;
                return Page();
            }
            else
            {
                ModelState.AddModelError("", res.Message);
                TempData["error"] = res.Message;
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

            var res = await _planeService.UpdatePlane(NewPlaneResponse.Id, planeRequest);
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
