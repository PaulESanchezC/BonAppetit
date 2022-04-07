﻿using Microsoft.AspNetCore.Authorization;
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
            if (string.IsNullOrEmpty(restaurantId))
            {
                ModelState.AddModelError("restaurantId", "The restaurantId field is required.");
                return BadRequest(ModelState);
            }

            var request = await _reservationService.GetByAsync(
                rsvp => rsvp.RestaurantId == restaurantId && rsvp.DateOfReservation >= DateTime.Now,
                cancellationToken);
            return StatusCode(request.StatusCode, request);
        }

        [HttpGet("GetAllExpiredReservationsForRestaurant/{restaurantId}")]
        public async Task<IActionResult> GetAllExpiredReservationsForRestaurant(string restaurantId,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(restaurantId))
            {
                ModelState.AddModelError("restaurantId", "The restaurantId field is required.");
                return BadRequest(ModelState);
            }

            var request = await _reservationService.GetByAsync(
                rsvp => rsvp.RestaurantId == restaurantId && rsvp.DateOfReservation < DateTime.Now,
                cancellationToken);
            return StatusCode(request.StatusCode, request);
        }

        [HttpGet("GetAllValidReservationsForClient/{clientId}")]
        public async Task<IActionResult> GetAllValidReservationsForClient(string clientId,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(clientId))
            {
                ModelState.AddModelError("clientId", "The clientId field is required.");
                return BadRequest(ModelState);
            }

            var request = await _reservationService.GetByAsync(
                rsvp => rsvp.ApplicationUserId == clientId && rsvp.DateOfReservation >= DateTime.Now,
                cancellationToken);
            return StatusCode(request.StatusCode, request);
        }

        [HttpGet("GetAllExpiredReservationsForClient/{clientId}")]
        public async Task<IActionResult> GetAllExpiredReservationsForClient(string clientId,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(clientId))
            {
                ModelState.AddModelError("clientId", "The clientId field is required.");
                return BadRequest(ModelState);
            }

            var request = await _reservationService.GetByAsync(
                rsvp => rsvp.ApplicationUserId == clientId && rsvp.DateOfReservation < DateTime.Now,
                cancellationToken);
            return StatusCode(request.StatusCode, request);
        }

        [HttpGet("GetReservationsForSingleTable/{tableId}")]
        public async Task<IActionResult> GetReservationsForSingleTable(string tableId,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(tableId))
            {
                ModelState.AddModelError("tableId", "The tableId field is required.");
                return BadRequest(ModelState);
            }

            var request = await _reservationService.GetByAsync(
                rsvp => rsvp.TableId == tableId && rsvp.DateOfReservation >= DateTime.Now,
                cancellationToken);
            return StatusCode(request.StatusCode, request);
        }

        [Authorize]//TODO: Implement Tests once this endpoint and methods dependent are complete
        [HttpPost("MakeReservation")]
        public async Task<IActionResult> MakeReservation([FromBody] ReservationDto reservationToMake,
            CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var request = await _reservationService.CreateAsync(reservationToMake, cancellationToken);
            return StatusCode(request.StatusCode, request);
        }
    }
}
