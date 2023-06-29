using Employer.Common.DTO;
using FluentValidation;

namespace ArtsofteAPI.Validators;

public class AddEmployeeValidator : AbstractValidator<AddEmployeeDTO>
{
    public AddEmployeeValidator()
    {
        RuleFor(a => a.Name).NotEmpty()
            .MinimumLength(1)
            .MaximumLength(50)
            .Matches(@"^[A-Za-z]+$");
        RuleFor(a => a.Surname).NotEmpty()
            .MinimumLength(1)
            .MaximumLength(50)
            .Matches(@"^[\p{L}\p{M}\p{Z}\p{P}-]+$");
            

        RuleFor(d => d.Age).GreaterThan(0);

        RuleFor(d => d.Department).NotEmpty();

        RuleFor(d => d.Department.Name).NotEmpty()
            .MinimumLength(1)
            .MaximumLength(50);
        RuleFor(d => d.Department.Floor).GreaterThan(0);
        
        RuleFor(d => d.Language).NotEmpty();

        RuleFor(d => d.Language.Name).NotEmpty()
            .MinimumLength(1)
            .MaximumLength(50);
    }
}