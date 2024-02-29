using Core.Interfaces.Services;
using Core.Request;
using Core.Response;
using Microsoft.AspNetCore.Mvc;


namespace Api.Controllers
{
    public class ReservationController : BaseController<ReservationController>
    {
        private readonly IReservationService _reservationService;
       
        public ReservationController(ILoggerFactory factory, IReservationService reservationService) : base(factory)
        {
            _reservationService = reservationService;
        }

        [HttpPost]
        public async Task<ActionResult<MainResponse<ReservationResponse>>> Create([FromBody] ReservationRequest reservationRequest)
        {
            var res = new MainResponse<ReservationResponse>();
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                    var errorMessage = string.Join("; ", errors);
                    res.Message = errorMessage;
                }
                else
                {
                    res = await _reservationService.CreateReservation(reservationRequest);
                }
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, "An Error Occured {message}", ex.Message);
                res.Message = ex.Message;
            }
            return res;
        }

        [HttpGet]
        public async Task<ActionResult<MainResponse<ReservationResponse>>> Details(int id)
        {
            var res = new MainResponse<ReservationResponse>();
            try
            {
                res = await _reservationService.GetReservationById(id);
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, "An Error Occured in ReservationController_Details : {message}", ex.Message);
                res.Message = ex.Message;
            }
            return res;

        }
    }
}
