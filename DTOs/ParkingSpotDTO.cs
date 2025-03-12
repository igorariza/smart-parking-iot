using System;

namespace SmartParkingLotManagement.DTOs
{
    public class ParkingSpotDTO
    {
        public string? Id { get; set; }
        public bool? IsOccupied { get; set; }
        public string? DeviceId { get; set; }
    }
}