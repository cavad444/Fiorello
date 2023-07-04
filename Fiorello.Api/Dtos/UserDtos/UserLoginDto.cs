using FluentValidation;

namespace Fiorello.Api.Dtos.UserDtos
{
    public class UserLoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; } 
    }
    public class UserLoginValidator:AbstractValidator<UserLoginDto>
    {
        public UserLoginValidator()
        {
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
            RuleFor(x => x.Email).Matches(@"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$").WithMessage("Email is not correct");
        }
    }
}

