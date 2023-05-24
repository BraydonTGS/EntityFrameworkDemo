using EntityFrameworkDemo.Business.Context;
using EntityFrameworkDemo.Business.Dto;
using EntityFrameworkDemo.Business.Validations.Extensions;
using EntityFrameworkDemo.Entity.Entities;
using FluentValidation;

namespace EntityFrameworkDemo.Business.Validations.Dto
{
    public class DeviceDtoValidator : AbstractValidator<DeviceDto>
    {
        private readonly IDbContextValidationHelper<SubSystemDbContext> _validationHelper;
        public DeviceDtoValidator(IDbContextValidationHelper<SubSystemDbContext> validationHelper)
        {
            _validationHelper = validationHelper;

            RuleFor(x => x.Id).NotNull().NotEmpty(); 
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Description).NotNull().NotEmpty();
            RuleFor(x => x).MustAsync((x, cancellation) => _validationHelper.DoesExist<Device>(e => e.Id == x.Id)); 
            RuleFor(x => x).MustAsync((x, cancellation) => _validationHelper.DoesEntityExistWithEntity<Device>(e => e.Id == x.Id && e.SubSystemId == x.SubSystemId)).WithMessage("{PropertyName}, {PropertyValue} already exists within the SubSystem."); 
        }
    }
}
