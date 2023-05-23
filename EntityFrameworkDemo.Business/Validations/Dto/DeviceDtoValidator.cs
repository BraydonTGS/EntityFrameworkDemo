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
            RuleFor(x => x).MustAsync((x, cancellation) => _validationHelper.DoesEntityExistWithEntity<Device>(d => d.Id == x.Id && d.SubSystemId == x.SubSystemId)); 
        }
    }
}
