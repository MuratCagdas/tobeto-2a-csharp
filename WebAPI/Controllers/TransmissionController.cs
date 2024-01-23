using Business.Abstract;
using Business.Requests.Transmission;
using Business.Responses.Transmission;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]/[Action]")]
[ApiController]
public class TransmissionController : ControllerBase
{
    private readonly ITransmissionService _transmissionService;
    public TransmissionController(ITransmissionService transmissionService )
    {
        _transmissionService = transmissionService;
    }

    [HttpGet] // GET http://localhost:5245/api/transmission
    [ActionName("GetList")]
    public GetTransmissionListResponse GetList([FromQuery] GetTransmissionListRequest request)
    {
        GetTransmissionListResponse transmissionList = _transmissionService.GetList(request);

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

    [HttpGet("{id:int}")]
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
