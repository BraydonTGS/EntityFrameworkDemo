using AutoMapper;
using EntityFrameworkDemo.Business.Dto;
using EntityFrameworkDemo.Business.Interfaces;
using EntityFrameworkDemo.Business.Repository;
using EntityFrameworkDemo.Entity.Entities;
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
        public async Task<PasswordDto?> CreatePasswordAsync(string password, int userId = 0)
        {
            var secret = _encryptionService.EncryptPassword(password);

            var entity = _mapper.Map<Password>(secret);

            if (userId != 0)
                entity.UserId = userId;

            var dto = await _repository.CreateAsync(entity);

            var result = _mapper.Map<PasswordDto>(dto);

            return result;
        }

        public Task<bool> DeletePasswordAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PasswordDto?> GetPasswordAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
