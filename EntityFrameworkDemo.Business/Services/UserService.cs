using AutoMapper;
using EntityFrameworkDemo.Business.Dto;
using EntityFrameworkDemo.Business.Interfaces;
using EntityFrameworkDemo.Business.Repository;
using EntityFrameworkDemo.Entity.Entities;
using Microsoft.Extensions.Logging;

namespace EntityFrameworkDemo.Business.Services
{
    //Todo: Add User Validation and Implement Methods
    public class UserService : IUserService
    {
        private readonly UserRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;
        public UserService(UserRepository repository, IMapper mapper, ILoggerFactory loggerFactory)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = loggerFactory.CreateLogger<UserService>();
        }
        public async Task<UserDto?> AddNewUser(UserDto user)
        {
            var entity = _mapper.Map<User>(user);

            var result = await _repository.CreateAsync(entity);

            if (result == null)
                return null;

            var dto = _mapper.Map<UserDto>(result);

            return dto;
        }

        public Task<bool> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDto>?> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<UserDto?> GetUserById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
