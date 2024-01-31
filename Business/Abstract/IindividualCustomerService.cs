

using Business.Requests.IndividualCustomer;
using Business.Responses.IndividualCustomer;

namespace Business.Abstract;

public interface IindividualCustomerService
{
    public AddIndCusResponse Add(AddIndvCusRequest request);
    public GetIndCusListResponse GetList(GetIndCustListRequest request);
    public GetByIdIndCusResponse GetById(GetIndCustByIdRequest id);
    public DeleteIndCusResponse Delete(DeleteIndvCusRequest request);
    public UpdateIndCusResponse Update(UpdateIndCusRequest request);
}
