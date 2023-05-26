using AutoMapper;
using EntityFrameworkDemo.Business.Dto;
using EntityFrameworkDemo.Business.Interfaces;
using EntityFrameworkDemo.Business.Repository;
using EntityFrameworkDemo.Business.Validations.Dto;
using EntityFrameworkDemo.Entity.Entities;

namespace EntityFrameworkDemo.Business.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly DeviceRepository _repository;
        private readonly DeviceDtoValidator _validator;
        private readonly IMapper _mapper;

        public DeviceService(DeviceRepository repository, DeviceDtoValidator validator, IMapper mapper)
        {
            _repository = repository;
            _validator = validator;
            _mapper = mapper;
        }

        #region GetAllDevices
        public async Task<IEnumerable<DeviceDto>> GetDevicesAsync()
        {
            try
            {
                var results = await _repository.GetAllAsync();

                if (results == null)
                    throw new ArgumentNullException(nameof(results));

                var dtos = _mapper.Map<IEnumerable<DeviceDto>>(results);

                return dtos;
            }
            catch (Exception)
            {
                throw new AutoMapperMappingException("Error Mapping to DeviceDto");
            }

        }
        #endregion
        #region AddNewDevice
        public async Task<DeviceDto?> AddNewDevice(DeviceDto device)
        {
            var results = _validator.ValidateAsync(device);

            if (!results.Result.IsValid)
                throw new InvalidOperationException($"{results.Result.Errors}");

            var entity = _mapper.Map<Device>(device);
            var result = await _repository.CreateAsync(entity);
            if (result != null)
                return device;

            return null;
        }
        #endregion
    }
}
