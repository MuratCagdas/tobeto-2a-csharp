
using Business.Requests.Car;
using Business.Responses.Car;

namespace Business.Abstract;

public interface ICarService
{
    public AddCarResponse Add(AddCarRequest request);

    public GetCarListResponse GetList(GetCarListRequest request);

    public GetByIDCarResponse GetById(GetByIDCarRequest id);
    public DeleteCarResponse Delete(DeletCarRequest request);
    public UpdateCarResponse Update(UpdateCarRequest request);
}
