
using Business.Requests.Model;
using Business.Responses.Model;

namespace Business.Abstract;

public interface IModelService
{
    public AddModelResponse Add(AddModelRequest request);

    public GetModelListResponse GetList(GetModelListRequest request);

    public GetByIDModelResponse GetById(GetModelByIdRequest id);
    public DeleteModelResponse Delete(DeletModelRequest request);
    public UpdateModelResponse Update(UpdateModelRequest request);
}
