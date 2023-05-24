using AutoMapper;
using EntityFrameworkDemo.Business.Dto;
using EntityFrameworkDemo.Business.Interfaces;
using EntityFrameworkDemo.Business.Repository;
using EntityFrameworkDemo.Business.Validations.Dto;
using EntityFrameworkDemo.Entity.Entities;
using FluentValidation;

namespace EntityFrameworkDemo.Business.Services
{
    public class SubSystemService : ISubSystemService
    {

        private readonly SubSystemRepository _repository;
        private readonly SubSystemDtoValidator _validator;
        private readonly IMapper _mapper;

        public SubSystemService(SubSystemRepository repository, SubSystemDtoValidator validator, IMapper mapper)
        {
            _repository = repository;
            _validator = validator;
            _mapper = mapper;
        }
        #region MapDtoToEntityAndAdd
        public async Task<SubSystemDto?> MapDtoToEntity(SubSystemDto subSystem)
        {
            var results = _validator.Validate(subSystem);
            if (!results.IsValid)
            {
                throw new InvalidOperationException($"{results.Errors}");
            }
            var entity = _mapper.Map<SubSystem>(subSystem);
            var result = await _repository.CreateAsync(entity);
            if (result != null)
            {
                return subSystem;
            }
            return null;
        }
        #endregion
    }
}
