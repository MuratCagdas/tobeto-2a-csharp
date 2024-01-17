using Business.Abstract;
using Business.Requests.Fuel;
using Business.Requests.Transmission;
using Business.Responses.Fuel;
using Business.Responses.Transmission;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]/[Action]")]
[ApiController]
public class TransmissionController : ControllerBase
{
    private readonly ITransmissionService _transmissionService;
    public TransmissionController()
    {
        _transmissionService = ServiceRegistration.TransmissionService;
    }
    [HttpGet] // GET http://localhost:5245/api/transmission
    [ActionName("GetList")]
    public ICollection<Transmission> GetList()
    {
        IList<Transmission> transmissionList = _transmissionService.GetList();
        return transmissionList;
    }

    //[HttpPost("/add")] // POST http://localhost:5245/api/transmission/add
    [HttpPost] // POST http://localhost:5245/api/transmission/Add
    [ActionName("Add")]
    public ActionResult<AddTransmissionResponse> Add(AddTransmissionRequest request)
    {
        AddTransmissionResponse response = _transmissionService.Add(request);

        return CreatedAtAction(nameof(GetList), response);
    }

    [HttpGet("{id}")]
    public GetByIDTransmissionResponse getById(int id)
    {
        GetByIDTransmissionResponse response = _transmissionService.GetById(id);
        return response;
    }

    //[HttpDelete("{id}")]
    [HttpDelete]
    public void Delete(DeleteTransmissionRequest request)
    {
        _transmissionService.Delete(request);
    }
    [HttpPut]
    public void Update(UpdateTransmissionRequest request)
    {
        _transmissionService.Update(request);
    }
}
