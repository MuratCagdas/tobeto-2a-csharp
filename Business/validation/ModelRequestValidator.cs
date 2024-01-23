

using Business.Requests.Model;
using FluentValidation;

namespace Business.validation;

public   class ModelRequestValidator : AbstractValidator<AddModelRequest>
{
    public ModelRequestValidator()
    {
        RuleFor(a => a.Name).MinimumLength(2).WithMessage("Must 2 character");
        RuleFor(b => b.DailyPrice).GreaterThan(0).WithMessage("must higher 0");
    }
}
