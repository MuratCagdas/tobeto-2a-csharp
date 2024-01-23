
using Business.Dtos.Fuel;

namespace Business.Responses.Fuel;

public class UpdateFuelResponse
{
    public FuelUpdateDto FuelUpdate { get; set; } 
    public UpdateFuelResponse() { 
        if (FuelUpdate == null) { throw new Exception("agla"); }
    }

    public UpdateFuelResponse(FuelUpdateDto fuelupdate)
    {
        FuelUpdate = fuelupdate;
    }
}
