using Microsoft.AspNetCore.Mvc;
using SmartParkingLotManagement.DTOs;
using SmartParkingLotManagement.Models;
using SmartParkingLotManagement.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartParkingLotManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParkingSpotsController : ControllerBase
    {
        private readonly ParkingSpotService _parkingSpotService;

        public ParkingSpotsController(ParkingSpotService parkingSpotService)
        {
            _parkingSpotService = parkingSpotService;
        }

        [HttpPost("{id}/occupy")]
        public async Task<IActionResult> OccupySpot(string id, [FromBody] string deviceId)
        {
            var result = await _parkingSpotService.OccupySpotAsync(id, deviceId);
            if (result)
                return Ok();
            return BadRequest("Unable to occupy the spot.");
        }

        [HttpPost("{id}/free")]
        public async Task<IActionResult> FreeSpot(string id)
        {
            var result = await _parkingSpotService.FreeSpotAsync(id);
            if (result)
                return Ok();
            return BadRequest("Unable to free the spot.");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParkingSpotDTO>>> GetAllParkingSpots()
        {
            var spots = await _parkingSpotService.GetAllParkingSpotsAsync();
            return Ok(spots);
        }

        [HttpPost]
        public async Task<IActionResult> AddParkingSpot([FromBody] ParkingSpotDTO parkingSpotDto)
        {
            parkingSpotDto.Id = Guid.NewGuid().ToString();
            var result = await _parkingSpotService.AddParkingSpotAsync(parkingSpotDto);
            if (result)
                return CreatedAtAction(nameof(GetAllParkingSpots), new { id = parkingSpotDto.Id }, parkingSpotDto);
            return BadRequest("Unable to add parking spot.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveParkingSpot(string id)
        {
            var result = await _parkingSpotService.RemoveParkingSpotAsync(id);
            if (result)
                return NoContent();
            return NotFound("Parking spot not found.");
        }
    }
}