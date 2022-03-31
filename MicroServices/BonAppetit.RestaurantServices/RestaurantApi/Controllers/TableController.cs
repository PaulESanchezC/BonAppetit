﻿using Microsoft.AspNetCore.Mvc;
using Models.TableModels;
using Services.Repository.TableRepository;

namespace RestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ITableService _tableService;
        public TableController(ITableService tableService)
        {
            _tableService = tableService;
        }


        [HttpGet("GetAllRestaurantTable/{restaurantId}")]
        public async Task<IActionResult> GetAllRestaurantTable(string restaurantId, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(restaurantId))
            {
                ModelState.AddModelError("restaurantId","The restaurantId field is required.");
                return BadRequest(ModelState);
            }

            var request = await _tableService.GetAllByAsync(
                table=>table.RestaurantId == restaurantId,
                cancellationToken,
                include=>include.Restaurant);

            return StatusCode(request.StatusCode, request);
        }

        [HttpGet("GetSingleRestaurantTable/{tableId}")]
        public async Task<IActionResult> GetSingleRestaurantTable(string tableId, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(tableId))
            {
                ModelState.AddModelError("tableId", "The tableId field is required.");
                return BadRequest(ModelState);
            }

            var request = await _tableService.GetSingleByAsync(
                table => table.TableId == tableId,
                cancellationToken,
                include => include.Restaurant);

            return StatusCode(request.StatusCode, request);
        }

        [HttpPost("CreateTable")]
        public async Task<IActionResult> CreateTable([FromBody] TableCreate tableToCreate,
            CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var request = await _tableService.CreateAsync(tableToCreate, cancellationToken);
            return StatusCode(request.StatusCode, request);
        }

        [HttpPut("UpdateTable")]
        public async Task<IActionResult> UpdateTable([FromBody] TableDto tableToUpdate,
            CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var request = await _tableService.UpdateAsync(tableToUpdate, cancellationToken);
            return StatusCode(request.StatusCode, request);
        }

        [HttpDelete("DeleteTable/{tableId}")]
        public async Task<IActionResult> DeleteTable(string tableId, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(tableId))
            {
                ModelState.AddModelError("tableId","The tableId field is required.");
                return BadRequest(ModelState);
            }

            var request = await _tableService.DeleteAsync(tableId, cancellationToken);
            return StatusCode(request.StatusCode, request);
        }
    }
}
