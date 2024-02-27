using Business.Abstract;
using Business.Requests.Users;
using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[Route("api/[controller]/[Action]")]
[ApiController]
public class UsersController : Controller
{
    private readonly IUsersService _userService;

    public UsersController(IUsersService userService)
    {
        _userService = userService;
    }


    [HttpPost("Register")]
    public void Register([FromBody] RegisterRequest request)
    {
        _userService.Register(request);
    }
    [HttpPost("Login")]
    public AccessToken Login([FromBody] LoginRequest request)
    {
        return _userService.Login(request);
    }
}
