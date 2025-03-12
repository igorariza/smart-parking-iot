using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartParkingLotManagement.DTOs;
using SmartParkingLotManagement.Models;
using SmartParkingLotManagement.Repositories;

namespace SmartParkingLotManagement.Services
{
    public class ParkingSpotService
    {
        private readonly IParkingSpotRepository _parkingSpotRepository;

        public ParkingSpotService(IParkingSpotRepository parkingSpotRepository)
        {
            _parkingSpotRepository = parkingSpotRepository;
        }

        public async Task<bool> OccupySpotAsync(string id, string deviceId)
        {
            var parkingSpot = await _parkingSpotRepository.GetByIdAsync(id);

            parkingSpot.IsOccupied = true;
            parkingSpot.DeviceId = deviceId;
            await _parkingSpotRepository.UpdateAsync(parkingSpot);
            return true;
        }

        public async Task<bool> FreeSpotAsync(string id)
        {
            var parkingSpot = await _parkingSpotRepository.GetByIdAsync(id);

            parkingSpot.IsOccupied = false;
            parkingSpot.DeviceId = null;
            await _parkingSpotRepository.UpdateAsync(parkingSpot);
            return true;
        }

        public async Task<IEnumerable<ParkingSpotDTO>> GetAllParkingSpotsAsync()
        {
            var parkingSpots = await _parkingSpotRepository.GetAllAsync();
            return parkingSpots.Select(spot => new ParkingSpotDTO
            {
                Id = spot.Id.ToString(),
                IsOccupied = spot.IsOccupied,
                DeviceId = spot.DeviceId
            });
        }

        public async Task<bool> AddParkingSpotAsync(ParkingSpotDTO parkingSpotDto)
        {
            var parkingSpot = new ParkingSpot
            {
                IsOccupied = parkingSpotDto.IsOccupied ?? false,
                DeviceId = parkingSpotDto.DeviceId
            };
            await _parkingSpotRepository.AddAsync(parkingSpot);
            return true;
        }

        public async Task<bool> RemoveParkingSpotAsync(string id)
        {
            return await _parkingSpotRepository.RemoveAsync(id);
        }
    }
}