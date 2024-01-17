
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.BusinessRules;

public class TransmissionBusinessRules
{
    private readonly ITransmissionDal _transmissionDal;

    public TransmissionBusinessRules(ITransmissionDal transmissionDal)
    {
        _transmissionDal = transmissionDal;
    }

    public void CheckIfTransmissionNameNotExists(string transmissionName)
    {
        bool isExists = _transmissionDal.GetList().Any(b => b.Name == transmissionName);
        if (isExists)
        {
            throw new Exception("Transmission already exists.");
        }
    }
    public void CheckIfFuelExists(int fuelId)
    {
        bool fuelExist = _transmissionDal.GetList().Any(b => b.Id == fuelId);
        if (!fuelExist)
        {
            throw new Exception("No Fuel");
        }

    }
}
