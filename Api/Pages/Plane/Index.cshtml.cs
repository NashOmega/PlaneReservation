using Api.Controllers.Interfaces;
using Core.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Api.Pages.Plane
{
    public class IndexModel : PageModel
    {
        private readonly IPlaneController _planeController;

        [BindProperty]
        public IEnumerable<PlaneResponse> planeList { get; set; } = new List<PlaneResponse>();

        
        public IndexModel(IPlaneController planeController)
        {
            _planeController = planeController;
        }

        public async Task<IActionResult> OnGet(int pageNumber = 1, int size = 10 )
        {
          
            var res = await _planeController.GetAll(pageNumber, size);
            if (res.Value != null && res.Value.Success)
            {
                planeList = res.Value.Data;
                return Page();
            }
           
            ModelState.AddModelError("", res.Value.Message);
            TempData["error"] = res.Value.Message;
            return Page();
            
        }
    }
}
