using EntityFrameworkDemo.Business.Dto;

namespace EntityFrameworkDemo.Business.Interfaces
{
    public interface IDeviceService
    {
        Task<DeviceDto?> AddNewDevice(DeviceDto device);
        Task <DeviceDto?> GetDeviceById(int id);
        Task<IEnumerable<DeviceDto>?> GetDevicesAsync();
    }
}
