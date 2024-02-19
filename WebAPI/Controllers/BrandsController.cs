using Business;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]/[Action]")]
[ApiController]
public class BrandsController : ControllerBase
{
    private readonly IBrandService _brandService; // Field

    public BrandsController(IBrandService brandService)
    {
        // Her HTTP Request için yeni bir Controller nesnesi oluşturulur.
        _brandService = brandService;
        // Daha sonra IoC Container yapımızı kurduğumuz Dependency Injection ile daha verimli hale getiricez.
    }
}
