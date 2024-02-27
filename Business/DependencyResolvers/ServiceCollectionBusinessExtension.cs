using System.Reflection;
using Business.Abstract;
using Business.BusinessRules;
using Business.Concrete;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Business.DependencyResolvers;

public static class ServiceCollectionBusinessExtension

{
    //Extension method
    public static IServiceCollection AddBusinessServices(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<ITokenHelper, JwtTokenHelper>();

        //Brand
        services.AddScoped<IBrandDal, EfBrandDal>();
        services.AddScoped<IBrandService, BrandManager>();
        services.AddScoped<BrandBusinessRules>();
        //reflection yöntemiyle Profile class'ını kalıtım alan tüm class'ları bulur ve automapleme yapar.
        // ödev singleton ve diğerlerini araştır.Addscoped her isteyen için new yapar.Tek new için singleton
        //Addtransient http req geldiğinde scope açılır onlara rules ekleyebilir.

        //Fuel
        services.AddScoped<IFuelDal, EfFuelDal>();
        services.AddScoped<IFuelService, FuelManager>();
        services.AddScoped<FuelBusinessRules>();

        //Transmission
        services.AddScoped<ITransmissionDal, EfTransmissionDal>();
        services.AddScoped<ITransmissionService, TransmissionManager>();
        services.AddScoped<TransmissionBusinessRules>();

        //Model
        services.AddScoped<IModelDal, EfModelDal>();
        services.AddScoped<IModelService, ModelManager>();
        services.AddScoped<ModelBusinessRules>();

        //Car
        services.AddScoped<ICarDal, EfCarDal>();
        services.AddScoped<ICarService, CarManager>();
        services.AddScoped<CarBusinessRules>();

        //Users
        services.AddScoped<IUsersDal, EfUsersDal>();
        services.AddScoped<IUsersService, UsersManager>();
        services.AddScoped<UsersBusinessRules>();

        //Role
        services.AddScoped<IRoleDal, EfRoleDal>();
        services.AddScoped<IRoleService, RoleManager>();

        //Customers
        services.AddScoped<ICustomersDal, EfCustomersDal>();
        services.AddScoped<ICustomersService, CustomersManager>();
        services.AddScoped<CustomersBusinessRules>();

        //IndividualCustomer
        services.AddScoped<IindividualCustomerDal, EfIndividualDal>();
        services.AddScoped<IindividualCustomerService, IndividualCustomerManager>();
        services.AddScoped<IndvCustBusinessRules>();

        //CorporateCustomer
        services.AddScoped<ICorporateCustomerDal, EfCorporateCustomerDal>();
        services.AddScoped<ICorporateCustomerService, CorporateCustomerManager>();
        services.AddScoped<CorpCustBusinessRules>();



        services.AddDbContext<RentACarContext>(options => options.UseSqlServer(configuration.GetConnectionString("RentACarMSSQL22")));
        return services;
    }
}
