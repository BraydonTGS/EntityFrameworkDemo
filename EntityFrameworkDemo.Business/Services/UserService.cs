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
    public class UserService : IUserService
    {
        private readonly UserRepository _repository;
        private readonly UserDtoValidator _validator; 
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;
        public UserService(UserRepository repository, UserDtoValidator validator, IMapper mapper, ILoggerFactory loggerFactory)
        {
            _repository = repository;
            _validator = validator;
            _mapper = mapper;
            _logger = loggerFactory.CreateLogger<UserService>();
        }

        #region GetAllUsersAsync
        public async Task<IEnumerable<UserDto>?> GetAllUsersAsync()
        {
            try
            {
                using (_logger.BeginScope("GetUsersAsync"))
                {
                    _logger.LogInformation("Calling User Repository GetAllAsync.");
                    var results = await _repository.GetAllAsync();
                    if (results == null)
                    {
                        _logger.LogInformation($"No Useers Found.");
                        return null;
                    }
                    _logger.LogInformation($"Found {results.Count()} Users.");

                    var dtos = _mapper.Map<IEnumerable<UserDto>?>(results);
                    _logger.LogInformation("Successfully Mapped Users to DTOs");

                    return dtos;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in GetUsersAsync method.");
                throw new AutoMapperMappingException(Constants.ErrorMappingToUser, ex);
            }

        }
        #endregion

        #region GetUserByIdAsync
        public async Task<UserDto?> GetUserByIdAsync(int id)
        {
            try
            {
                using (_logger.BeginScope("GetByUserIdAsync"))
                {
                    _logger.LogInformation($"Calling User Repository GetByIdAsync with User Id: {id}.");
                    var entity = await _repository.GetByIdAsync(id);
                    if (entity == null)
                    {
                        _logger.LogInformation($"No User with Id: {id} Found.");
                        return null;
                    }

                    var dto = _mapper.Map<UserDto>(entity);
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
        #endregion

        #region AddNewUserAsync
        public async Task<UserDto?> AddNewUserAsync(UserDto user)
        {
            try
            {
                using (_logger.BeginScope("AddNewUserAsync"))
                {
                    _logger.LogInformation($"Validating UserDto with the Id: {user.Id}.");
                    var results = _validator.ValidateAsync(user);
                    if (!results.Result.IsValid)
                    {
                        _logger.LogInformation($"Invalid UserDto. Number of Errors: {results.Result.Errors.Count()}");
                        throw new InvalidOperationException($"{results.Result.Errors.FirstOrDefault()}");
                    }
                    _logger.LogInformation($"UserDto is valid!");
                    var entity = _mapper.Map<User>(user);

                    _logger.LogInformation($"Calling UserRepository CreateAsync with User: {user.FirstName}.");
                    var result = await _repository.CreateAsync(entity);
                    if (result == null)
                    {
                        _logger.LogWarning($"User Repository CreateAsync returned null.");
                        return null;
                    }

                    var dto = _mapper.Map<UserDto>(result);
                    _logger.LogInformation("Successfully Mapped User to DTO");
                    return dto;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in AddNewUserAsync method.");
                throw new InvalidOperationException(Constants.ErrorMappingToUser, ex);
            }

        }
        #endregion

        #region DeleteUserAsync
        public async Task<bool> DeleteUserAsync(int id)
        {
            try
            {
                using (_logger.BeginScope("DeleteUserAsync"))
                {
                    _logger.LogInformation($"Calling User Repository DeleteAsync with User Id: {id}");
                    var result = await _repository.DeleteAsync(id);
                    _logger.LogInformation($"User Deleted: {result}");
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in Delete method.");
                throw new InvalidOperationException(ex.Message);
            }
        }
        #endregion
    }
}
