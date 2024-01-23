using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.BusinessRules;

public class FuelBusinessRules
{
    private readonly IFuelDal _fuelDal;

    public FuelBusinessRules(IFuelDal fuelDal)
    {
        _fuelDal = fuelDal;
    }

    public void CheckIfFuelNameNotExists(string fuelName)
    {
        bool isExists = _fuelDal.GetList().Any<Fuel>(b => b.Name == fuelName);
        if (isExists)
        {
            throw new Exception("Fuel already exists.");
        }
    }
    public void CheckIfFuelExists(int fuelId)
    {
        bool fuelExist = _fuelDal.GetList().Any<Fuel>(b => b.Id == fuelId);
        if (!fuelExist)
        {
            throw new Exception("No Fuel");
        }
    }
}
