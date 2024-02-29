using Core.Interfaces.Services;
using Core.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Drawing;

namespace Api.Pages.Plane
{
    public class IndexModel : PageModel
    {
        private readonly IPlaneService _planeService;

        [BindProperty]
        public IEnumerable<PlaneResponse> planeList { get; set; } = new List<PlaneResponse>();

        
        public IndexModel(IPlaneService planeService)
        {
            _planeService = planeService;
        }

        public async Task<IActionResult> OnGet(int pageNumber)
        {
          if(pageNumber > 1)
            {
                return await OnGetMore(pageNumber);
            }
            var res = await _planeService.GetPlanesByPage(1, 15);
            if (res.Success)
            {
               if (res.Data != null) planeList = res.Data;
                return Page();
            }
           
            ModelState.AddModelError("", res.Message);
            TempData["error"] = res.Message;
            return Page();
            
        }

        public async Task<IActionResult> OnGetMore(int pageNumber)
        {

            var res = await _planeService.GetPlanesByPage(pageNumber, 15);
            if (res.Success)
            {
                if (res.Data != null) planeList = res.Data;
                var content = JsonConvert.SerializeObject(planeList);
                return Content(content, "application/json");
            }

            ModelState.AddModelError("", res.Message);
            TempData["error"] = res.Message;
            return Content("");   
        }
    }
}
