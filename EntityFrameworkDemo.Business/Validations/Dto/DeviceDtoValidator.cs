using EntityFrameworkDemo.Business.Context;
using EntityFrameworkDemo.Business.Dto;
using EntityFrameworkDemo.Business.Validations.Extensions;
using EntityFrameworkDemo.Entity.Entities;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace EntityFrameworkDemo.Business.Validations.Dto
{
    public class DeviceDtoValidator : AbstractValidator<DeviceDto>
    {
        private readonly IDbContextValidationHelper _validationHelper;
        public DeviceDtoValidator(IDbContextValidationHelper validationHelper)
        {
            _validationHelper = validationHelper;

            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Description).NotNull().NotEmpty();
            RuleFor(x => x).MustAsync((x, cancellation) => _validationHelper.IsUniqueWithinEntity<Device>(e => e.SubSystemId == x.SubSystemId && e.Name == x.Name)).WithMessage("{PropertyName}, {PropertyValue} already exists within the SubSystem."); 
        }
    }
}
