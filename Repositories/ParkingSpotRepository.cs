using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using SmartParkingLotManagement.Models;

namespace SmartParkingLotManagement.Repositories
{
    public class ParkingSpotRepository : IParkingSpotRepository
    {
        private readonly IMongoCollection<ParkingSpot> _parkingSpots;

        public ParkingSpotRepository(IMongoDatabase database)
        {
            _parkingSpots = database.GetCollection<ParkingSpot>("ParkingSpots");
        }

        public async Task AddAsync(ParkingSpot parkingSpot)
        {
            await _parkingSpots.InsertOneAsync(parkingSpot);
        }

        public async Task<bool> RemoveAsync(string id)
        {
            var result = await _parkingSpots.DeleteOneAsync(spot => spot.Id == Guid.Parse(id));
            return result.DeletedCount > 0;
        }

        public async Task<ParkingSpot> GetByIdAsync(string id)
        {
            return await _parkingSpots.Find(spot => spot.Id == Guid.Parse(id)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ParkingSpot>> GetAllAsync()
        {
            return await _parkingSpots.Find(spot => true).ToListAsync();
        }

        public async Task UpdateAsync(ParkingSpot parkingSpot)
        {
            await _parkingSpots.ReplaceOneAsync(spot => spot.Id == parkingSpot.Id, parkingSpot);
        }
    }
}