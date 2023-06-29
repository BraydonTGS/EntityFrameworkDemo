using EntityFrameworkDemo.Business.Dto;
using EntityFrameworkDemo.Business.Validations.Extensions;
using EntityFrameworkDemo.Entity.Entities;
using FluentValidation;

namespace EntityFrameworkDemo.Business.Validations.Dto
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        private readonly IDbContextValidationHelper _validationHelper;
        public UserDtoValidator(IDbContextValidationHelper validationHelper)
        {
            _validationHelper = validationHelper;

            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();    
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.UserName).NotEmpty().MinimumLength(8).MaximumLength(25);

            RuleFor(x => x).MustAsync((x, cancellation) => _validationHelper.IsUniqueWithinEntity<User>(u => u.UserName == x.UserName)).WithMessage(Global.Constants.UserNameAlreadyExists);
        }
    }
}
