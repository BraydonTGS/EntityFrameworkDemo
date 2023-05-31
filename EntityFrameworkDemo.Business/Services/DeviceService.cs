using AutoMapper;
using EntityFrameworkDemo.Business.Dto;
using EntityFrameworkDemo.Business.Interfaces;
using EntityFrameworkDemo.Business.Repository;
using EntityFrameworkDemo.Business.Validations.Dto;
using EntityFrameworkDemo.Entity.Entities;
using EntityFrameworkDemo.Global;
using Microsoft.Extensions.Logging;

namespace EntityFrameworkDemo.Business.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly DeviceRepository _repository;
        private readonly DeviceDtoValidator _validator;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public DeviceService(DeviceRepository repository, DeviceDtoValidator validator, IMapper mapper, ILogger<DeviceService> logger)
        {
            _repository = repository;
            _validator = validator;
            _mapper = mapper;
            _logger = logger;
        }

        #region GetAllDevices
        public async Task<IEnumerable<DeviceDto>?> GetDevicesAsync()
        {
            try
            {
                using (_logger.BeginScope("GetDevicesAsync"))
                {
                    _logger.LogInformation("Calling Device Repository GetAllAsync.");
                    var results = await _repository.GetAllAsync();
                    if (results == null)
                    {
                        _logger.LogInformation($"No Devices Found.");
                        return null;
                    }
                    _logger.LogInformation($"Found {results.Count()} Devices.");

                    var dtos = _mapper.Map<IEnumerable<DeviceDto>?>(results);
                    _logger.LogInformation("Successfully Mapped Devices to DTOs");

                    return dtos;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in GetDevicesAsync method.");
                throw new AutoMapperMappingException(Constants.ErrorMappingToDevice, ex);
            }

        }
        #endregion

        #region GetDeviceById
        public async Task<DeviceDto?> GetDeviceById(int id)
        {
            try
            {
                using (_logger.BeginScope("GetDeviceById"))
                {
                    _logger.LogInformation($"Calling Device Repository GetByIdAsync with Device Id: {id}.");
                    var entity = await _repository.GetByIdAsync(id);
                    if (entity == null)
                    {
                        _logger.LogInformation($"No Device with Id: {id} Found.");
                        return null;
                    }

                    var dto = _mapper.Map<DeviceDto>(entity);
                    _logger.LogInformation("Successfully Mapped Device to DTO");
                    return dto;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in GetByDeviceId method.");
                throw new AutoMapperMappingException(Constants.ErrorMappingToDevice, ex);
            }
        }
        #endregion

        #region AddNewDevice
        public async Task<DeviceDto?> AddNewDevice(DeviceDto device)
        {
            try
            {
                using (_logger.BeginScope("AddNewDevice"))
                {
                    _logger.LogInformation($"Validating DeviceDto with the Id: {device.Id}.");
                    var results = _validator.ValidateAsync(device);
                    if (!results.Result.IsValid)
                    {
                        _logger.LogInformation($"Invalid DeviceDto. Number of Errors: {results.Result.Errors.Count()}");
                        throw new InvalidOperationException($"{results.Result.Errors.FirstOrDefault()}");
                    }
                    _logger.LogInformation($"DeviceDto is valid!");
                    var entity = _mapper.Map<Device>(device);

                    _logger.LogInformation($"Calling Device Repository CreateAsync with Device: {device.Name}.");
                    var result = await _repository.CreateAsync(entity);
                    if (result == null)
                    {
                        _logger.LogWarning($"Device Repository CreateAsync returned null.");
                        return null;
                    }
                     
                    var dto = _mapper.Map<DeviceDto>(result);
                    _logger.LogInformation("Successfully Mapped Device to DTO");
                    return dto;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in CreateNewDevice method.");
                throw new InvalidOperationException(Constants.ErrorMappingToDevice, ex);
            }

        }
        #endregion

        #region DeleteDevice
        public async Task<bool> DeleteDevice(int id)
        {
            try
            {
                using (_logger.BeginScope("DeleteDevice"))
                {
                    _logger.LogInformation($"Calling Device Repository DeleteAsync with Device Id: {id}"); 
                    var result = await _repository.DeleteAsync(id);
                    _logger.LogInformation($"Device Deleted: {result}"); 
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in DeleteDevice method.");
                throw new InvalidOperationException(ex.Message);
            }
        }
        #endregion


    }

}
