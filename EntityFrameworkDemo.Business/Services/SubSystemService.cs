using AutoMapper;
using EntityFrameworkDemo.Business.Dto;
using EntityFrameworkDemo.Business.Interfaces;
using EntityFrameworkDemo.Business.Repository;
using EntityFrameworkDemo.Business.Validations.Dto;
using EntityFrameworkDemo.Entity.Entities;
using EntityFrameworkDemo.Global;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace EntityFrameworkDemo.Business.Services
{
    public class SubSystemService : ISubSystemService
    {

        private readonly SubSystemRepository _repository;
        private readonly SubSystemDtoValidator _validator;
        private readonly IMapper _mapper;
        private readonly ILogger<SubSystemService> _logger;

        public SubSystemService(SubSystemRepository repository, SubSystemDtoValidator validator, IMapper mapper, ILoggerFactory loggerFactory)
        {
            _repository = repository;
            _validator = validator;
            _mapper = mapper;
            _logger = loggerFactory.CreateLogger<SubSystemService>();
        }

        #region GetSubSystemsAsync
        public async Task<IEnumerable<SubSystemDto>?> GetSubSystemsAsync()
        {
            try
            {
                using (_logger.BeginScope("GetSubSystemsAsync"))
                {
                    _logger.LogInformation("Calling SubSystem Repository GetAllAsync.");
                    var results = await _repository.GetAllAsync();
                    if (results == null)
                    {
                        _logger.LogInformation($"No SubSystems Found.");
                        return null;
                    }
                    _logger.LogInformation($"Found {results.Count()} SubSystems.");

                    var dtos = _mapper.Map<IEnumerable<SubSystemDto>?>(results);
                    _logger.LogInformation("Successfully Mapped SubSystems to DTOs");

                    return dtos;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in GetSubSystemsAsync method.");
                throw new AutoMapperMappingException(Constants.ErrorMappingToSubSystem, ex);
            }

        }
        #endregion

        #region GetSubSystemById
        public async Task<SubSystemDto?> GetSubSystemById(int id)
        {
            try
            {
                using (_logger.BeginScope("GetSubSystemById"))
                {
                    _logger.LogInformation($"Calling SubSystem Repository GetByIdAsync with SubSystem Id: {id}.");
                    var entity = await _repository.GetByIdAsync(id);
                    if (entity == null)
                    {
                        _logger.LogInformation($"No SubSystem with Id: {id} Found.");
                        return null;
                    }

                    var dto = _mapper.Map<SubSystemDto>(entity);
                    _logger.LogInformation("Successfully Mapped SubSystem to DTO");
                    return dto;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in GetBySubSystemId method.");
                throw new AutoMapperMappingException(Constants.ErrorMappingToSubSystem, ex);
            }
        }
        #endregion

        #region AddNewSubSystem
        public async Task<SubSystemDto?> AddNewSubSystem(SubSystemDto subSystem)
        {
            try
            {
                using (_logger.BeginScope("AddNewSubSystem"))
                {
                    _logger.LogInformation($"Validating SubSystemDto with the Id: {subSystem.Id}.");
                    var results = _validator.ValidateAsync(subSystem);
                    if (!results.Result.IsValid)
                    {
                        _logger.LogInformation($"Invalid SubSystemDto. Number of Errors: {results.Result.Errors.Count()}");
                        throw new InvalidOperationException($"{results.Result.Errors.FirstOrDefault()}");
                    }
                    _logger.LogInformation($"SubSystemDto is valid!");
                    var entity = _mapper.Map<SubSystem>(subSystem);

                    _logger.LogInformation($"Calling SubSystem Repository CreateAsync with SubSystem: {subSystem.Name}.");
                    var result = await _repository.CreateAsync(entity);
                    if (result == null)
                    {
                        _logger.LogWarning($"SubSystem Repository CreateAsync returned null.");
                        return null;
                    }

                    var dto = _mapper.Map<SubSystemDto>(result);
                    _logger.LogInformation("Successfully Mapped SubSystem to DTO");
                    return dto;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in CreateNewSubSystemDto method.");
                throw new InvalidOperationException(Constants.ErrorMappingToSubSystem, ex);
            }

        }
        #endregion

        #region DeleteSubSystem
        public async Task<bool> DeleteSubSystem(int id)
        {
            try
            {
                using (_logger.BeginScope("DeleteSubSystem"))
                {
                    _logger.LogInformation($"Calling SubSystem Repository DeleteAsync with SubSystem Id: {id}");
                    var result = await _repository.DeleteAsync(id);
                    _logger.LogInformation($"SubSystem Deleted: {result}");
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
