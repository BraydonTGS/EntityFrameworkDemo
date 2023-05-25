using EntityFrameworkDemo.Business.Context;
using EntityFrameworkDemo.Business.Dto;
using EntityFrameworkDemo.Business.Validations.Extensions;
using FluentValidation;

namespace EntityFrameworkDemo.Business.Validations.Dto
{
    public class SubSystemDtoValidator : AbstractValidator<SubSystemDto>
    {
        private readonly IDbContextValidationHelper _validationHelper;

        public SubSystemDtoValidator(IDbContextValidationHelper validationHelper)
        {
            _validationHelper = validationHelper;
        }
    }
}
