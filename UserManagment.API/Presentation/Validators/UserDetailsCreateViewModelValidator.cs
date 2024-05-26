using FluentValidation;
using UserManagment.API.Presentation.ViewModels;

namespace UserManagment.API.Application.Validators
{
    public class UserDetailsCreateViewModelValidator : AbstractValidator<UserDetailsCreateViewModel>
    {
        public UserDetailsCreateViewModelValidator()
        {

            RuleFor(x => x.Name)
                 .NotEmpty().WithMessage("Name is required.")
                 .MaximumLength(100).WithMessage("Name cannot be longer than 100 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("A valid email is required.")
                .MaximumLength(100).WithMessage("Email cannot be longer than 100 characters.");


            RuleFor(x => x.Designation)
                .NotEmpty().WithMessage("Designation is required.")
                .MaximumLength(255).WithMessage("Designation cannot be longer than 255 characters.");

            RuleFor(x => x.EmployeeType)
                .NotEmpty().WithMessage("EmployeeType is required.")
                .MaximumLength(100).WithMessage("EmployeeType cannot be longer than 100 characters.");

            RuleFor(x => x.MobileNo)
                .NotEmpty().WithMessage("MobileNo is required.")
                .MaximumLength(15).WithMessage("MobileNo cannot be longer than 15 characters.");


            RuleFor(x => x.PassportNo)
                .NotEmpty().WithMessage("Passport number is required.")
                .MaximumLength(20).WithMessage("Passport number cannot be longer than 20 characters.");

            RuleFor(x => x.PassportExpiryDate)
               .NotEmpty().WithMessage("Passport Expiry Date is required.");

            RuleFor(x => x.LocationId)
            .NotEmpty().WithMessage("LocationId is required.");

            RuleFor(x => x.Nationality)
          .NotEmpty().WithMessage("LocationId is required.");



        }
    }
}