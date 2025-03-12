using System.Collections.Generic;
using System.Threading.Tasks;
using SmartParkingLotManagement.Models;

namespace SmartParkingLotManagement.Repositories
{
    public interface IParkingSpotRepository
    {
        Task AddAsync(ParkingSpot parkingSpot);
        Task<bool> RemoveAsync(string id);
        Task<ParkingSpot> GetByIdAsync(string id);
        Task<IEnumerable<ParkingSpot>> GetAllAsync();
        Task UpdateAsync(ParkingSpot parkingSpot);
    }
}