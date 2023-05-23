using EntityFrameworkDemo.Business.Context;
using EntityFrameworkDemo.Business.Validations.Extensions;
using EntityFrameworkDemo.Entity.Entities;
using FluentValidation;

namespace EntityFrameworkDemo.Business.Validations.Dto
{
    public class SubSystemDtoValidator : AbstractValidator<SubSystem>
    {
        private readonly IDbContextValidationHelper<SubSystemDbContext> _validationHelper;

        public SubSystemDtoValidator(IDbContextValidationHelper<SubSystemDbContext> validationHelper)
        {
            _validationHelper = validationHelper;
        }
    }
}
