using EntityFrameworkDemo.Business.Dto;
using EntityFrameworkDemo.Business.Validations.Extensions;
using EntityFrameworkDemo.Entity.Entities;
using FluentValidation;

namespace EntityFrameworkDemo.Business.Validations.Dto
{
    public class SubSystemDtoValidator : AbstractValidator<SubSystemDto>
    {
        private readonly IDbContextValidationHelper _validationHelper;

        public SubSystemDtoValidator(IDbContextValidationHelper validationHelper)
        {
            _validationHelper = validationHelper;

            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x).MustAsync((x, cancellation) => _validationHelper.IsUniqueWithinEntity<SubSystem>(s => s.Name == x.Name)).WithMessage(Global.Constants.SubSystemAlreadyExists);
        }
    }
}
