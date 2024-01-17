using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Concrete;
using Business.Requests.Brand;
using Business.Requests.Fuel;
using Business.Requests.Transmission;
using Business.Responses.Brand;
using Business.Responses.Fuel;
using Business.Responses.Transmission;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace WebAPI;

public static class ServiceRegistration
{


  

    public static readonly IBrandDal BrandDal = new InMemoryBrandDal();

    public static readonly BrandBusinessRules BrandBusinessRules = new BrandBusinessRules(BrandDal);

    public static IMapper Mapper = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<AddBrandRequest, Brand>();
        cfg.CreateMap<Brand, AddBrandResponse>();

    }).CreateMapper();

    public static readonly IBrandService BrandService = new BrandManager(
        BrandDal,
        BrandBusinessRules,
        Mapper
    );
    public static readonly IFuelDal FueldDal = new InMemoryFuelDal();

    public static readonly FuelBusinessRules FuelBusinessRules = new FuelBusinessRules(FueldDal);

    public static IMapper FuelMapper = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<AddFuelRequest, Fuel>();
        cfg.CreateMap<Fuel, AddFuelResponse>();
        cfg.CreateMap<DeleteFuelRequest, Fuel>();
        cfg.CreateMap<UpdateFuelRequest, Fuel>();
        cfg.CreateMap<GetByIDFuelResponse, Fuel>();
        cfg.CreateMap<Fuel, GetByIDFuelResponse>();
    }).CreateMapper();

    public static readonly IFuelService FuelService = new FuelManager(
        FueldDal,
        FuelBusinessRules,
        FuelMapper
    );
    public static readonly ITransmissionDal TransmissiondDal = new InMemoryTransmissionDal();

    public static readonly TransmissionBusinessRules TransmissionBusinessRules = new TransmissionBusinessRules(TransmissiondDal);

    public static IMapper TransmissionMapper = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<AddTransmissionRequest, Transmission>();
        cfg.CreateMap<Transmission, AddTransmissionResponse>();
        cfg.CreateMap<DeleteTransmissionRequest, Transmission>();
        cfg.CreateMap<UpdateTransmissionRequest, Transmission>();
        cfg.CreateMap<GetByIDTransmissionResponse, Transmission>();
        cfg.CreateMap<Transmission, GetByIDTransmissionResponse>();

    }).CreateMapper();

    public static readonly ITransmissionService TransmissionService = new TransmissionManager(
        TransmissiondDal,
        TransmissionBusinessRules,
        TransmissionMapper
    );
} // IoC Container yapımızı kurduğumuz Dependency Injection ile daha verimli hale getiricez.
