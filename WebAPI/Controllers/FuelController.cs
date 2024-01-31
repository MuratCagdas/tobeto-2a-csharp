using Business.Abstract;
using Business.Requests.Fuel;
using Business.Responses.Fuel;
using Business.Responses.Model;
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
    public GetByIDFuelResponse GetById(int id)
    {
        GetByIDFuelResponse response = _fuelService.GetById(id);
        return response;
    }

    //[HttpPost("/add")] // POST http://localhost:5245/api/fuel/add
    [HttpPost] // POST http://localhost:5245/api/fuel
    public ActionResult<AddFuelResponse> Add(AddFuelRequest request)
    {
        AddFuelResponse response = _fuelService.Add(request);
        return CreatedAtAction( // 201 Created
            actionName: nameof(GetById),
            routeValues: new { Id = response.Id }, // Anonymous object
                                                   // Response Header: Location=http://localhost:5245/api/models/1

            value: response // Response Body: JSON
        );
    }
    //[HttpDelete("{id}")]
    [HttpDelete("{Id}")]
    public DeleteFuelResponse Delete(DeleteFuelRequest request)
    {
        DeleteFuelResponse response = _fuelService.Delete(request);
        return response;
    }
    [HttpPut("{Id}")]
   public ActionResult<UpdateFuelResponse>  Update([FromBody]UpdateFuelRequest request, [FromRoute]int Id)
    {
        if (Id != request.Id)
            return BadRequest();

        UpdateFuelResponse response = _fuelService.Update(request);
        return Ok(response);
    }

}
