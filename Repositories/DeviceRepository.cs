using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartParkingLotManagement.Models;

namespace SmartParkingLotManagement.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly List<Device> _devices = new List<Device>();

        public Task AddDeviceAsync(Device device)
        {
            _devices.Add(device);
            return Task.CompletedTask;
        }

        public Task<Device?> GetDeviceByIdAsync(Guid id)
        {
            var device = _devices.FirstOrDefault(d => d.Id == id);
            return Task.FromResult(device);
        }

        public Task<List<Device>> GetAllDevicesAsync()
        {
            return Task.FromResult(_devices);
        }

        public Task<bool> IsDeviceRegisteredAsync(Guid id)
        {
            var isRegistered = _devices.Any(d => d.Id == id && d.IsRegistered);
            return Task.FromResult(isRegistered);
        }

        public Task RemoveDeviceAsync(Guid id)
        {
            var device = _devices.FirstOrDefault(d => d.Id == id);
            if (device != null)
            {
                _devices.Remove(device);
            }
            return Task.CompletedTask;
        }
    }
}