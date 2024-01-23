
using Business.Abstract;
using Business.BusinessRules;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Business.DependencyResolvers;

public static class ServiceCollectionBusinessExtension

{
    //Extension method
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        //Brand
        services.AddSingleton<IBrandDal, InMemoryBrandDal>();
        services.AddSingleton<IBrandService, BrandManager>();
        services.AddSingleton<BrandBusinessRules>();
        //reflection yöntemiyle Profile class'ını kalıtım alan tüm class'ları bulur ve automapleme yapar.
        // ödev singleton ve diğerlerini araştır.Addscoped her isteyen için new yapar.Tek new için singleton
        //Addtransient http req geldiğinde scope açılır onlara rules ekleyebilir.

        //Fuel
        services.AddSingleton<IFuelDal, InMemoryFuelDal>();
        services.AddSingleton<IFuelService, FuelManager>();
        services.AddSingleton<FuelBusinessRules>();

        //Transmission
        services.AddSingleton<ITransmissionDal, InMemoryTransmissionDal>();
        services.AddSingleton<ITransmissionService, TransmissionManager>();
        services.AddSingleton<TransmissionBusinessRules>();

        //Model
        services.AddSingleton<IModelDal, InMemoryModelDal>();
        services.AddSingleton<IModelService, ModelManager>();
        services.AddSingleton<ModelBusinessRules>();

        //Car
        services.AddSingleton<ICarDal, InMemoryCarDal>();
        services.AddSingleton<ICarService, CarManager>();
        services.AddSingleton<CarBusinessRules>();

        return services;
    }
}
