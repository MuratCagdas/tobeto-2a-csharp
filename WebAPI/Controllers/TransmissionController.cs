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
    public GetTransmissionListResponse GetList([FromQuery] GetTransmissionListRequest request)
    {
        GetTransmissionListResponse transmissionList = _transmissionService.GetList(request);

        return transmissionList;
    }

    //[HttpPost("/add")] // POST http://localhost:5245/api/transmission/add
    [HttpPost] // POST http://localhost:5245/api/transmission/Add
    public ActionResult<AddTransmissionResponse> Add(AddTransmissionRequest request)
    {
        AddTransmissionResponse response = _transmissionService.Add(request);
        return CreatedAtAction( // 201 Created
            actionName: nameof(GetById),
            routeValues: new { Id = response.Id }, // Anonymous object
                                                   // Response Header: Location=http://localhost:5245/api/models/1

            value: response // Response Body: JSON
        );
    }

    [HttpGet("{Id}")]
    public GetByIDTransmissionResponse GetById(GetByIDTransmissionRequest request)
    {
        GetByIDTransmissionResponse response = _transmissionService.GetById(request);
        return response;
    }

    //[HttpDelete("{id}")]
    [HttpDelete("{Id}")]
    public DeleteTransmissionResponse Delete(DeleteTransmissionRequest request)
    {
        DeleteTransmissionResponse response = _transmissionService.Delete(request);
        return response;
    }
    [HttpPut("{Id}")]
    public ActionResult< UpdateTransmissionResponse> Update([FromBody]UpdateTransmissionRequest request, [FromRoute] int Id)
    {
        if (Id != request.Id)
            return BadRequest();

        UpdateTransmissionResponse response = _transmissionService.Update(request);
        return Ok(response);
    }
}
