
using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Model;
using Business.Responses.Model;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class ModelManager : IModelService

{
    private readonly IModelDal  _modelDal;
    private readonly ModelBusinessRules _modelBusinessRules;
    private readonly IMapper _mapper;

    public  ModelManager(IModelDal modelDal, ModelBusinessRules modelBusinessRules, IMapper mapper)
    {
        _modelDal = modelDal;
        _modelBusinessRules = modelBusinessRules;
        _mapper = mapper;
    }
    public AddModelResponse Add(AddModelRequest request)
    {
        _modelBusinessRules.CheckIfModelNameExists(request.Name);

        // mapping
        var modelToAdd = _mapper.Map<Model>(request);

        // data operations
        Model updatedModel = _modelDal.Add(modelToAdd);

        // mapping & response
        var response = _mapper.Map<AddModelResponse>(updatedModel);
        return response;
    }

    public DeleteModelResponse Delete(DeletModelRequest request)
    {
        throw new NotImplementedException();
    }

    public GetByIDModelResponse GetById(GetModelByIdRequest id)
    {
        throw new NotImplementedException();
    }

    public GetModelListResponse GetList(GetModelListRequest request)
    {
        IList<Model> modelList = _modelDal.GetList(
        predicate: model =>
        (request.FilterByBrandId == null || model.BrandId == request.FilterByBrandId)
        && (request.FilterByFuelId == null || model.FuelId == request.FilterByFuelId)
        && (
            request.FilterByTransmissionId == null
            || model.TransmissionId == request.FilterByTransmissionId
         )
        );
        var response = _mapper.Map<GetModelListResponse>(modelList);
        return response;
    }

    public UpdateModelResponse Update(UpdateModelRequest request)
    {
        throw new NotImplementedException();
    }
}
