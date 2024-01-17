using Business.Requests.Fuel;
using Business.Requests.Transmission;
using Business.Responses.Fuel;
using Business.Responses.Transmission;
using Entities.Concrete;

namespace Business.Abstract;

public interface ITransmissionService
{
    public AddTransmissionResponse Add(AddTransmissionRequest request);

    public IList<Transmission> GetList();
    public GetByIDTransmissionResponse GetById(int id);
    public void Delete(DeleteTransmissionRequest request);
    public void Update(UpdateTransmissionRequest request);
}
