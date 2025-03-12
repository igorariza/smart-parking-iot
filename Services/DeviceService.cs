using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SmartParkingLotManagement.Models;
using SmartParkingLotManagement.Repositories;

namespace SmartParkingLotManagement.Services
{
    public class DeviceService
    {
        private readonly IDeviceRepository _deviceRepository;

        public DeviceService(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public async Task<bool> RegisterDeviceAsync(Device device)
        {
            if (device == null)
            {
                throw new ArgumentNullException(nameof(device));
            }

            await _deviceRepository.AddDeviceAsync(device);
            return true;
        }

        public async Task<bool> ValidateDeviceAsync(string deviceId)
        {
            if (string.IsNullOrEmpty(deviceId))
            {
                throw new ArgumentNullException(nameof(deviceId));
            }

            var device = await _deviceRepository.GetDeviceByIdAsync(Guid.Parse(deviceId));
            return device != null && device.IsRegistered;
        }
    }
}