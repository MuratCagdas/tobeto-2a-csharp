

using Business.Requests.Car;
using FluentValidation;

namespace Business.validation;

public class CarRequestValidator : AbstractValidator<AddCarRequest>
{
    public CarRequestValidator()
    {
        //RuleFor(a => a.ModelYear).GreaterThan(DateTime.Now.Year - 20);
    }
}
