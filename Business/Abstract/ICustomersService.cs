
using Business.Requests.Customers;
using Business.Responses.Customers;

namespace Business.Abstract;

public interface ICustomersService
{
    public AddCustomersResponse Add(AddCustomersRequest request);
    public GetCustomersListResponse GetList(GetCustomersListRequest request);
    public GetByIdCustomersResponse GetById(GetCustomersByIdRequest id);
    public DeleteCustomersResponse Delete(DeleteCustomersRequest request);
    public UpdateCustomersResponse Update(UpdateCustomersRequest request);
}
