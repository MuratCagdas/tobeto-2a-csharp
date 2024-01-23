
using Abp.Runtime.Validation;
using Business.validation;

namespace Business.Requests.Car;

[Validator(typeof(CarRequestValidator))]
public class AddCarRequest
{
    public string Name { get; set; }
    public int ModelYear { get; set; }

    public AddCarRequest(string name)
    {
        Name = name;
    }
}
