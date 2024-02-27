using Core.Request;
using Core.Response;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Interfaces
{
    public interface IReservationController
    {
        Task<ActionResult<MainResponse<ReservationResponse>>> Create([FromBody] ReservationRequest reservationRequest);

        Task<ActionResult<MainResponse<ReservationResponse>>> Details(int id);
    }
}
