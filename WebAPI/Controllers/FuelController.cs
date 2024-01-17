using Business.Abstract;
using Business.Requests.Fuel;
using Business.Responses.Fuel;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FuelController : ControllerBase
{
    private readonly IFuelService _fuelService;
    public FuelController()
    {
        _fuelService = ServiceRegistration.FuelService;
    }
    [HttpGet] // GET http://localhost:5245/api/fuel
    public ICollection<Fuel> GetList()
    {
        IList<Fuel> fuelList = _fuelService.GetList();
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
    public void Update(UpdateFuelRequest request)
    {
        _fuelService.Update(request);
    }

}
