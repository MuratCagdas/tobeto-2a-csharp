
using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Transmission;
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

    public GetTransmissionListResponse GetList(GetTransmissionListRequest request)
    {
        IList<Transmission> transmissionlList = _transmissionDal.GetList();
        GetTransmissionListResponse response = _mapper.Map<GetTransmissionListResponse>(transmissionlList);

        return response;
    }
    public GetByIDTransmissionResponse GetById(GetByIDTransmissionRequest id)
    {
        _transmissionBusinessRules.CheckIfFuelExists(id.ID);
        Transmission? transmission = _transmissionDal.GetList().First<Transmission>(b => b.Id == id.ID);
        GetByIDTransmissionResponse response = _mapper.Map<GetByIDTransmissionResponse>(transmission);

        return response;
    }
    public DeleteTransmissionResponse Delete(DeleteTransmissionRequest request)
    {
        _transmissionBusinessRules.CheckIfFuelExists(request.Id);
        Transmission DeleteFuel = _mapper.Map<Transmission>(request);
        _transmissionDal.Delete(DeleteFuel);
        DeleteTransmissionResponse response = _mapper.Map<DeleteTransmissionResponse>(DeleteFuel);
        return response;
    }
    public UpdateTransmissionResponse Update(UpdateTransmissionRequest request)
    {
        _transmissionBusinessRules.CheckIfFuelExists(request.Id);
        Transmission UpdateFuel = _mapper.Map<Transmission>(request);
        Transmission updatedTransmission = _transmissionDal.Update(UpdateFuel);
        UpdateTransmissionResponse response = _mapper.Map<UpdateTransmissionResponse>(updatedTransmission);
        return response;
    }
}
