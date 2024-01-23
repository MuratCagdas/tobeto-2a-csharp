using Business.Requests.Fuel;
using Business.Responses.Fuel;

namespace Business.Abstract;

public interface IFuelService
{
    public AddFuelResponse Add(AddFuelRequest request);

    public GetFuelListResponse GetList(GetFuelListRequest request);


    public GetByIDFuelResponse GetById(int id);
    public DeleteFuelResponse Delete(DeleteFuelRequest request);
    public UpdateFuelResponse Update(UpdateFuelRequest request);

}
