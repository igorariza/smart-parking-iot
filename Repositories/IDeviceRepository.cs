using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SmartParkingLotManagement.Models;

namespace SmartParkingLotManagement.Repositories
{
    public interface IDeviceRepository
    {
        Task AddDeviceAsync(Device device);
        Task<Device?> GetDeviceByIdAsync(Guid id);
        Task<List<Device>> GetAllDevicesAsync();
        Task<bool> IsDeviceRegisteredAsync(Guid id);
        Task RemoveDeviceAsync(Guid id);
    }
}