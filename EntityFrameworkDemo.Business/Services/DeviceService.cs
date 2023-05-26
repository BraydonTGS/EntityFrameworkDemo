using AutoMapper;
using EntityFrameworkDemo.Business.Dto;
using EntityFrameworkDemo.Business.Interfaces;
using EntityFrameworkDemo.Business.Repository;
using EntityFrameworkDemo.Business.Validations.Dto;
using EntityFrameworkDemo.Entity.Entities;
using EntityFrameworkDemo.Global;

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
        public async Task<IEnumerable<DeviceDto>?> GetDevicesAsync()
        {
            try
            {
                var results = await _repository.GetAllAsync();
                if (results == null)
                    return null;

                var dtos = _mapper.Map<IEnumerable<DeviceDto>?>(results);

                return dtos;
            }
            catch (Exception ex)
            {
                throw new AutoMapperMappingException(Constants.ErrorMappingToDevice, ex);
            }

        }
        #endregion
        #region AddNewDevice
        public async Task<DeviceDto?> AddNewDevice(DeviceDto device)
        {
            try
            {
                var results = _validator.ValidateAsync(device);
                if (!results.Result.IsValid)
                    throw new InvalidOperationException($"{results.Result.Errors.FirstOrDefault()}");

                var entity = _mapper.Map<Device>(device);

                var result = await _repository.CreateAsync(entity);

                if (result != null)
                    return device;

                return null;
            }
            catch (Exception ex)
            {

                throw new AutoMapperMappingException(Constants.ErrorMappingToDevice, ex);
            }

        }

        public async Task<DeviceDto?> GetDeviceById(int id)
        {
            return _mapper.Map<DeviceDto>(await _repository.GetByIdAsync(id));
        }
        #endregion
    }
}
