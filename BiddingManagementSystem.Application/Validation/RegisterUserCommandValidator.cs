using BiddingManagementSystem.Application.Features.UserFeature.Commands;
using FluentValidation;

namespace BiddingManagementSystem.Application.Validation
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(x => x.UserDTO.Email)
                .NotEmpty().WithMessage("Email is required.")
                .NotNull().WithMessage("Email cannot be null.")
                .EmailAddress().WithMessage("Invalid email format.")
                .MinimumLength(16).WithMessage("Email must be at least 16 characters long.")
                .MaximumLength(30).WithMessage("Email must not exceed 30 characters");

            RuleFor(x => x.UserDTO.Password)
                .NotEmpty().WithMessage("Password is required.")
                .NotNull().WithMessage("Password cannot be null.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                .MaximumLength(60).WithMessage("Password must not exceed 60 characters");

            RuleFor(x => x.UserDTO.UserName)
                .NotEmpty().WithMessage("UserName is required.")
                .NotNull().WithMessage("UserName cannot be null.")
                .MinimumLength(3).WithMessage("UserName must be at least 3 characters long.")
                .MaximumLength(25).WithMessage("UserName must not exceed 25 characters.");
        }
    }
}
