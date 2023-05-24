using EntityFrameworkDemo.Business.Context;
using EntityFrameworkDemo.Business.Dto;
using EntityFrameworkDemo.Business.Validations.Extensions;
using FluentValidation;

namespace EntityFrameworkDemo.Business.Validations.Dto
{
    public class SubSystemDtoValidator : AbstractValidator<SubSystemDto>
    {
        private readonly IDbContextValidationHelper<SubSystemDbContext> _validationHelper;

        public SubSystemDtoValidator(IDbContextValidationHelper<SubSystemDbContext> validationHelper)
        {
            _validationHelper = validationHelper;
        }
    }
}
