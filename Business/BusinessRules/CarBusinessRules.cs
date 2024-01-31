
using DataAccess.Abstract;
using Entities.Concrete;
namespace Business.BusinessRules;

public class CarBusinessRules
{
    private readonly ICarDal _carDal;

    public CarBusinessRules(ICarDal carDal)
    {
        _carDal = carDal;
    }
    public void CheckIfFuelExists(int carId)
    {
        bool fuelExist = _carDal.GetList().Any<Car>(b => b.Id == carId);
        if (!fuelExist)
        {
            throw new Exception("No Fuel");
        }
    }
}
