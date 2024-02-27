using Core.Request;
using Core.Response;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Interfaces
{
    public interface IPlaneController
    {
        Task<ActionResult<MainResponse<IEnumerable<PlaneResponse>>>> GetAll(int page, int size);
        Task<ActionResult<MainResponse<IEnumerable<PlaneResponse>>>> GetAllAvailable(int page, int size);
        Task<ActionResult<MainResponse<bool>>> Delete(int id);
        Task<ActionResult<MainResponse<PlaneResponse>>> Edit(int id, [FromBody] PlaneRequest planeRequest);
        Task<ActionResult<MainResponse<PlaneResponse>>> Create([FromBody] PlaneRequest planeRequest);
        Task<ActionResult<MainResponse<PlaneResponse>>> Details(int id);
    }
}
