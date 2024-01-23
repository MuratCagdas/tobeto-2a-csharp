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
        GetModelListResponse fuelList = _modelService.GetList(request);
        return fuelList;
    }
    [HttpGet("{id}")]
    public GetByIDModelResponse getById(GetModelByIdRequest id)
    {
        GetByIDModelResponse response = _modelService.GetById(id);
        return response;
    }

    //[HttpPost("/add")] // POST http://localhost:5245/api/fuel/add
    [HttpPost] // POST http://localhost:5245/api/fuel
    public ActionResult<AddModelResponse> Add(AddModelRequest request)
    {
        AddModelResponse response = _modelService.Add(request);

        return CreatedAtAction(nameof(GetList), response);
    }
    //[HttpDelete("{id}")]
    [HttpDelete]
    public DeleteModelResponse Delete(DeletModelRequest request)
    {
        DeleteModelResponse response = _modelService.Delete(request);
        return response;
    }
    [HttpPut]
    public UpdateModelResponse Update(UpdateModelRequest request)
    {
        UpdateModelResponse response = _modelService.Update(request);
        return response;
    }
}
