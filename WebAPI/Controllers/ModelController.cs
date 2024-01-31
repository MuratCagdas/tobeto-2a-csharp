using Business.Abstract;
using Business.Requests.Model;
using Business.Responses.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]/[Action]")]
[ApiController]
public class ModelController : ControllerBase
{
    private readonly IModelService _modelService;
    public ModelController(IModelService modelService)
    {
        _modelService = modelService;
    }
    [HttpGet] // GET http://localhost:5245/api/fuel
    public GetModelListResponse GetList([FromQuery] GetModelListRequest request)
    {
        GetModelListResponse response = _modelService.GetList(request);
        return response;
    }
    [HttpGet("{Id}")]
    public GetByIDModelResponse GetById(GetModelByIdRequest request)
    {
        GetByIDModelResponse response = _modelService.GetById(request);
        return response;
    }

    //[HttpPost("/add")] // POST http://localhost:5245/api/fuel/add
    [HttpPost] // POST http://localhost:5245/api/fuel
    public ActionResult<AddModelResponse> Add(AddModelRequest request)
    {
        AddModelResponse response = _modelService.Add(request);
        return CreatedAtAction( // 201 Created
            actionName: nameof(GetById),
            routeValues: new { Id = response.Id }, // Anonymous object
                                                   // Response Header: Location=http://localhost:5245/api/models/1

            value: response // Response Body: JSON
        );
    }
    [HttpPut("{Id}")] // PUT http://localhost:5245/api/models/1
    public ActionResult<UpdateModelResponse> Update(
        [FromRoute] int Id,
        [FromBody] UpdateModelRequest request
    )
    {
        if (Id != request.Id)
            return BadRequest();

        UpdateModelResponse response = _modelService.Update(request);
        return Ok(response);
    }

    [HttpDelete("{Id}")] // DELETE http://localhost:5245/api/models/1
    public DeleteModelResponse Delete([FromRoute] DeletModelRequest request)
    {
        DeleteModelResponse response = _modelService.Delete(request);
        return response;
    }
}
