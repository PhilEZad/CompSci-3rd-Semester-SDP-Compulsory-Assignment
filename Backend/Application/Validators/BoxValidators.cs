using Domain;
using FluentValidation;

namespace Application.Validators;


public class BoxValidator : AbstractValidator<Box>
{
    public BoxValidator()
    {
        RuleFor(b => b.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(b => b.Width).GreaterThan(0).WithMessage("Width must be greater than 0");
        RuleFor(b => b.Height).GreaterThan(0).WithMessage("Height must be greater than 0");
        RuleFor(b => b.Length).GreaterThan(0).WithMessage("Length must be greater than 0");
        RuleFor(b => b.Weight).GreaterThan(0).WithMessage("Weight must be greater than 0");
    }
}

public class PostBoxValidator : AbstractValidator<PostBoxDTO>
{
    public PostBoxValidator()
    {
        RuleFor(b => b.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(b => b.Width).GreaterThan(0).WithMessage("Width must be greater than 0");
        RuleFor(b => b.Height).GreaterThan(0).WithMessage("Height must be greater than 0");
        RuleFor(b => b.Length).GreaterThan(0).WithMessage("Length must be greater than 0");
        RuleFor(b => b.Weight).GreaterThan(0).WithMessage("Weight must be greater than 0");
    }

}