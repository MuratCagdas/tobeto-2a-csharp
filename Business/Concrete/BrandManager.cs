using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Brand;
using Business.Responses.Brand;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete;

public class BrandManager : IBrandService
{
    private readonly IBrandDal _brandDal; //Bir entity Service'i kendi entity dışında başka bir entity enjekte etmemelidir.
                                          //Bir servis başka bir entitye daima servis ile erişir.
    private readonly BrandBusinessRules _brandBusinessRules;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public BrandManager(IBrandDal brandDal, BrandBusinessRules brandBusinessRules, IMapper mapper, IHttpContextAccessor httpContextAccessor)
    {
        _brandDal = brandDal; //new InMemoryBrandDal(); // Başka katmanların class'ları new'lenmez. Bu yüzden dependency injection kullanıyoruz.
        _brandBusinessRules = brandBusinessRules;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
    }

    public AddBrandResponse Add(AddBrandRequest request)
    {
        // BrandAdmin
        if (!_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
        {
            throw new Exception("Bu endpointi çalıştırmak için giriş yapmak zorundasınız!");
        }
        // İş Kuralları
        _brandBusinessRules.CheckIfBrandNameNotExists(request.Name);

        // Validation
        // Yetki kontrolü
        // Cache
        // Transaction

        //Brand brandToAdd = new(request.Name)
        Brand brandToAdd = _mapper.Map<Brand>(request); // Mapping

        _brandDal.Add(brandToAdd);

        AddBrandResponse response = _mapper.Map<AddBrandResponse>(brandToAdd);
        return response;
    }

    public GetBrandListResponse GetList(GetBrandListRequest request)
    {
        // İş Kuralları
        // Validation
        // Yetki kontrolü
        // Cache
        // Transaction

        IList<Brand> brandList = _brandDal.GetList();
        GetBrandListResponse response = _mapper.Map<GetBrandListResponse>(brandList);
        return response;
    }
    public Brand? GetById(int id)
    {
        return _brandDal.Get(i => i.Id == id);
    }
}
