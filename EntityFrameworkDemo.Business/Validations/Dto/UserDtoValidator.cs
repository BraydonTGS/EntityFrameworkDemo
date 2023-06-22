using EntityFrameworkDemo.Business.Dto;
using FluentValidation;

namespace EntityFrameworkDemo.Business.Validations.Dto
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {

        }
    }
}
