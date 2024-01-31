using Business.Requests.Transmission;
using Business.Responses.Transmission;

namespace Business.Abstract;

public interface ITransmissionService
{
    public AddTransmissionResponse Add(AddTransmissionRequest request);
    public GetTransmissionListResponse GetList(GetTransmissionListRequest request);
    public GetByIDTransmissionResponse GetById(GetByIDTransmissionRequest id);
    public DeleteTransmissionResponse Delete(DeleteTransmissionRequest request);
    public UpdateTransmissionResponse Update(UpdateTransmissionRequest request);
}
