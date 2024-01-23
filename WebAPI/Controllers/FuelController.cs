using Business.Abstract;
using Business.Requests.Fuel;
using Business.Responses.Fuel;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]/[Action]")]
[ApiController]
public class FuelController : ControllerBase
{
    private readonly IFuelService _fuelService;
    public FuelController(IFuelService fuelService)
    {
        _fuelService = fuelService;
    }
    [HttpGet] // GET http://localhost:5245/api/fuel
    public GetFuelListResponse GetList([FromQuery] GetFuelListRequest request)
    {
        GetFuelListResponse fuelList = _fuelService.GetList(request);
        return fuelList; 
    }
    [HttpGet("{id}")]
    public GetByIDFuelResponse getById(int id)
    {
        GetByIDFuelResponse response = _fuelService.GetById(id);
        return response;
    }

    //[HttpPost("/add")] // POST http://localhost:5245/api/fuel/add
    [HttpPost] // POST http://localhost:5245/api/fuel
    public ActionResult<AddFuelResponse> Add(AddFuelRequest request)
    {
        AddFuelResponse response = _fuelService.Add(request);

        return CreatedAtAction(nameof(GetList), response);
    }
    //[HttpDelete("{id}")]
    [HttpDelete]
    public void Delete(DeleteFuelRequest request) {
        _fuelService.Delete(request);
    }
    [HttpPut]
   public UpdateFuelResponse Update(UpdateFuelRequest request)
    {
        UpdateFuelResponse response =_fuelService.Update(request);
        return response;
    }

}
