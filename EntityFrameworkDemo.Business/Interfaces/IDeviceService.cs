using EntityFrameworkDemo.Business.Dto;

namespace EntityFrameworkDemo.Business.Interfaces
{
    public interface IDeviceService
    {
        Task<DeviceDto?> MapDtoToEntity(DeviceDto device);
    }
}
