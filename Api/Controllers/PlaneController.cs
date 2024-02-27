using Api.Controllers.Interfaces;
using Core.Entities;
using Core.Interfaces.Services;
using Core.Request;
using Core.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using X.PagedList;

namespace Api.Controllers
{
    public class PlaneController :  BaseController<PlaneController>, IPlaneController
    {
        private readonly IPlaneService _planeService;
        public PlaneController(ILoggerFactory factory, IPlaneService planeService) : base(factory) 
        {
            _planeService = planeService;
        }

        [HttpGet]
        public async Task<ActionResult<MainResponse<IEnumerable<PlaneResponse>>>> GetAll(int page, int size)
        {
            var res = new MainResponse<IEnumerable<PlaneResponse>>();
            try
            {
                res = await _planeService.GetPlanesByPage(page, size);
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, "An Error Occured in PlaneController_GetAllPlanes : {message}", ex.Message);
                res.Message = ex.Message;
            }
            return res;
        }
        
        [HttpGet]
        public async Task<ActionResult<MainResponse<IEnumerable<PlaneResponse>>>> GetAllAvailable(int page, int size)
        {
            var res = new MainResponse<IEnumerable<PlaneResponse>>();
            try 
            {
                res = await _planeService.GetAvailablePlanesByPage(page, size);
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, "An Error Occured in PlaneController_GetAvailablePlanesByPage : {message}", ex.Message);
                res.Message = ex.Message;
            }
            return res;
        }

        [HttpGet]
        public async Task<ActionResult<MainResponse<PlaneResponse>>> Details(int id)
        {
            var res = new MainResponse<PlaneResponse>();
            try
            {
                res = await _planeService.GetPlaneById(id);
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, "An Error Occured in PlaneController_Details : {message}", ex.Message);
                res.Message = ex.Message;
            }
            return res;

        }

        [HttpPost]
        public async Task<ActionResult<MainResponse<PlaneResponse>>> Create([FromBody] PlaneRequest planeRequest)
        {
            var res = new MainResponse<PlaneResponse>();
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                    var errorMessage = string.Join("; ", errors);
                    res.Message = errorMessage;
                }
                else {
                    res = await _planeService.AddPlane(planeRequest);
                }
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, "An Error Occured in  PlaneController_Create : {message}", ex.Message);
                res.Message = ex.Message;
            }
            return res;
        }

        [HttpPut]
        public async Task<ActionResult<MainResponse<PlaneResponse>>> Edit(int id, [FromBody] PlaneRequest planeRequest)
        {
            var res = new MainResponse<PlaneResponse>();
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                    var errorMessage = string.Join("; ", errors);
                    res.Message= errorMessage;
                }
                else
                {
                   res = await _planeService.UpdatePlane(id, planeRequest);
                }
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, "An Error Occured in PlaneController_Edit : {message}", ex.Message);
                res.Message = ex.Message;
            }
            return res;
        }

        [HttpDelete]
        public async Task<ActionResult<MainResponse<bool>>> Delete(int id)
        {
            var res = new MainResponse<bool>();
            try 
            { 
                 res = await _planeService.DeletePlane(id);
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, "An Error Occured in PlaneController_Delete : {message}", ex.Message);
                res.Message = ex.Message;
            }
            return res;
        }
    }
}
