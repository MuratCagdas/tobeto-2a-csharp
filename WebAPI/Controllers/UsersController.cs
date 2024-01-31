using Business.Abstract;
using Business.Requests.Users;
using Business.Responses.Users;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[Route("api/[controller]/[Action]")]
[ApiController]
public class UsersController : Controller
{
    private readonly IUsersService _usersService;
    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }
    [HttpGet] // GET http://localhost:5245/api/fuel
    public GetUsersListResponse GetList([FromQuery] GetUsersListRequest request)
    {
        GetUsersListResponse response = _usersService.GetList(request);
        return response;
    }
    [HttpGet("{Id}")]
    public GetByIdUsersResponse GetById(GetUsersByIdRequest request)
    {
        GetByIdUsersResponse response = _usersService.GetById(request);
        return response;
    }

    //[HttpPost("/add")] // POST http://localhost:5245/api/fuel/add
    [HttpPost] // POST http://localhost:5245/api/fuel
    public ActionResult<AddUsersResponse> Add(AddUsersRequest request)
    {
        AddUsersResponse response = _usersService.Add(request);
        return CreatedAtAction( // 201 Created
            actionName: nameof(GetById),
            routeValues: new { Id = response.Id }, // Anonymous object
                                                   // Response Header: Location=http://localhost:5245/api/models/1

            value: response // Response Body: JSON
        );
    }
    [HttpPut("{Id}")] // PUT http://localhost:5245/api/models/1
    public ActionResult<UpdateUsersResponse> Update(
        [FromRoute] int Id,
        [FromBody] UpdateUsersRequest request
    )
    {
        if (Id != request.Id)
            return BadRequest();

        UpdateUsersResponse response = _usersService.Update(request);
        return Ok(response);
    }

    [HttpDelete("{Id}")] // DELETE http://localhost:5245/api/models/1
    public DeleteUsersResponse Delete([FromRoute] DeleteUsersRequest request)
    {
        DeleteUsersResponse response = _usersService.Delete(request);
        return response;
    }
}
