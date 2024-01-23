
using Business.Dtos.Fuel;

namespace Business.Responses.Car;

public class UpdateCarResponse
{
    public FuelUpdateDto FuelUpdate { get; set; } 
    public UpdateCarResponse() { 
        if (FuelUpdate == null) { throw new Exception("agla"); }
    }

    public UpdateCarResponse(FuelUpdateDto fuelupdate)
    {
        FuelUpdate = fuelupdate;
    }
}
