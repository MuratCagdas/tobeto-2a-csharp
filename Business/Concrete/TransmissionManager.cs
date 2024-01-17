
using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Fuel;
using Business.Requests.Transmission;
using Business.Responses.Fuel;
using Business.Responses.Transmission;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class TransmissionManager : ITransmissionService
{
    private readonly ITransmissionDal _transmissionDal;
    private readonly TransmissionBusinessRules _transmissionBusinessRules;
    private readonly IMapper _mapper;
    public TransmissionManager(ITransmissionDal transmissiondDal, TransmissionBusinessRules transmissionBusinessRules, IMapper mapper)
    {
        _transmissionDal = transmissiondDal;
        _transmissionBusinessRules = transmissionBusinessRules;
        _mapper = mapper;
    }

    public AddTransmissionResponse Add(AddTransmissionRequest request)
    {
        _transmissionBusinessRules.CheckIfTransmissionNameNotExists(request.Name);
        Transmission transmissionToAdd = _mapper.Map<Transmission>(request);

        _transmissionDal.Add(transmissionToAdd);

        AddTransmissionResponse response = _mapper.Map<AddTransmissionResponse>(transmissionToAdd);
        return response;
    }

    public IList<Transmission> GetList()
    {
        IList<Transmission> transmissionlList = _transmissionDal.GetList();
        return transmissionlList;
    }
    public GetByIDTransmissionResponse GetById(int id)
    {
        _transmissionBusinessRules.CheckIfFuelExists(id);
        Transmission? transmission = _transmissionDal.GetList().First<Transmission>(b => b.Id == id);
        GetByIDTransmissionResponse response = _mapper.Map<GetByIDTransmissionResponse>(transmission);

        return response;
    }
    public void Delete(DeleteTransmissionRequest request)
    {
        _transmissionBusinessRules.CheckIfFuelExists(request.Id);
        Transmission DeleteFuel = _mapper.Map<Transmission>(request);
        _transmissionDal.Delete(DeleteFuel);
    }
    public void Update(UpdateTransmissionRequest request)
    {
        _transmissionBusinessRules.CheckIfFuelExists(request.Id);
        Transmission UpdateFuel = _mapper.Map<Transmission>(request);
        _transmissionDal.Update(UpdateFuel);
    }
}
