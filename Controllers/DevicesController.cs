using Microsoft.AspNetCore.Mvc;
using SmartParkingLotManagement.DTOs;
using SmartParkingLotManagement.Models;
using SmartParkingLotManagement.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartParkingLotManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly DeviceService _deviceService;

        public DevicesController(DeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterDevice([FromBody] DeviceDTO deviceDto)
        {
            if (deviceDto == null)
            {
                return BadRequest("Device data is required.");
            }
            if (string.IsNullOrEmpty(deviceDto.Id))
            {
                return BadRequest("Device ID is required.");
            }

            var device = new Device
            {
                Id = Guid.Parse(deviceDto.Id),
                IsRegistered = deviceDto.IsRegistered
            };

            var result = await _deviceService.RegisterDeviceAsync(device);
            if (result)
            {
                return Ok("Device registered successfully.");
            }

            return BadRequest("Device registration failed.");
        }

        [HttpPost("validate")]
        public async Task<IActionResult> ValidateDevice([FromBody] string deviceId)
        {
            if (string.IsNullOrEmpty(deviceId))
            {
                return BadRequest("Device ID is required.");
            }

            var isValid = await _deviceService.ValidateDeviceAsync(deviceId);
            if (isValid)
            {
                return Ok("Device is valid.");
            }

            return Unauthorized("Device is not registered.");
        }
    }
}