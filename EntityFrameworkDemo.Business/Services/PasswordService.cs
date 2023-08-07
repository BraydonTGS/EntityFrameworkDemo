using AutoMapper;
using EntityFrameworkDemo.Business.Dto;
using EntityFrameworkDemo.Business.Interfaces;
using EntityFrameworkDemo.Business.Repository;
using EntityFrameworkDemo.Entity.Entities;
using EntityFrameworkDemo.Global;
using Microsoft.Extensions.Logging;

namespace EntityFrameworkDemo.Business.Services
{
    //Todo: Add Password Validation and Implement Methods
    public class PasswordService : IPasswordService
    {
        private readonly PasswordRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<PasswordService> _logger;
        private readonly IEncryptPasswordService _encryptionService;
        public PasswordService(PasswordRepository respository, IMapper mapper, ILoggerFactory loggerFactory, IEncryptPasswordService encryptionService)
        {
            _repository = respository;
            _mapper = mapper;
            _logger = loggerFactory.CreateLogger<PasswordService>();
            _encryptionService = encryptionService;

        }
        public async Task<PasswordDto?> CreatePasswordAsync(string password = "", int userId = 0)
        {
            var secret = _encryptionService.EncryptPassword(password);

            var entity = _mapper.Map<Password>(secret);

            if (userId != 0)
                entity.UserId = userId;

            var result = await _repository.CreateAsync(entity);

            return _mapper.Map<PasswordDto>(result);
        }

        public async Task<bool> DeletePasswordAsync(int id)
        {
            try
            {
                using (_logger.BeginScope("DeletePasswordAsync"))
                {
                    _logger.LogInformation($"Calling Password Repository DeleteAsync with Password Id: {id}");
                    var result = await _repository.DeleteAsync(id);
                    _logger.LogInformation($"Password Deleted: {result}");
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in Delete method.");
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<PasswordDto?> GetPasswordAsync(int id)
        {
            try
            {
                using (_logger.BeginScope("GetPasswordAsync"))
                {
                    _logger.LogInformation($"Calling Password Repository GetByIdAsync with Password Id: {id}.");
                    var entity = await _repository.GetByIdAsync(id);
                    if (entity == null)
                    {
                        _logger.LogInformation($"No Password with Id: {id} Found.");
                        return null;
                    }

                    var dto = _mapper.Map<PasswordDto>(entity);
                    _logger.LogInformation("Successfully Mapped User to DTO");
                    return dto;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in GetByUserIdAsync method.");
                throw new AutoMapperMappingException(Constants.ErrorMappingToUser, ex);
            }
        }
    }
}
