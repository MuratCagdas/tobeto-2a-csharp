using Business.Abstract;
using Business.Requests.IndividualCustomer;
using Business.Responses.IndividualCustomer;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class IndividualCustomerController : Controller
{
    private readonly IindividualCustomerService _indvService;
    public IndividualCustomerController(IindividualCustomerService indvService)
    {
        _indvService = indvService;
    }
    [HttpGet] // GET http://localhost:5245/api/fuel
    public GetIndCusListResponse GetList([FromQuery] GetIndCustListRequest request)
    {
        GetIndCusListResponse response = _indvService.GetList(request);
        return response;
    }
    [HttpGet("{Id}")]
    public GetByIdIndCusResponse GetById(GetIndCustByIdRequest request)
    {
        GetByIdIndCusResponse response = _indvService.GetById(request);
        return response;
    }

    //[HttpPost("/add")] // POST http://localhost:5245/api/fuel/add
    [HttpPost] // POST http://localhost:5245/api/fuel
    public ActionResult<AddIndCusResponse> Add(AddIndvCusRequest request)
    {
        AddIndCusResponse response = _indvService.Add(request);
        return CreatedAtAction( // 201 Created
            actionName: nameof(GetById),
            routeValues: new { Id = response.Id }, // Anonymous object
                                                   // Response Header: Location=http://localhost:5245/api/models/1

            value: response // Response Body: JSON
        );
    }
    [HttpPut("{Id}")] // PUT http://localhost:5245/api/models/1
    public ActionResult<UpdateIndCusResponse> Update(
        [FromRoute] int Id,
        [FromBody] UpdateIndCusRequest request
    )
    {
        if (Id != request.Id)
            return BadRequest();

        UpdateIndCusResponse response = _indvService.Update(request);
        return Ok(response);
    }

    [HttpDelete("{Id}")] // DELETE http://localhost:5245/api/models/1
    public DeleteIndCusResponse Delete([FromRoute] DeleteIndvCusRequest request)
    {
        DeleteIndCusResponse response = _indvService.Delete(request);
        return response;
    }
}
