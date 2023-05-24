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

        #region MapDtoToEntityAndAdd
        public async Task<DeviceDto?> MapDtoToEntity(DeviceDto device)
        {
            var results = _validator.Validate(device);
            if (!results.IsValid)
            {
                throw new InvalidOperationException($"{results.Errors}"); 
            }
            var entity = _mapper.Map<Device>(device);
            var result = await _repository.CreateAsync(entity);
            if(result != null)
            {
                return device; 
            }
            return null;
        }
        #endregion
    }
}
