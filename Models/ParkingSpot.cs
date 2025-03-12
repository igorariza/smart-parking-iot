namespace SmartParkingLotManagement.Models
{
    public class ParkingSpot
    {
         public Guid Id { get; set; }
        public bool? IsOccupied { get; set; }
        public string? DeviceId { get; set; }
    }
}