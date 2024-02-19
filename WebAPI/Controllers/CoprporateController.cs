using Business.Abstract;
using Business.Requests.CorporateCustomer;
using Business.Responses.CorporateCustomer;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[Route("api/[controller]/[Action]")]
[ApiController]
public class CoprporateController : Controller
{
    private readonly ICorporateCustomerService _CorporateCustomerService;
    public CoprporateController(ICorporateCustomerService corporateCustomerService)
    {
        _CorporateCustomerService = corporateCustomerService;
    }
    [HttpGet] // GET http://localhost:5245/api/fuel
    public GetCorpCustListResponse GetList([FromQuery] GetCorpCustListRequest request)
    {
        GetCorpCustListResponse response = _CorporateCustomerService.GetList(request);
        return response;
    }
    [HttpGet("{Id}")]
    public GetByIdCorpCustResponse GetById(GetCorpCustByIdRequest request)
    {
        GetByIdCorpCustResponse response = _CorporateCustomerService.GetById(request);
        return response;
    }

    //[HttpPost("/add")] // POST http://localhost:5245/api/fuel/add
    [HttpPost] // POST http://localhost:5245/api/fuel
    public ActionResult<AddCorpCustResponse> Add(AddCorpCustRequest request)
    {
        AddCorpCustResponse response = _CorporateCustomerService.Add(request);
        return CreatedAtAction( // 201 Created
            actionName: nameof(GetById),
            routeValues: new { Id = response.Id }, // Anonymous object
                                                   // Response Header: Location=http://localhost:5245/api/models/1

            value: response // Response Body: JSON
        );
    }
    [HttpPut("{Id}")] // PUT http://localhost:5245/api/models/1
    public ActionResult<UpdateCorpCustResponse> Update(
        [FromRoute] int Id,
        [FromBody] UpdateCorpCustRequest request
    )
    {
        if (Id != request.Id)
            return BadRequest();

        UpdateCorpCustResponse response = _CorporateCustomerService.Update(request);
        return Ok(response);
    }

    [HttpDelete("{Id}")] // DELETE http://localhost:5245/api/models/1
    public DeleteCorpCustResponse Delete([FromRoute] DeleteCorpCustRequest request)
    {
        DeleteCorpCustResponse response = _CorporateCustomerService.Delete(request);
        return response;
    }
}
