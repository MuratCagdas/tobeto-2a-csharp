using Business.Abstract;
using Business.Requests.Car;
using Business.Responses.Car;
using Business.Responses.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;


[Route("api/[controller]/[Action]")]
[ApiController]
public class CarController : ControllerBase
{
    private readonly ICarService _carService;
    public CarController(ICarService carService)
    {
        _carService = carService;
    }
    [HttpGet] // GET http://localhost:5245/api/fuel
    public GetCarListResponse GetList([FromQuery] GetCarListRequest request)
    {
        GetCarListResponse fuelList = _carService.GetList(request);
        return fuelList;
    }
    [HttpGet("{id}")]
    public GetByIDCarResponse GetById(GetByIDCarRequest id)
    {
        GetByIDCarResponse response = _carService.GetById(id);
        return response;
    }

    //[HttpPost("/add")] // POST http://localhost:5245/api/fuel/add
    [HttpPost] // POST http://localhost:5245/api/fuel
    public ActionResult<AddCarResponse> Add(AddCarRequest request)
    {
        AddCarResponse response = _carService.Add(request);
        return CreatedAtAction( // 201 Created
            actionName: nameof(GetById),
            routeValues: new { Id = response.Id }, // Anonymous object
                                                   // Response Header: Location=http://localhost:5245/api/models/1

            value: response // Response Body: JSON
        );
    }
   
    [HttpDelete("{Id}")]
    public DeleteCarResponse Delete(DeletCarRequest request)
    {
        DeleteCarResponse response = _carService.Delete(request);
        return response;
    }
    [HttpPut("{Id}")]
    public ActionResult<UpdateCarResponse>  Update([FromBody]UpdateCarRequest request, [FromRoute] int Id)
    {
        if (Id != request.Id)
            return BadRequest();

        UpdateCarResponse response = _carService.Update(request);
        return Ok(response);
    }
}
