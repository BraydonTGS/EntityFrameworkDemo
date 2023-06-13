using AutoMapper;
using EntityFrameworkDemo.Business.Dto;
using EntityFrameworkDemo.Business.Interfaces;
using EntityFrameworkDemo.Business.Repository;
using Microsoft.Extensions.Logging;

namespace EntityFrameworkDemo.Business.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _repository;
        // Todo: Add Validation
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;
        public UserService(UserRepository repository, IMapper mapper, ILoggerFactory loggerFactory)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = loggerFactory.CreateLogger<UserService>();
        }
        public Task<UserDto?> AddNewUser(UserDto user)
        {
            throw new NotImplementedException();
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
