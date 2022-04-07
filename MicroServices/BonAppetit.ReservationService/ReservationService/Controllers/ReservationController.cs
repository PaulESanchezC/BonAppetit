using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.ReservationModels;
using Services.Repository.ReservationServices;

namespace ReservationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet("GetAllValidReservationsForRestaurant/{restaurantId}")]
        public async Task<IActionResult> GetAllReservationsForRestaurant(string restaurantId,
            CancellationToken cancellationToken)
        {
            var request = await _reservationService.GetAllByAsync(
                rsvp => rsvp.RestaurantId == restaurantId && rsvp.DateOfReservation >= DateTime.Now,
                cancellationToken);
            return StatusCode(request.StatusCode, request);
        }

        [HttpGet("GetAllExpiredReservationsForRestaurant/{restaurantId}")]
        public async Task<IActionResult> GetAllExpiredReservationsForRestaurant(string restaurantId,
            CancellationToken cancellationToken)
        {
            var request = await _reservationService.GetAllByAsync(
                rsvp => rsvp.RestaurantId == restaurantId && rsvp.DateOfReservation < DateTime.Now,
                cancellationToken);
            return StatusCode(request.StatusCode, request);
        }

        [HttpGet("GetAllValidReservationsForClient/{clientId}")]
        public async Task<IActionResult> GetAllValidReservationsForClient(string clientId,
            CancellationToken cancellationToken)
        {
            var request = await _reservationService.GetAllByAsync(
                rsvp => rsvp.ApplicationUserId == clientId && rsvp.DateOfReservation >= DateTime.Now,
                cancellationToken);
            return StatusCode(request.StatusCode, request);
        }

        [HttpGet("GetAllExpiredReservationsForClient/{clientId}")]
        public async Task<IActionResult> GetAllExpiredReservationsForClient(string clientId,
            CancellationToken cancellationToken)
        {
            var request = await _reservationService.GetAllByAsync(
                rsvp => rsvp.ApplicationUserId == clientId && rsvp.DateOfReservation < DateTime.Now,
                cancellationToken);
            return StatusCode(request.StatusCode, request);
        }

        [Authorize]
        [HttpPost("MakeReservation")]
        public async Task<IActionResult> MakeReservation([FromBody] ReservationDto reservationToMake,
            CancellationToken cancellationToken)
        {
            var request = await _reservationService.CreateAsync(reservationToMake, cancellationToken);
            return StatusCode(request.StatusCode, request);
        }
    }
}
